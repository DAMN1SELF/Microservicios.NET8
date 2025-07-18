
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace INCHE.Producto.Persistence.Configuration.Ventas
{

	public class VentaCabConfiguration 
	{
		public VentaCabConfiguration(EntityTypeBuilder<VentaCab> builder)
		{
			builder.ToTable("VentaCab", "VENTAS");

			builder.HasKey(x => x.VentaCabId);

			builder.Property(x => x.VentaCabId)
				.HasColumnName("Id_VentaCab")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.FechaRegistro)
				.HasColumnName("FecRegistro")
				.IsRequired();

			builder.Property(x => x.SubTotal)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(x => x.Igv)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(x => x.Total)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.HasMany(x => x.Detalles)
				.WithOne(d => d.VentaCab)
				.HasForeignKey(d => d.VentaCabId);
		}
	}
}
