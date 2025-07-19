using AutoMapper;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities.Movimientos;

namespace INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement
{
    public class CreateMovementCommand: ICreateMovementCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

		public CreateMovementCommand(
		IDataBaseService dataBaseService,
		IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_mapper = mapper;
		}

        public async Task<ResponseMovementModel> Execute(CreateMovementModel model)
        {


			using var transaction = await _dataBaseService.BeginTransactionAsync();
			try
			{
				var movimientoCab = _mapper.Map<MovimientoCabEntity>(model);
				await _dataBaseService.MovimientoCab.AddAsync(movimientoCab);
				await _dataBaseService.SaveAsync();

				await transaction.CommitAsync();

				var resultModel = _mapper.Map<ResponseMovementModel>(movimientoCab);
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
