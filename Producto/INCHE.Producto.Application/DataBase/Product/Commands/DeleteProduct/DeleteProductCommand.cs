
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand: IDeleteProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public DeleteProductCommand(IDataBaseService dataBaseService
            )
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(int ProductoId)
        {
            var entity = await _dataBaseService.Producto
                .FirstOrDefaultAsync(x => x.Id == ProductoId);

            if (entity == null)
                return false;

            _dataBaseService.Producto.Remove(entity);
            return await _dataBaseService.SaveAsync();
        }
    }
}
