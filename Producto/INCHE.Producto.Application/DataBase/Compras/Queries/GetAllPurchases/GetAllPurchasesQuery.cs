
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Purchase.Queries.GetAllPurchases
{
    public class GetAllPurchasesQuery : IGetAllPurchasesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllPurchasesQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<ResponsePurchaseModel>> Execute(bool IncludeDetails)
        {

            if (IncludeDetails)
            {
                var listEntities = await _dataBaseService.CompraCab
                    .Include(x => x.Detalles)
                    .ToListAsync();
                return _mapper.Map<List<ResponsePurchaseModel>>(listEntities);
            }
            else
            {

				var listEntities = await _dataBaseService.CompraCab
                    .ToListAsync();
				return _mapper.Map<List<ResponsePurchaseModel>>(listEntities);
			}


        }
    }
}
