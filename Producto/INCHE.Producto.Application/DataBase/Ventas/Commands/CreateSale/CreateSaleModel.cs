using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale
{
    public class CreateSaleModel
	{
		public DateTime fecha_Registro { get; set; }
		public decimal sub_Total { get; set; }
		public decimal Igv_Total { get; set; }
		public decimal total_Total { get; set; }
		public required List<CreateSaleDetalleModel> Detalles { get; set; }

	}
	public class CreateSaleDetalleModel
	{
		public int codigo_item { get; set; }
		public decimal cantidad_item { get; set; }
		public decimal precio_item { get; set; }
		public decimal subtotal_item { get; set; }
		public decimal igv_item { get; set; }
		public decimal total_item { get; set; }

	}

}
