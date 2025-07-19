


namespace INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement
{
    public interface ICreateMovementCommand
    {
        Task<ResponseMovementModel> Execute(CreateMovementModel model);
    }
}
