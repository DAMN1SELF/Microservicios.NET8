using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Domain.Entities.Compras;
using INCHE.Producto.Domain.Entities.Movimientos;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.User;
using INCHE.Producto.Domain.Entities.Ventas;
using INCHE.Producto.Persistence.Configuration.Producto;
using INCHE.Producto.Persistence.Configuration.Usuario;
using INCHE.Producto.Persistence.Configuration.Compras;
using INCHE.Producto.Persistence.Configuration.Ventas;
using INCHE.Producto.Persistence.Configuration.Movimientos;

using Microsoft.EntityFrameworkCore;

namespace INCHE.Producto.Persistence.DataBase
{
    public class DataBaseService: DbContext ,IDataBaseService
    {
        public DataBaseService(DbContextOptions options): base(options)
        {
            
        }

		public DbSet<UserEntity> User { get; set; }
		public DbSet<ProductoEntity> Producto { get; set; }


		#region Compras
		public DbSet<CompraCabEntity> CompraCab { get; set; }
		public DbSet<CompraDetEntity> CompraDet { get; set; }
		#endregion


		#region Compras
		public DbSet<VentaCabEntity> VentaCab { get; set; }
		public DbSet<VentaDetEntity> VentaDet { get; set; }
		#endregion


		#region Movimientos
		public DbSet<MovimientoCabEntity> MovimientoCab { get; set; }
		public DbSet<MovimientoDetEntity> MovimientoDet { get; set; }
		#endregion


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
			new UserConfiguration(modelBuilder.Entity<UserEntity>());
			new ProductoConfiguration(modelBuilder.Entity<ProductoEntity>());
			new CompraCabConfiguration(modelBuilder.Entity<CompraCabEntity>());
			new CompraDetConfiguration(modelBuilder.Entity<CompraDetEntity>());
			new VentaCabConfiguration(modelBuilder.Entity<VentaCabEntity>());
			new VentaDetConfiguration(modelBuilder.Entity<VentaDetEntity>());
			new MovimientoCabConfiguration(modelBuilder.Entity<MovimientoCabEntity>());
			new MovimientoDetConfiguration(modelBuilder.Entity<MovimientoDetEntity>());
		}

    }
}
