using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Commands.PatchProduct
{
    public class PatchProductModel
	{
		public int IdProducto { get; set; }
		public string NombreProducto { get; set; } 
		public decimal PrecioProducto { get; set; }

	}
	public class PatchProductResultModel
	{
		public int IdProducto { get; set; }
		public string NombreProducto { get; set; }
		public DateTime FechaActualizacion { get; set; }
		public decimal PrecioProducto { get; set; }
		public decimal PrecioVenta { get; set; }

	}
}
