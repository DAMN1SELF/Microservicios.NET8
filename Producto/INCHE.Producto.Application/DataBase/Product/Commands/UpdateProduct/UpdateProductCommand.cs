
using AutoMapper;
using INCHE.Producto.Domain.Entities;

namespace INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand: IUpdateProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public UpdateProductCommand(IDataBaseService dataBaseService,
            IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateProductModel> Execute(UpdateProductModel model)
        {
            var entity = _mapper.Map<ProductoEntity>(model);
            _dataBaseService.Producto.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
