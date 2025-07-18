
using AutoMapper;
using INCHE.Producto.Common.Constants;
using INCHE.Producto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ResponseProductModel> Execute(int productoId, UpdateProductModel model)
        {

			var entity = await _dataBaseService.Producto.FindAsync(productoId);

			if (entity == null) throw new Exception(Messages.RecordNotFound);
			
            _mapper.Map(model, entity);
			    entity.FechaRegistro = DateTime.UtcNow;
                entity.Id = productoId;
			_dataBaseService.Producto.Update(entity);
            await _dataBaseService.SaveAsync();

			var resultModel = _mapper.Map<ResponseProductModel>(entity);
			return resultModel;
		}
    }
}
