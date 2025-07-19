using AutoMapper;
using INCHE.Producto.Application.DataBase.Inventory;
using INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement;
using INCHE.Producto.Application.DataBase.Product;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.PatchProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.DataBase.Purchase;
using INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase;
using INCHE.Producto.Application.DataBase.Sale;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Application.DataBase.User.Commands.CreateUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetAllUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserById;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using INCHE.Producto.Domain.Entities.Compras;
using INCHE.Producto.Domain.Entities.Movimientos;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.User;
using INCHE.Producto.Domain.Entities.Ventas;

namespace INCHE.Producto.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

			#region User
			CreateMap<UserEntity, CreateUserModel>().ReverseMap();
			CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
			CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
			CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
			CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
			#endregion

			#region Producto
			CreateMap<ProductoEntity, CreateProductModel>().ReverseMap()
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.FullName))
				.ForMember(dest => dest.NumeroLote, opt => opt.MapFrom(src => src.BatchNumber))
				.ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Cost))
				.ForMember(dest => dest.PrecioVenta, opt => opt.Ignore()) 
				.ForMember(dest => dest.FechaRegistro, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			CreateMap<ProductoEntity, UpdateProductModel>().ReverseMap()
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.FullName))
				.ForMember(dest => dest.NumeroLote, opt => opt.MapFrom(src => src.BatchNumber))
				.ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Cost))
				.ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.SalePrice))
				.ForMember(dest => dest.FechaRegistro, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			CreateMap<ProductoEntity, GetAllProductModel>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Nombre))
				.ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.NumeroLote))
				.ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Costo))
				.ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.PrecioVenta));


			CreateMap<ProductoEntity, GetProductByIdModel>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Nombre))
				.ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.NumeroLote))
				.ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Costo))
				.ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.PrecioVenta));

			CreateMap<ProductoEntity, GetProductByNameModel>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Nombre))
				.ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.NumeroLote))
				.ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Costo))
				.ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.PrecioVenta));

			CreateMap<ProductoEntity, ResponseProductModel>()
			   .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
			   .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Nombre))
			   .ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.NumeroLote))
			   .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.FechaRegistro))
			   .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Costo))
			   .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.PrecioVenta));



			// PatchProductModel -> ProductoEntity
			CreateMap<PatchProductModel, ProductoEntity>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProducto))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreProducto))
				.ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.PrecioProducto));

			// ProductoEntity -> PatchProductResultModel
			CreateMap<ProductoEntity, PatchProductResultModel>()
				.ForMember(dest => dest.IdProducto, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Nombre))
				.ForMember(dest => dest.FechaActualizacion, opt => opt.MapFrom(src => DateTime.Now))
				.ForMember(dest => dest.PrecioProducto, opt => opt.MapFrom(src => src.Costo))
				.ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.PrecioVenta));

			#endregion

			#region Venta


			CreateMap<CreateSaleModel, VentaCabEntity>()
				.ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.fecha_Registro))
				.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.sub_Total))
				.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.Igv_Total))
				.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
				.ForMember(dest => dest.VentaCabId, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(dest => dest.fecha_Registro, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.sub_Total, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.Igv_Total, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_Total, opt => opt.MapFrom(src => src.Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<CreateSaleDetalleModel, VentaDetEntity>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.codigo_item))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.cantidad_item))
				.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.subtotal_item))
				.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.igv_item))
				.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_item))
				.ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.precio_item))
				.ForMember(dest => dest.VentaCabId, opt => opt.Ignore())
				.ForMember(dest => dest.VentaDetId, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(dest => dest.codigo_item, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.cantidad_item, opt => opt.MapFrom(src => src.Cantidad))
				.ForMember(dest => dest.subtotal_item, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.igv_item, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_item, opt => opt.MapFrom(src => src.Total))
				.ForMember(dest => dest.precio_item, opt => opt.MapFrom(src => src.Precio));

			CreateMap<VentaCabEntity, ResponseSaleModel>()
				.ForMember(dest => dest.codigo_venta, opt => opt.MapFrom(src => src.VentaCabId))
				.ForMember(dest => dest.fecha_Registro, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.sub_Total, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.Igv_Total, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_Total, opt => opt.MapFrom(src => src.Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<VentaDetEntity, ResponseSaleDetModel>()
				.ForMember(dest => dest.codigo_venta, opt => opt.MapFrom(src => src.VentaCabId))
				.ForMember(dest => dest.codigo_detalle, opt => opt.MapFrom(src => src.VentaDetId))
				.ForMember(dest => dest.codigo_item, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.cantidad_item, opt => opt.MapFrom(src => src.Cantidad))
				.ForMember(dest => dest.precio_item, opt => opt.MapFrom(src => src.Precio))
				.ForMember(dest => dest.subtotal_item, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.igv_item, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_item, opt => opt.MapFrom(src => src.Total));

			CreateMap<VentaCabEntity, CreateMovementModel>()
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => 2)) // 2 = Salida
				.ForMember(dest => dest.DocumentoOrigenId, opt => opt.MapFrom(src => src.VentaCabId))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<VentaDetEntity, CreateMovementDetModel>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));

			#endregion

			#region Compras

			CreateMap<CreatePurchaseModel, CompraCabEntity>()
				.ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.fecha_Registro))
				.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.sub_Total))
				.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.Igv_Total))
				.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
				.ForMember(dest => dest.CompraCabId, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(dest => dest.fecha_Registro, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.sub_Total, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.Igv_Total, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_Total, opt => opt.MapFrom(src => src.Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<CreatePurchaseDetailModel, CompraDetEntity>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.codigo_item))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.cantidad_item))
				.ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.precio_item))
				.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.subtotal_item))
				.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.igv_item))
				.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_item))
				.ForMember(dest => dest.CompraDetId, opt => opt.Ignore())
				.ForMember(dest => dest.CompraCabId, opt => opt.Ignore())
				.ReverseMap()
				.ForMember(dest => dest.codigo_item, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.cantidad_item, opt => opt.MapFrom(src => src.Cantidad))
				.ForMember(dest => dest.precio_item, opt => opt.MapFrom(src => src.Precio))
				.ForMember(dest => dest.subtotal_item, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.igv_item, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_item, opt => opt.MapFrom(src => src.Total));

			CreateMap<CompraCabEntity, ResponsePurchaseModel>()
				.ForMember(dest => dest.codigo_compra, opt => opt.MapFrom(src => src.CompraCabId))
				.ForMember(dest => dest.fecha_Registro, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.sub_Total, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.Igv_Total, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_Total, opt => opt.MapFrom(src => src.Total))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));


			CreateMap<CompraDetEntity, ResponsePurchaseDetModel>()
				.ForMember(dest => dest.codigo_compra, opt => opt.MapFrom(src => src.CompraCabId))
				.ForMember(dest => dest.codigo_detalle, opt => opt.MapFrom(src => src.CompraDetId))
				.ForMember(dest => dest.codigo_item, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.cantidad_item, opt => opt.MapFrom(src => src.Cantidad))
				.ForMember(dest => dest.precio_item, opt => opt.MapFrom(src => src.Precio))
				.ForMember(dest => dest.subtotal_item, opt => opt.MapFrom(src => src.SubTotal))
				.ForMember(dest => dest.igv_item, opt => opt.MapFrom(src => src.Igv))
				.ForMember(dest => dest.total_item, opt => opt.MapFrom(src => src.Total));


			CreateMap<CompraCabEntity, CreateMovementModel>()
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => 1))
				.ForMember(dest => dest.DocumentoOrigenId, opt => opt.MapFrom(src => src.CompraCabId))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<CompraDetEntity, CreateMovementDetModel>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));

			CreateMap<CreatePurchaseDetailModel, PatchProductModel>()
				.ForMember(dest => dest.IdProducto, opt => opt.MapFrom(src => src.codigo_item))
				.ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.nombre_item))
				.ForMember(dest => dest.PrecioProducto, opt => opt.MapFrom(src => src.precio_item));

		#endregion

		#region Movimientos

		CreateMap<MovimientoCabEntity, ResponseMovementModel>()
				.ForMember(dest => dest.MovimientoCabId, opt => opt.MapFrom(src => src.MovimientoCabId))
				.ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.FechaRegistro))
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => src.TipoMovimiento))
				.ForMember(dest => dest.DocumentoOrigenId, opt => opt.MapFrom(src => src.DocumentoOrigenId))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles));

			CreateMap<MovimientoDetEntity, ResponseMovementDetModel>()
				.ForMember(dest => dest.MovimientoDetId, opt => opt.MapFrom(src => src.MovimientoDetId))
				.ForMember(dest => dest.MovimientoCabId, opt => opt.MapFrom(src => src.MovimientoCabId))
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));

			CreateMap<CreateMovementModel, MovimientoCabEntity>()
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => src.TipoMovimiento))
				.ForMember(dest => dest.DocumentoOrigenId, opt => opt.MapFrom(src => src.DocumentoOrigenId))
				.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
				.ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => DateTime.UtcNow)) 
				.ForMember(dest => dest.MovimientoCabId, opt => opt.Ignore());

			CreateMap<CreateMovementDetModel, MovimientoDetEntity>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
				.ForMember(dest => dest.MovimientoDetId, opt => opt.Ignore())
				.ForMember(dest => dest.MovimientoCabId, opt => opt.Ignore())
				.ForMember(dest => dest.MovimientoCab, opt => opt.Ignore());

			#endregion


		}
	}
}
