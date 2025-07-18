
using INCHE.Producto.Domain.Entities.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Ventas
{
	public class VentaDetConfiguration 
	{
		public VentaDetConfiguration(EntityTypeBuilder<VentaDet> builder)
		{
			builder.ToTable("VentaDet", "VENTAS");

			builder.HasKey(x => x.VentaDetId);

			builder.Property(x => x.VentaDetId)
				.HasColumnName("Id_VentaDet")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.VentaCabId)
				.HasColumnName("Id_VentaCab")
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