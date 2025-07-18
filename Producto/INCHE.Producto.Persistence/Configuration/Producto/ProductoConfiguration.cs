using INCHE.Producto.Domain.Entities.Producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INCHE.Producto.Persistence.Configuration.Producto
{

		public class ProductoConfiguration 
		{
			public  ProductoConfiguration(EntityTypeBuilder<ProductoEntity> entityBuilder)
			{

			entityBuilder.ToTable("Productos");

			entityBuilder.HasKey(x => x.Id);
			entityBuilder.Property(x => x.Id)
					.HasColumnName("Id_producto")
					.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.Nombre)
					.HasColumnName("Nombre_producto")
					.IsRequired()
					.HasMaxLength(100);

			entityBuilder.Property(x => x.NumeroLote)
					.HasColumnName("NroLote")
					.HasMaxLength(50)
					.IsRequired(false);

			entityBuilder.Property(x => x.FechaRegistro)
					.HasColumnName("Fec_registro")
					.IsRequired();

			entityBuilder.Property(x => x.Costo)
					.HasColumnName("Costo")
					.HasColumnType("decimal(18,2)")
					.IsRequired();

			entityBuilder.Property(x => x.PrecioVenta)
					.HasColumnName("PrecioVenta")
					.HasColumnType("decimal(18,2)")
					.IsRequired();
			}
		}
}	
