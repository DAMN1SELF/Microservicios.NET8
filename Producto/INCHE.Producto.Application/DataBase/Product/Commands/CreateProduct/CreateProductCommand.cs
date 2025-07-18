using AutoMapper;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities;

namespace INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct
{
    public class CreateProductCommand: ICreateProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public CreateProductCommand(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<ResponseProductModel> Execute(CreateProductModel model)
        {
			try
			{
				var entity = _mapper.Map<ProductoEntity>(model);
				entity.FechaRegistro = DateTime.UtcNow; 
                entity.PrecioVenta = model.Cost * ApplicationConstants.MARGEN_PRECIO_VENTA;
          
			await _dataBaseService.Producto.AddAsync(entity);
            await _dataBaseService.SaveAsync();
			var resultModel = _mapper.Map<ResponseProductModel>(entity);
			return resultModel;

			}
			catch (Exception ex)
			{
				throw new ApplicationException(Messages.RecordCreationFailed, ex);

			}
		}
    }
}
