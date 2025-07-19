
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetAllMovements
{
    public class GetAllMovementsQuery : IGetAllMovementsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllMovementsQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<ResponseMovementModel>> Execute(bool IncludeDetails)
        {

            if (IncludeDetails)
            {
                var listEntities = await _dataBaseService.MovimientoCab
					.Include(x => x.Detalles)
                    .ToListAsync();
                return _mapper.Map<List<ResponseMovementModel>>(listEntities);
            }
            else
            {

				var listEntities = await _dataBaseService.MovimientoCab
                    .ToListAsync();
				return _mapper.Map<List<ResponseMovementModel>>(listEntities);
			}


        }
    }
}
