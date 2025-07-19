using AutoMapper;
using INCHE.Producto.Application.DataBase.GetMovementById;
using INCHE.Producto.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById
{
    public class GetMovementByIdQuery: IGetMovementByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetMovementByIdQuery(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<MovementByIdModel>> Execute(int idProducto)
        {

		var movimientos = await _dataBaseService.MovimientoDet
			.Where(md => md.ProductoId == idProducto)
			.Include(md => md.MovimientoCab)
			.Select(md => new MovementByIdModel
			{
				tipoMovimiento =md.MovimientoCab.TipoMovimiento,
				fechaRegistro = md.MovimientoCab.FechaRegistro,
				cantidad = (int)md.Cantidad 
			})
			.OrderBy(m => m.fechaRegistro)
			.ToListAsync();

			return movimientos;
		}

	}
}
