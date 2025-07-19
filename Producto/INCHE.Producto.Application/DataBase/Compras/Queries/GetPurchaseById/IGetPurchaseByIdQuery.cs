

namespace INCHE.Producto.Application.DataBase.Purchase.Queries.GetPurchaseById
{
    public interface IGetPurchaseByIdQuery
    {
        Task<ResponsePurchaseModel> Execute(int PurchaseId, bool IncludeDetails);
    }
}
