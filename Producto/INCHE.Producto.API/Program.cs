using INCHE.Producto.Application.DataBase;
using INCHE.Producto.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataBaseService>(options=>
options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

builder.Services.AddScoped<IDataBaseService, DataBaseService>();

var app = builder.Build();

app.MapPost("/createProductoTest", async (IDataBaseService _databaseService) =>
{
	var producto = new INCHE.Producto.Domain.Entities.ProductoEntity
	{
		Nombre = "Laptop Lenovo X",
		NumeroLote = "LT00000001",
		FechaRegistro = DateTime.Now,
		Costo = 1550.75m,
		PrecioVenta = 2100.99m
	};

	await _databaseService.Producto.AddAsync(producto);
	await _databaseService.SaveAsync();

	return Results.Ok("Producto creado OK");
});


app.Run();
