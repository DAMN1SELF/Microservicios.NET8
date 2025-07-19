using FluentValidation;
using INCHE.Producto.Application.DataBase.Inventory.Commands.CreateMovement;
using INCHE.Producto.Application.DataBase.Inventory.Queries.GetAllMovements;
using INCHE.Producto.Application.DataBase.Inventory.Queries.GetMovementById;
using INCHE.Producto.Application.Exceptions;
using INCHE.Producto.Application.Features;
using INCHE.Producto.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace INCHE.Producto.API.Controllers
{


	[Route("api/v1/[controller]")]
	[TypeFilter(typeof(ExceptionManager))]
	[ApiController]
	public class MovimientoController : ControllerBase
	{


		public MovimientoController()
		{

		}

		/// <summary>
		/// Registrar una nueva movimiento
		/// </summary>
		/// <returns></returns>
		[HttpPost("registrar-movimiento")]
		public async Task<IActionResult> RegisterMovement(
			[FromBody] CreateMovementModel model,
			[FromServices] ICreateMovementCommand createmovimientoCommand
			)
		{

			var data = await createmovimientoCommand.Execute(model);
			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, Messages.RecordCreated));

		}

		/// <summary>
		/// Listar todas las movimientos registradas
		/// </summary>
		/// <param name="getAllMovementsQuery">CQRS que se encarga de listar las movimientos</param>
		/// <returns></returns>
		[HttpGet("listar-movimientos")]
		public async Task<IActionResult> ListMovements(
		[FromServices] IGetAllMovementsQuery getAllMovementsQuery)
		{
			var data = await getAllMovementsQuery.Execute(IncludeDetails:false);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		/// <summary>
		/// Listar todas las movimientos registradas
		/// </summary>
		/// <param name="getAllMovementsQuery">CQRS que se encarga de listar las movimientos</param>
		/// <returns></returns>
		[HttpGet("listar-movimientos-detalladas")]
		public async Task<IActionResult> ListMovements2(
		[FromServices] IGetAllMovementsQuery getAllMovementsQuery)
		{
			var data = await getAllMovementsQuery.Execute(IncludeDetails: true);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}



		/// <summary>
		///	 Recuperar una movimiento por su ID Producto
		/// </summary>
		/// <returns></returns>
		[HttpGet("buscar-movimiento-detallado/{IdProducto}")]
		public async Task<IActionResult> ListMovementbyId(
		int IdProducto,
		[FromServices] IGetMovementByIdQuery getMovement)
		{
			var data = await getMovement.Execute(IdProducto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		
	}

}
