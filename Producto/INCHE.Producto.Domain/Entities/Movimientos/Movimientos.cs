using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Domain.Entities.Movimientos
{
	public class MovimientoCabEntity
	{
		public int MovimientoCabId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public int TipoMovimiento { get; set; } // 1: Entrada, 2: Salida
		public int DocumentoOrigenId { get; set; }

		public required ICollection<MovimientoDetEntity> Detalles { get; set; }
	}

	public class MovimientoDetEntity
	{
		public int MovimientoDetId { get; set; }
		public int MovimientoCabId { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }

		public MovimientoCabEntity? MovimientoCab { get; set; }
	}
}
