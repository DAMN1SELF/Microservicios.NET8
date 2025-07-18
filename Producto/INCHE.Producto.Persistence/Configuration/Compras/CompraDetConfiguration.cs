using INCHE.Producto.Domain.Entities.Compras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Compras
{
	public class CompraDetConfiguration
	{
		public CompraDetConfiguration(EntityTypeBuilder<CompraDet> builder)
		{
			builder.ToTable("CompraDet", "COMPRAS");

			builder.HasKey(x => x.CompraDetId);

			builder.Property(x => x.CompraDetId)
				.HasColumnName("Id_CompraDet")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.CompraCabId)
				.HasColumnName("Id_CompraCab")
				.IsRequired();

			builder.Property(x => x.ProductoId)
				.HasColumnName("Id_Producto")
				.IsRequired();

			builder.Property(x => x.Cantidad)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(x => x.Precio)
				.HasColumnType("decimal(18,2)")
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
		}
	}
}
