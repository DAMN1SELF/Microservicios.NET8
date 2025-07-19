
using AutoMapper;
using FluentValidation;
using INCHE.Producto.Application.Configuration;
using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement;
using INCHE.Producto.Application.DataBase.Inventory.Queries.GetAllMovements;
using INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.DeleteProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.PatchProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProductsStock;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase;
using INCHE.Producto.Application.DataBase.Purchase.Queries.GetAllPurchases;
using INCHE.Producto.Application.DataBase.Purchase.Queries.GetPurchaseById;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;
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

			services.AddTransient<IAuthUserCommand, AuthUserCommand>();
			services.AddScoped<IValidator<AuthUserModel>, AuthUserValidator>();
			#endregion

			#region Producto

			services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
			services.AddTransient<IPatchProductCommand, PatchProductCommand>();
			services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();

            services.AddTransient<IGetAllProductQuery, GetAllProductQuery>();
            services.AddTransient<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddTransient<IGetProductByNameQuery, GetProductByNameQuery>();
            services.AddTransient<IGetAllProductStockQuery, GetAllProductStockQuery>();

			services.AddScoped<IValidator<CreateProductModel>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductModel>, UpdateProductValidator>();

			#endregion

			#region Compras
			services.AddScoped<ICreatePurchaseCommand, CreatePurchaseCommand>();
			services.AddScoped<IGetPurchaseByIdQuery, GetPurchaseByIdQuery>();
			services.AddScoped<IGetAllPurchasesQuery, GetAllPurchasesQuery>();
			#endregion


			#region Ventas
			services.AddScoped<ICreateSaleCommand, CreateSaleCommand>();
			services.AddScoped<IGetSaleByIdQuery, GetSaleByIdQuery>();
			services.AddScoped<IGetAllSalesQuery, GetAllSalesQuery>();
			#endregion

			#region Movimientos
			services.AddScoped<ICreateMovementCommand, CreateMovementCommand>();
			services.AddScoped<IGetMovementByIdQuery, GetMovementByIdQuery>();
			services.AddScoped<IGetAllMovementsQuery, GetAllMovementsQuery>();
			#endregion


			return services;
        }
    }
}
