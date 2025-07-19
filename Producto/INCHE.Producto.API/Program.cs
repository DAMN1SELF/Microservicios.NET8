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


builder.Services.AddHttpClient("API_Movimiento", c =>
{
	c.BaseAddress = new Uri("http://localhost:5188");
});

builder.Services.AddHttpClient("API_Producto", client =>
{
	client.BaseAddress = new Uri("http://localhost:5188/");

});


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend",
		policy => policy
			.WithOrigins(
				"http://localhost:4200"   // Angular
			)
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials() // si necesitas enviar cookies/jwt por headers
	);
});



var app = builder.Build();


app.UseCors("AllowFrontend");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
	options.RoutePrefix = string.Empty;
});



app.MapControllers();
app.Run();
