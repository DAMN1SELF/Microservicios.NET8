
namespace INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName
{
    public class GetProductByNameModel
    {
		public int ProductId { get; set; }
		public string FullName { get; set; }
		public string BatchNumber { get; set; }
		public DateTime RegistrationDate { get; set; }
		public decimal Cost { get; set; }
		public decimal SalePrice { get; set; }

	}
}
