
namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName
{
    public interface IGetProductByNameQuery
    {
		Task<List<GetProductByNameModel>> Execute(string nombreProducto);
    }
}
