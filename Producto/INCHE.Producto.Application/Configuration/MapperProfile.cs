using AutoMapper;
using INCHE.Producto.Application.DataBase.Product;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Application.DataBase.User.Commands.CreateUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetAllUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserById;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
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
			#endregion



			CreateMap<CreateSaleModel, VentaCabEntity>()
			.ForMember(dest => dest.FechaRegistro, opt => opt.MapFrom(src => src.fecha_Registro))
			.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.sub_Total))
			.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.Igv_Total))
			.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_Total))
			.ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Detalles))
			.ForMember(dest => dest.VentaCabId, opt => opt.Ignore()); 

			CreateMap<CreateVentaDetalleModel, VentaDetEntity>()
				.ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.codigo_item))
				.ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.cantidad_item))
				.ForMember(dest => dest.SubTotal, opt => opt.MapFrom(src => src.subtotal_item))
				.ForMember(dest => dest.Igv, opt => opt.MapFrom(src => src.igv_item))
				.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.total_item))
				.ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.precio_item))
				.ForMember(dest => dest.VentaCabId, opt => opt.Ignore())
				.ForMember(dest => dest.VentaDetId, opt => opt.Ignore());


		}
	}
}
