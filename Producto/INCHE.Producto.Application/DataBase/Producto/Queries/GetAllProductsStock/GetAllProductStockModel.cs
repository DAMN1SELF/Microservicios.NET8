using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Queries.GetAllProductsStock
{
    public class GetAllProductStockModel
    {
		public int Id_producto { get; set; }
		public string nombre_producto { get; set; }
		public decimal stock_actual { get; set; }
		public decimal costo { get; set; }
		public decimal precio_venta{ get; set; }
	}
}
