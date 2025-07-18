namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales
{
    public interface IGetAllSaleQuery
    {
        Task<List<GetAllSaleModel>> Execute();
    }
}
