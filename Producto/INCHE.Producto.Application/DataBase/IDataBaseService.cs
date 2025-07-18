using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase
{
    public interface IDataBaseService
    {


		DbSet<UserEntity> User { get; set; }
		DbSet<ProductoEntity> Producto{ get; set; }
        Task<bool> SaveAsync();
    }
}
