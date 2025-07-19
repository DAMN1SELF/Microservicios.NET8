
using AutoMapper;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.Ventas;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Commands.PatchProduct
{
    public class PatchProductCommand: IPatchProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper; 
		public PatchProductCommand(IDataBaseService dataBaseService, 
			IMapper mapper)
        {
            _dataBaseService = dataBaseService; 
			_mapper = mapper;
        }


	
		public async Task<List<PatchProductResultModel>> Execute(List<PatchProductModel> listaproductos)
		{
			using var transaction = await _dataBaseService.BeginTransactionAsync();
			try
			{
				
				var idsBusqueda = listaproductos.Select(p => p.IdProducto).ToList();
				var lstProductosUpd = await _dataBaseService.Producto
					.Where(p => idsBusqueda.Contains(p.Id)).ToListAsync();

				// Compara por Id y Nombre
				var ListaPatch = new List<PatchProductModel>();
				foreach (var producto in listaproductos)
				{
					var entity = lstProductosUpd
						.FirstOrDefault(e => e.Id == producto.IdProducto && e.Nombre == producto.NombreProducto);
					if (entity == null)
					{
						ListaPatch.Add(producto);
						continue;
					}
					entity.FechaRegistro= DateTime.Now;
					entity.Costo = producto.PrecioProducto;
					entity.PrecioVenta = producto.PrecioProducto * ApplicationConstants.MARGEN_PRECIO_VENTA;
				}

				if (ListaPatch.Any())
				{
					await transaction.RollbackAsync();
					throw new Exception("No se encontraron los siguientes productos: " +
						string.Join(", ", ListaPatch.Select(x => $"Id={x.IdProducto}, Nombre={x.NombreProducto}")));
				}
				_dataBaseService.Producto.UpdateRange(lstProductosUpd);
				await _dataBaseService.SaveAsync();
				await transaction.CommitAsync();

				return _mapper.Map<List<PatchProductResultModel>>(lstProductosUpd);
			}
			catch (Exception)
			{
				throw ;
			}
		}

	}
}

