using AutoMapper;
using INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement;
using INCHE.Producto.Application.DataBase.Product;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.Ventas;
using System.Net.Http;
using System.Net.Http.Json;

namespace INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
	{
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
		private readonly IHttpClientFactory _httpClientFactory;

		public CreateSaleCommand(
		IDataBaseService dataBaseService,
		IHttpClientFactory httpClientFactory,
		IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_httpClientFactory = httpClientFactory;
			_mapper = mapper;
		}

        public async Task<CreateSaleModel> Execute(CreateSaleModel model)
        {


			using var transaction = await _dataBaseService.BeginTransactionAsync();
			try
			{
				var ventaCab = _mapper.Map<VentaCabEntity>(model);
				await _dataBaseService.VentaCab.AddAsync(ventaCab);
				await _dataBaseService.SaveAsync();

				#region insertar movimiento de inventario
				var movimientoModel = _mapper.Map<CreateMovementModel>(ventaCab);

				var httpClient = _httpClientFactory.CreateClient("API_Movimiento");
				var response = await httpClient.PostAsJsonAsync("api/v1/Movimiento/registrar-movimiento", movimientoModel);

				if (!response.IsSuccessStatusCode)
				{
					await transaction.RollbackAsync();
					throw new Exception("Error al registrar el movimiento de inventario");
				}
				#endregion
				await transaction.CommitAsync();

				var resultModel = _mapper.Map<CreateSaleModel>(ventaCab);
				return resultModel;
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw new ApplicationException(Messages.RecordCreationFailed, ex);
			}
		}
    }
}
