

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById
{
    public interface IGetSaleByIdQuery
	{
        Task<ResponseSaleModel> Execute(int SaleId, bool IncludeDetails);
    }
}
