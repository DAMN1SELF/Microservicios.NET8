using Microsoft.EntityFrameworkCore;
using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Domain.Entities;
using INCHE.Persistence.Configuration;

namespace INCHE.Producto.Persistence.DataBase
{
    public class DataBaseService: DbContext ,IDataBaseService
    {
        public DataBaseService(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<ProductoEntity> Producto { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new ProductoConfiguration(modelBuilder.Entity<ProductoEntity>());
        }

    }
}
