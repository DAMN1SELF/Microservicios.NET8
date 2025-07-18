using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using INCHE.Producto.Api;
using DANIEL.Producto.Common;
using INCHE.Producto.Application;
using INCHE.Producto.External;
using INCHE.Producto.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddWebApi()
	.AddCommon()
	.AddApplication()
	.AddExternal(builder.Configuration)
	.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.MapControllers();
app.Run();
