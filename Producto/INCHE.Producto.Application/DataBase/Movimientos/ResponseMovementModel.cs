
namespace INCHE.Producto.Application.DataBase.Inventory
{

	public class ResponseMovementModel
	{
		public int MovimientoCabId { get; set; }
		public DateTime FechaRegistro { get; set; }
		public int TipoMovimiento { get; set; }
		public int DocumentoOrigenId { get; set; }
		public List<ResponseMovementDetModel> Detalles { get; set; }
	}

	public class ResponseMovementDetModel
	{
		public int MovimientoDetId { get; set; }
		public int MovimientoCabId { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
	}
}
