using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductById
{
    public class GetProductByIdQuery: IGetProductByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetProductByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetProductByIdModel> Execute(int ProductId)
        {
            var entity = await _dataBaseService.Producto
                .FirstOrDefaultAsync(x => x.Id == ProductId);
            return _mapper.Map<GetProductByIdModel>(entity);
        }
    }
}
