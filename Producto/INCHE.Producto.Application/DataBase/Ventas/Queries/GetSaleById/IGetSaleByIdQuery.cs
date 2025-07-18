

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById
{
    public interface IGetSaleByIdQuery
    {
        Task<GetSaleByIdModel> Execute(int SaleId);
    }
}
