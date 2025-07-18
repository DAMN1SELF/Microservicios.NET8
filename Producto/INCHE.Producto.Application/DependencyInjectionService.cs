//using AutoMapper;
//using FluentValidation;
using AutoMapper;
using INCHE.Producto.Application.Configuration;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.DeleteProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using Microsoft.Extensions.DependencyInjection;

namespace INCHE.Producto.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

     

            #region Producto
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<IGetAllProductQuery, GetAllProductQuery>();
            services.AddTransient<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddTransient<IGetProductByNameQuery, GetProductByNameQuery>();

            #endregion



            return services;
        }
    }
}
