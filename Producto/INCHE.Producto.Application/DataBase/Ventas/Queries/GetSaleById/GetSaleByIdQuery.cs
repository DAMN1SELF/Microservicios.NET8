using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById
{
    public class GetSaleByIdQuery: IGetSaleByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetSaleByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetSaleByIdModel> Execute(int SaleId)
        {
            var entity = await _dataBaseService.Producto
                .FirstOrDefaultAsync(x => x.Id == SaleId);
            return _mapper.Map<GetSaleByIdModel>(entity);
        }
    }
}
