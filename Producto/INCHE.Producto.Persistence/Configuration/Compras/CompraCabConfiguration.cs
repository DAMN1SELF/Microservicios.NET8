using INCHE.Producto.Domain.Entities.Compras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Compras
{
	public class CompraCabConfiguration 
	{
		public CompraCabConfiguration(EntityTypeBuilder<CompraCab> builder)
		{
			builder.ToTable("CompraCab", "COMPRAS");

			builder.HasKey(x => x.CompraCabId);

			builder.Property(x => x.CompraCabId)
				.HasColumnName("Id_CompraCab")
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
				.WithOne(d => d.CompraCab)
				.HasForeignKey(d => d.CompraCabId);
		}
	}
}
