namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales
{
    public interface IGetAllSalesQuery
	{
        Task<List<ResponseSaleModel>> Execute(bool IncludeDetails);
    }
}
