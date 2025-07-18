
using AutoMapper;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName
{
	public class GetProductByNameQuery : IGetProductByNameQuery
	{
		private readonly IDataBaseService _dataBaseService;
		private readonly IMapper _mapper;
		public GetProductByNameQuery(IDataBaseService dataBaseService,
			IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_mapper = mapper;
		}
	
		public async Task<List<GetProductByNameModel>> Execute(string nombreProducto)
		{
			var listEntities = await _dataBaseService.Producto
							.Where(x => x.Nombre.ToLower().Contains(nombreProducto.ToLower()))
							.Take(7)
							.ToListAsync();

			return _mapper.Map<List<GetProductByNameModel>>(listEntities);
		}
	}
}
