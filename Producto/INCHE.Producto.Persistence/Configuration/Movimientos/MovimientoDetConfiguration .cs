
using INCHE.Producto.Domain.Entities.Movimientos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Movimientos
{
	public class MovimientoDetConfiguration 
	{
		public MovimientoDetConfiguration(EntityTypeBuilder<MovimientoDetEntity> builder)
		{
			builder.ToTable("MovimientoDet", "INVENTARIO");

			builder.HasKey(x => x.MovimientoDetId);

			builder.Property(x => x.MovimientoDetId)
				.HasColumnName("Id_MovimientoDet")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.MovimientoCabId)
				.HasColumnName("Id_MovimientoCab")
				.IsRequired();

			builder.Property(x => x.ProductoId)
				.HasColumnName("Id_Producto")
				.IsRequired();

			builder.Property(x => x.Cantidad)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
		}
	}
}