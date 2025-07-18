using FluentValidation;
using INCHE.Ventao.Application.DataBase.Venta.Commands.CreateVenta;
using INCHE.Ventao.Application.DataBase.Venta.Commands.DeleteVenta;
using INCHE.Ventao.Application.DataBase.Venta.Commands.UpdateVenta;
using INCHE.Ventao.Application.DataBase.Venta.Queries.GetAllVentas;
using INCHE.Ventao.Application.DataBase.Venta.Queries.GetVentaById;
using INCHE.Ventao.Application.DataBase.Venta.Queries.GetVentaByName;
using INCHE.Producto.Application.Exceptions;
using INCHE.Producto.Application.Features;
using INCHE.Producto.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace INCHE.Producto.API.Controllers
{

	[Authorize]
	[Route("api/v1/[controller]")]
	[TypeFilter(typeof(ExceptionManager))]
	[ApiController]
	public class VentaController : ControllerBase
	{


		public VentaController()
		{

		}

		/// <summary>
		/// Registrar una nueva venta
		/// </summary>
		[HttpPost("registrar-venta")]
		public async Task<IActionResult> RegisterSale(
			[FromBody] CreateVentaModel model,
			[FromServices] ICreateVentaCommand createVentaCommand,
			[FromServices] IValidator<CreateVentaModel> validator)
		{
			var validation = await validator.ValidateAsync(model);
			if (!validation.IsValid)
				return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));

			var result = await createVentaCommand.Execute(model);
			if (result.Success)
				return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, result.Data, "Venta registrada correctamente"));

			return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, result.Errors));
		}

		/// <summary>
		/// Listar todas las ventas
		/// </summary>
		[HttpGet("listar-venta")]
		public async Task<IActionResult> ListarVenta(
			[FromServices] IGetAllVentaQuery getAllVentaQuery)
		{
			var result = await getAllVentaQuery.Execute();
			return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result, "Ventas obtenidas correctamente"));
		}

		/// <summary>
		/// Obtener una venta por ID
		/// </summary>
		[HttpGet("obtener-venta/{id}")]
		public async Task<IActionResult> ObtenerVenta(
			int id,
			[FromServices] IGetVentaByIdQuery getVentaByIdQuery)
		{
			var result = await getVentaByIdQuery.Execute(id);
			if (result == null)
				return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound, null, "Venta no encontrada"));

			return Ok(ResponseApiService.Response(StatusCodes.Status200OK, result, "Venta obtenida correctamente"));
		}
	}
}
}
