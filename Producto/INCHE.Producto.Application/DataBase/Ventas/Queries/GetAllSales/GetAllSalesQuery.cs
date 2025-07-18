
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales
{
    public class GetAllSalesQuery : IGetAllSalesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllSalesQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<ResponseSaleModel>> Execute(bool IncludeDetails)
        {

            if (IncludeDetails)
            {
                var listEntities = await _dataBaseService.VentaCab
                    .Include(x => x.Detalles)
                    .ToListAsync();
                return _mapper.Map<List<ResponseSaleModel>>(listEntities);
            }
            else
            {

				var listEntities = await _dataBaseService.VentaCab
                    .ToListAsync();
				return _mapper.Map<List<ResponseSaleModel>>(listEntities);
			}


        }
    }
}
