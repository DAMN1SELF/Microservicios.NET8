

namespace INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase
{
    public class CreatePurchaseModel
    {
		public DateTime fecha_Registro { get; set; }
		public decimal sub_Total { get; set; }
		public decimal Igv_Total { get; set; }
		public decimal total_Total { get; set; }
		public required List<CreatePurchaseDetailModel> Detalles { get; set; }

	}
	public class CreatePurchaseDetailModel
	{
		public int codigo_item { get; set; }
		public string nombre_item { get; set; }
		public decimal cantidad_item { get; set; }
		public decimal precio_item { get; set; }
		public decimal subtotal_item { get; set; }
		public decimal igv_item { get; set; }
		public decimal total_item { get; set; }

	}




}
