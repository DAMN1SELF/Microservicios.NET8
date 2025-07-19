using INCHE.Producto.Domain.Entities.Compras;
using INCHE.Producto.Domain.Entities.Movimientos;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.User;
using INCHE.Producto.Domain.Entities.Ventas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;




namespace INCHE.Producto.Application.DataBase
{

	public interface IDataBaseService
    {
		#region Users
		DbSet<UserEntity> User { get; set; }
		#endregion

		#region Productos
		DbSet<ProductoEntity> Producto { get; set; }
		#endregion

		#region Compras
		DbSet<CompraCabEntity> CompraCab { get; set; }
		DbSet<CompraDetEntity> CompraDet { get; set; }
		#endregion

		#region Ventas
		DbSet<VentaCabEntity> VentaCab { get; set; }
		DbSet<VentaDetEntity> VentaDet { get; set; }
		#endregion

		#region Movimientos
		DbSet<MovimientoCabEntity> MovimientoCab { get; set; }
		DbSet<MovimientoDetEntity> MovimientoDet { get; set; }
		#endregion
		Task<IDbContextTransaction> BeginTransactionAsync();
		Task<bool> SaveAsync();

	}
}
