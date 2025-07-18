
using INCHE.Producto.Domain.Entities.Movimientos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Movimientos
{
	public class MovimientoCabConfiguration 
	{
		public MovimientoCabConfiguration(EntityTypeBuilder<MovimientoCab> builder)
		{
			builder.ToTable("MovimientoCab", "INVENTARIO");

			builder.HasKey(x => x.MovimientoCabId);

			builder.Property(x => x.MovimientoCabId)
				.HasColumnName("Id_MovimientoCab")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.FechaRegistro)
				.HasColumnName("FecRegistro")
				.IsRequired();

			builder.Property(x => x.TipoMovimiento)
				.HasColumnName("Id_TipoMovimiento")
				.IsRequired();

			builder.Property(x => x.DocumentoOrigenId)
				.HasColumnName("Id_DocumentoOrigen")
				.IsRequired();

			builder.HasMany(x => x.Detalles)
				.WithOne(d => d.MovimientoCab)
				.HasForeignKey(d => d.MovimientoCabId);
		}
	}
}
