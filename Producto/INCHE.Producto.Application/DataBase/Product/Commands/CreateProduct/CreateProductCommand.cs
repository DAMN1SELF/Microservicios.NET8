using AutoMapper;
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

        public async Task<CreateProductModel> Execute(CreateProductModel model)
        {
            var entity = _mapper.Map<ProductoEntity>(model);
            await _dataBaseService.Producto.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
