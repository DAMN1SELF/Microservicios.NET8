using AutoMapper;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Domain.Entities;

namespace INCHE.Producto.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

            #region Producto
            CreateMap<ProductoEntity, CreateProductModel>().ReverseMap();
            CreateMap<ProductoEntity, UpdateProductModel>().ReverseMap();
            CreateMap<ProductoEntity, GetAllProductModel>().ReverseMap();
            CreateMap<ProductoEntity, GetProductByIdModel>().ReverseMap();
            CreateMap<ProductoEntity, GetProductByNameModel>().ReverseMap();
			#endregion
		}
	}
}
