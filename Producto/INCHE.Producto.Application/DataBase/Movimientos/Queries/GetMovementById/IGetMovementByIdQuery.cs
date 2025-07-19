

using INCHE.Producto.Application.DataBase.GetMovementById;

namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById
{
    public interface IGetMovementByIdQuery
    {
        Task<List<MovementByIdModel>> Execute(int idProducto);
    }
}
