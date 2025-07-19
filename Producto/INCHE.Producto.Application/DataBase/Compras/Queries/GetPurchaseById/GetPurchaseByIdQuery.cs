using AutoMapper;
using INCHE.Producto.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace INCHE.Producto.Application.DataBase.Purchase.Queries.GetPurchaseById
{
    public class GetPurchaseByIdQuery: IGetPurchaseByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetPurchaseByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<ResponsePurchaseModel> Execute(int PurchaseId, bool IncludeDetails)
        {

			if (IncludeDetails)
			{
				var entity = await _dataBaseService.CompraCab
					.Include(x => x.Detalles)
					.FirstOrDefaultAsync(x => x.CompraCabId== PurchaseId);
				if (entity == null) throw new Exception(Messages.RecordNotFound);
				return  _mapper.Map<ResponsePurchaseModel>(entity);
			}
			else
			{
				var entity = await _dataBaseService.CompraCab
					.FirstOrDefaultAsync(x => x.CompraCabId == PurchaseId);

				if (entity == null) throw new Exception(Messages.RecordNotFound);

				return _mapper.Map<ResponsePurchaseModel>(entity);
			}
		}
    }
}
