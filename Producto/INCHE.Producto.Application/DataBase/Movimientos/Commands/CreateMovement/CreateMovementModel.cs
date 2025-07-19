

namespace INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement
{
	public class CreateMovementModel
	{
		public int TipoMovimiento { get; set; }  
		public int DocumentoOrigenId { get; set; }
		public required List<CreateMovementDetModel> Detalles { get; set; }
	}

	public class CreateMovementDetModel
	{
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
	}

}
