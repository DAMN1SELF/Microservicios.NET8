namespace INCHE.Producto.Application.DataBase.Product.Queries.GetAllProductsStock
{
    public interface IGetAllProductStockQuery
    {
        Task<List<GetAllProductStockModel>> Execute();
    }
}
