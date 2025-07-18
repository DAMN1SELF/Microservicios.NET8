
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales
{
    public class GetAllSaleQuery: IGetAllSaleQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllSaleQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllSaleModel>> Execute()
        {
            var listEntities = await _dataBaseService.Producto.ToListAsync();
            return _mapper.Map<List<GetAllSaleModel>>(listEntities);
        }
    }
}
