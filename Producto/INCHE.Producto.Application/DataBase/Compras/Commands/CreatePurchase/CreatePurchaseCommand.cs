using AutoMapper;
using INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement;
using INCHE.Producto.Application.DataBase.Product.Commands.PatchProduct;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities.Compras;
using System.Net.Http;
using System.Net.Http.Json;

namespace INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase
{
    public class CreatePurchaseCommand: ICreatePurchaseCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
		private readonly IHttpClientFactory _httpClientFactory;
		public CreatePurchaseCommand(
		IDataBaseService dataBaseService,
		IHttpClientFactory httpClientFactory,
		IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_httpClientFactory = httpClientFactory;
			_mapper = mapper;
		}

        public async Task<CreatePurchaseModel> Execute(CreatePurchaseModel model)
        {
			using var transaction = await _dataBaseService.BeginTransactionAsync();

			try
			{
				var compraCab = _mapper.Map<CompraCabEntity>(model);
				await _dataBaseService.CompraCab.AddAsync(compraCab);
				await _dataBaseService.SaveAsync();



				#region actualizar precio de productos
				var productosPatch = _mapper.Map<List<PatchProductModel>>(model.Detalles);
				var httpClientProductos = _httpClientFactory.CreateClient("API_Producto");
				var responsePatch = await httpClientProductos.PatchAsJsonAsync("api/v1/Producto/actualizar-precios-masivo", productosPatch);
				if (!responsePatch.IsSuccessStatusCode)
				{
					await transaction.RollbackAsync();
					throw new Exception("Error al actualizar los precios de productos");
				}
				#endregion


				#region insertar movimiento de inventario
				var movimientoModel = _mapper.Map<CreateMovementModel>(compraCab);
				var httpClient = _httpClientFactory.CreateClient("API_Movimiento");
				var response = await httpClient.PostAsJsonAsync("api/v1/Movimiento/registrar-movimiento", movimientoModel);

				if (!response.IsSuccessStatusCode)
				{
					await transaction.RollbackAsync();
					throw new Exception("Error al registrar el movimiento de inventario");
				}
				#endregion
				
				
				await transaction.CommitAsync();

				var resultModel = _mapper.Map<CreatePurchaseModel>(compraCab);
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
