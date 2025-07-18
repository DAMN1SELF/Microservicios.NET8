
using AutoMapper;
using FluentValidation;
using INCHE.Producto.Application.Configuration;
using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.DeleteProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById;
using INCHE.Producto.Application.DataBase.User.Commands.CreateUser;
using INCHE.Producto.Application.DataBase.User.Commands.DeleteUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUserPassword;
using INCHE.Producto.Application.DataBase.User.Queries.GetAllUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserById;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using INCHE.Producto.Application.Validators.Product;
using INCHE.Producto.Application.Validators.User;
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

			#region User
			services.AddTransient<ICreateUserCommand, CreateUserCommand>();
			services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
			services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
			services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
			services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
			services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
			services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();

			services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
			services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
			services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
			services.AddScoped<IValidator<(string, string)>, GetUserByUserNameAndPasswordValidator>();

			#endregion

			#region Producto
			services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<IGetAllProductQuery, GetAllProductQuery>();
            services.AddTransient<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddTransient<IGetProductByNameQuery, GetProductByNameQuery>();

            services.AddScoped<IValidator<CreateProductModel>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductModel>, UpdateProductValidator>();

			#endregion


			services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
			services.AddScoped<IGetSaleByIdQuery, GetSaleByIdQuery>();
			services.AddScoped<IGetAllSalesQuery, GetAllSalesQuery>();


			return services;
        }
    }
}
