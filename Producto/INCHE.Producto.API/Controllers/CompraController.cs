using FluentValidation;

using INCHE.Producto.Application.DataBase.Purchase.Commands.CreatePurchase;
using INCHE.Producto.Application.DataBase.Purchase.Queries.GetAllPurchases;
using INCHE.Producto.Application.DataBase.Purchase.Queries.GetPurchaseById;
using INCHE.Producto.Application.Exceptions;
using INCHE.Producto.Application.Features;
using INCHE.Producto.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace INCHE.Producto.API.Controllers
{

	[Authorize]
	[Route("api/v1/[controller]")]
	[TypeFilter(typeof(ExceptionManager))]
	[ApiController]
	public class CompraController : ControllerBase
	{


		public CompraController()
		{

		}

		/// <summary>
		/// Registrar una nueva compra
		/// </summary>
		/// <returns></returns>
		[HttpPost("registrar-compra")]
		public async Task<IActionResult> RegisterPurchase(
			[FromBody] CreatePurchaseModel model,
			[FromServices] ICreatePurchaseCommand createCompraCommand
			)
		{

			var data = await createCompraCommand.Execute(model);
			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, Messages.RecordCreated));

		}

		/// <summary>
		/// Listar todas las compras registradas
		/// </summary>
		/// <param name="getAllPurchasesQuery">CQRS que se encarga de listar las compras</param>
		/// <returns></returns>
		[HttpGet("listar-compras")]
		public async Task<IActionResult> ListPurchases(
		[FromServices] IGetAllPurchasesQuery getAllPurchasesQuery)
		{
			var data = await getAllPurchasesQuery.Execute(IncludeDetails:false);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		/// <summary>
		/// Listar todas las compras registradas
		/// </summary>
		/// <param name="getAllPurchasesQuery">CQRS que se encarga de listar las compras</param>
		/// <returns></returns>
		[HttpGet("listar-compras-detalladas")]
		public async Task<IActionResult> ListPurchases2(
		[FromServices] IGetAllPurchasesQuery getAllPurchasesQuery)
		{
			var data = await getAllPurchasesQuery.Execute(IncludeDetails: true);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}



		/// <summary>
		///	 Recuperar una compra por su ID
		/// </summary>
		/// <returns></returns>
		[HttpGet("buscar-compra/{Id}")]
		public async Task<IActionResult> ListPurchasebyId(
		int Id,
		[FromServices] IGetPurchaseByIdQuery getPurchase)
		{
			var data = await getPurchase.Execute(Id,IncludeDetails: false);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		/// <summary>
		/// buscar una compra por su ID con detalles
		/// </summary>
		/// <returns></returns>
		[HttpGet("buscar-compra-detallada/{Id}")]
		public async Task<IActionResult> ListPurchasebyId2(
		int Id,
		[FromServices] IGetPurchaseByIdQuery getPurchase)
		{
			var data = await getPurchase.Execute(Id, IncludeDetails: true);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}
	}

}
