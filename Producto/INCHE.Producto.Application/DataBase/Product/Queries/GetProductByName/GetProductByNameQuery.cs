
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName
{
    public class GetProductByNameQuery: IGetProductByNameQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetProductByNameQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<GetProductByNameModel> Execute(string documentNumber)
        {
            var entity = await _dataBaseService.Producto
                .FirstOrDefaultAsync(x=> x.NumeroLote == documentNumber);

            return _mapper.Map<GetProductByNameModel>(entity);
        }
    }
}
