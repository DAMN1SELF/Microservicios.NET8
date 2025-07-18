using AutoMapper;
using INCHE.Producto.Application.DataBase.Product;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.DataBase.User.Commands.CreateUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetAllUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserById;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using INCHE.Producto.Domain.Entities.Producto;
using INCHE.Producto.Domain.Entities.User;

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
		}
	}
}
