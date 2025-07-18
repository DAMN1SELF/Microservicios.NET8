
namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName
{
    public interface IGetProductByNameQuery
    {
        Task<GetProductByNameModel> Execute(string documentNumber);
    }
}
