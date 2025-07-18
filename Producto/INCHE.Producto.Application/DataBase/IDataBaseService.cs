using INCHE.Producto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<ProductoEntity> Producto{ get; set; }
        Task<bool> SaveAsync();
    }
}
