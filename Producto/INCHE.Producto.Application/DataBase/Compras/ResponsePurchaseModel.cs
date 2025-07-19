
namespace INCHE.Producto.Application.DataBase.Purchase
{

	public class ResponsePurchaseModel
	{
		public int codigo_compra { get; set; }
		public DateTime fecha_Registro { get; set; }
		public decimal sub_Total { get; set; }
		public decimal Igv_Total { get; set; }
		public decimal total_Total { get; set; }
		public required List<ResponsePurchaseDetModel> Detalles { get; set; }

	}
	public class ResponsePurchaseDetModel
	{
		public int codigo_compra { get; set; }
		public int codigo_detalle { get; set; }
		public int codigo_item { get; set; }
		public decimal cantidad_item { get; set; }
		public decimal precio_item { get; set; }
		public decimal subtotal_item { get; set; }
		public decimal igv_item { get; set; }
		public decimal total_item { get; set; }

	}
}
