using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Domain.Entities.Ventas
{
	public class VentaCabEntity
	{
		public int VentaCabId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Igv { get; set; }
		public decimal Total { get; set; }

		public required ICollection<VentaDetEntity> Detalles { get; set; }
	}

	public class VentaDetEntity
	{
		public int VentaDetId { get; set; }
		public int VentaCabId { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Igv { get; set; }
		public decimal Total { get; set; }

		public VentaCabEntity? VentaCab { get; set; }
	}
}
