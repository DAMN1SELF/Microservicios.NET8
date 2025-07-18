using AutoMapper;
using INCHE.Producto.Application.DataBase.Product;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.Ventas;

namespace INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale
{
    public class CreateSaleCommand: ICreateSaleCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
		private readonly ITransactionalDbContext _transactionalContext;

		public CreateSaleCommand(
		IDataBaseService dataBaseService,
		ITransactionalDbContext transactionalContext,
		IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_transactionalContext = transactionalContext;
			_mapper = mapper;
		}

        public async Task<CreateSaleModel> Execute(CreateSaleModel model)
        {


			using var transaction = await _transactionalContext.BeginTransactionAsync();
			try
			{
				var ventaCab = _mapper.Map<VentaCabEntity>(model);
				await _dataBaseService.VentaCab.AddAsync(ventaCab);
				await _dataBaseService.SaveAsync();

				var detalles = model.Detalles.Select(det =>
				{
					var detalleEntity = _mapper.Map<VentaDetEntity>(det);
					detalleEntity.VentaCabId = ventaCab.VentaCabId; 
					return detalleEntity;
				}).ToList();

				await _dataBaseService.VentaDet.AddRangeAsync(detalles);
				await _dataBaseService.SaveAsync();

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
