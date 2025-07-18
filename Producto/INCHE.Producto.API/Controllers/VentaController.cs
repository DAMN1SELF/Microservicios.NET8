using FluentValidation;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetAllSales;
using INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById;
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
	public class VentaController : ControllerBase
	{


		public VentaController()
		{

		}

		/// <summary>
		/// Registrar una nueva venta
		/// </summary>
		/// <param name="model">El formato json </param>
		/// <param name="createVentaCommand"></param>
		/// <returns></returns>
		[HttpPost("registrar-venta")]
		public async Task<IActionResult> RegisterSale(
			[FromBody] CreateSaleModel model,
			[FromServices] ICreateSaleCommand createVentaCommand
			)
		{

			var data = await createVentaCommand.Execute(model);
			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, Messages.RecordCreated));

		}

		/// <summary>
		/// Listar todas las ventas registradas
		/// </summary>
		/// <param name="getAllSalesQuery">CQRS que se encarga de listar las ventas</param>
		/// <returns></returns>
		[HttpGet("listar-ventas")]
		public async Task<IActionResult> ListSales(
		[FromServices] IGetAllSalesQuery getAllSalesQuery)
		{
			var data = await getAllSalesQuery.Execute(IncludeDetails:false);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		/// <summary>
		/// Listar todas las ventas registradas
		/// </summary>
		/// <param name="getAllSalesQuery">CQRS que se encarga de listar las ventas</param>
		/// <returns></returns>
		[HttpGet("listar-ventas-detalladas")]
		public async Task<IActionResult> ListSales2(
		[FromServices] IGetAllSalesQuery getAllSalesQuery)
		{
			var data = await getAllSalesQuery.Execute(IncludeDetails: true);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}



		/// <summary>
		///	 Recuperar una venta por su ID
		/// </summary>
		/// <returns></returns>
		[HttpGet("buscar-venta/{Id}")]
		public async Task<IActionResult> ListSalebyId(
		int Id,
		[FromServices] IGetSaleByIdQuery getSale)
		{
			var data = await getSale.Execute(Id,IncludeDetails: false);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}

		/// <summary>
		/// buscar una venta por su ID con detalles
		/// </summary>
		/// <returns></returns>
		[HttpGet("buscar-venta-detallada/{Id}")]
		public async Task<IActionResult> ListSalebyId2(
		int Id,
		[FromServices] IGetSaleByIdQuery getSale)
		{
			var data = await getSale.Execute(Id, IncludeDetails: true);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}
	}

}
