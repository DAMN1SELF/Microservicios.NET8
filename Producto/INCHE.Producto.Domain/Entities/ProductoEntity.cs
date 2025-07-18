using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Domain.Entities
{
	public  class ProductoEntity
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string NumeroLote { get; set; }
		public DateTime FechaRegistro { get; set; }
		public decimal Costo { get; set; }
		public decimal PrecioVenta { get; set; }
	}
}
