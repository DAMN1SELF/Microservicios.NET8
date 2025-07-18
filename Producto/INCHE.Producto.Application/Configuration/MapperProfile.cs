using AutoMapper;
//using INCHE.Producto.Application.DataBase.Producto.Commands.CreateProducto;
//using INCHE.Producto.Application.DataBase.Producto.Commands.UpdateProducto;
//using INCHE.Producto.Application.DataBase.Producto.Queries.GetAllProductos;
//using INCHE.Producto.Application.DataBase.Producto.Queries.GetProductoByDocumentNumber;
//using INCHE.Producto.Application.DataBase.Producto.Queries.GetProductoById;
using INCHE.Producto.Domain.Entities;

namespace INCHE.Producto.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {

            #region Producto
            //CreateMap<ProductoEntity, CreateProductoModel>().ReverseMap();
            //CreateMap<ProductoEntity, UpdateProductoModel>().ReverseMap();
            //CreateMap<ProductoEntity, GetAllProductoModel>().ReverseMap();
            //CreateMap<ProductoEntity, GetProductoByIdModel>().ReverseMap();
            //CreateMap<ProductoEntity, GetProductoByDocumentNumberModel>().ReverseMap();
			#endregion
		}
	}
}
