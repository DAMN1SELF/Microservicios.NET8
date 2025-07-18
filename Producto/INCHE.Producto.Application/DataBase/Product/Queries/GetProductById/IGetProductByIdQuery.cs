

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductById
{
    public interface IGetProductByIdQuery
    {
        Task<GetProductByIdModel> Execute(int ProductId);
    }
}
