using AutoMapper;
using INCHE.Producto.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById
{
    public class GetMovementByIdQuery: IGetMovementByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetMovementByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<ResponseMovementModel> Execute(int PurchaseId, bool IncludeDetails)
        {

			if (IncludeDetails)
			{
				var entity = await _dataBaseService.MovimientoCab
					.Include(x => x.Detalles)
					.FirstOrDefaultAsync(x => x.MovimientoCabId == PurchaseId);
				if (entity == null) throw new Exception(Messages.RecordNotFound);
				return  _mapper.Map<ResponseMovementModel>(entity);
			}
			else
			{
				var entity = await _dataBaseService.MovimientoCab
					.FirstOrDefaultAsync(x => x.MovimientoCabId == PurchaseId);

				if (entity == null) throw new Exception(Messages.RecordNotFound);

				return _mapper.Map<ResponseMovementModel>(entity);
			}
		}
    }
}
