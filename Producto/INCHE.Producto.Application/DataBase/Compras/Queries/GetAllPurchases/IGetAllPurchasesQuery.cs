namespace INCHE.Producto.Application.DataBase.Purchase.Queries.GetAllPurchases
{
    public interface IGetAllPurchasesQuery
	{
        Task<List<ResponsePurchaseModel>> Execute(bool IncludeDetails);
    }
}
