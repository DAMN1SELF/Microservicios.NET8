using INCHE.Producto.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
			entityBuilder.ToTable("Usuarios");

			entityBuilder.HasKey(x => x.UserId);
			entityBuilder.Property(x => x.UserId)
				.HasColumnName("Id_Usuario")
				.ValueGeneratedOnAdd();

			entityBuilder.Property(x => x.FirstName)
				.HasColumnName("Nombres")
				.IsRequired()
				.HasMaxLength(100);

			entityBuilder.Property(x => x.LastName)
				.HasColumnName("Apellidos")
				.IsRequired()
				.HasMaxLength(100);

			entityBuilder.Property(x => x.UserName)
				.HasColumnName("Usuario")
				.IsRequired()
				.HasMaxLength(30);

			entityBuilder.Property(x => x.Password)
				.HasColumnName("Clave")
				.IsRequired()
				.HasMaxLength(30);
		}

	}
    
}
