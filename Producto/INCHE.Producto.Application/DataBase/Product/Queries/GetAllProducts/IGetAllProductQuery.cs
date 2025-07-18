namespace INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts
{
    public interface IGetAllProductQuery
    {
        Task<List<GetAllProductModel>> Execute();
    }
}
