using AutoMapper;
using INCHE.Producto.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById
{
    public class GetSaleByIdQuery : IGetSaleByIdQuery
	{
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetSaleByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<ResponseSaleModel> Execute(int SaleId, bool IncludeDetails)
        {

			if (IncludeDetails)
			{
				var entity = await _dataBaseService.VentaCab
					.Include(x => x.Detalles)
					.FirstOrDefaultAsync(x => x.VentaCabId == SaleId);
				if (entity == null) throw new Exception(Messages.RecordNotFound);
				return  _mapper.Map<ResponseSaleModel>(entity);
			}
			else
			{
				var entity = await _dataBaseService.VentaCab
					.FirstOrDefaultAsync(x => x.VentaCabId == SaleId);

				if (entity == null) throw new Exception(Messages.RecordNotFound);

				return _mapper.Map<ResponseSaleModel>(entity);
			}
		}
    }
}
