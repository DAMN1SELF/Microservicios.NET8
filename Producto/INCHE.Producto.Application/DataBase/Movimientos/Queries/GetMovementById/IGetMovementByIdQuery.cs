

namespace INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById
{
    public interface IGetMovementByIdQuery
    {
        Task<ResponseMovementModel> Execute(int PurchaseId, bool IncludeDetails);
    }
}
