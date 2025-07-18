using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Domain.Entities.Compras
{
	public class CompraCabEntity
	{
		public int CompraCabId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Igv { get; set; }
		public decimal Total { get; set; }

		public required ICollection<CompraDetEntity> Detalles { get; set; }
	}

	public class CompraDetEntity
	{
		public int CompraDetId { get; set; }
		public int CompraCabId { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Igv { get; set; }
		public decimal Total { get; set; }

		public CompraCabEntity? CompraCab { get; set; }
	}
}
