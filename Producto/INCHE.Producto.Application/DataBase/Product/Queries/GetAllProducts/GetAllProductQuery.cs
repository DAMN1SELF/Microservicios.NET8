
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts
{
    public class GetAllProductQuery: IGetAllProductQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllProductQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductModel>> Execute()
        {
            var listEntities = await _dataBaseService.Producto.ToListAsync();
            return _mapper.Map<List<GetAllProductModel>>(listEntities);
        }
    }
}
