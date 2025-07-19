
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetAllProductsStock
{
    public class GetAllProductStockQuery : IGetAllProductStockQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllProductStockQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductStockModel>> Execute()
        {

			#region ENDPOINT : /api/movimientos-detallado
			var movCabList = await _dataBaseService.MovimientoCab.ToListAsync();
			var movDetList = await _dataBaseService.MovimientoDet.ToListAsync();
			#endregion
			var movimientos = from det in movDetList
							  join cab in movCabList on det.MovimientoCabId equals cab.MovimientoCabId
							  select new
							  {
								  det.ProductoId,
								  det.Cantidad,
								  cab.TipoMovimiento
							  };

			var productoList = await _dataBaseService.Producto.ToListAsync();

			var stockPorProducto = movimientos
				.GroupBy(x => x.ProductoId)
				.Select(g => new {
					Id_Producto = g.Key,
					Stock_Actual = g.Sum(x =>
						x.TipoMovimiento == 1 ? x.Cantidad :
						x.TipoMovimiento == 2 ? -x.Cantidad : 0)
				})
				.ToList();

			var resultado = (from p in productoList
							 join s in stockPorProducto on p.Id equals s.Id_Producto into ps
							 from s in ps.DefaultIfEmpty()
							 select new GetAllProductStockModel
							 {
								 Id_producto = p.Id,
								 nombre_producto = p.Nombre,
								 stock_actual = s?.Stock_Actual ?? 0,
								 costo = p.Costo,
								 precio_venta = p.PrecioVenta
							 })
							 .OrderByDescending(r => r.stock_actual)
							 .ToList();

			return resultado;

		}
    }
}
