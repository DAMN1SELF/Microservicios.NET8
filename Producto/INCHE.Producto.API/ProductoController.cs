using FluentValidation;
using INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.DeleteProduct;
using INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct;
using INCHE.Producto.Application.DataBase.Product.Queries.GetAllProducts;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductById;
using INCHE.Producto.Application.DataBase.Product.Queries.GetProductByName;
using INCHE.Producto.Application.Exceptions;
using INCHE.Producto.Application.Features;
using INCHE.Producto.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace INCHE.Producto.API
{
	[Route("api/v1/[controller]")]
	[TypeFilter(typeof(ExceptionManager))]
	[ApiController]
	public class ProductoController : ControllerBase
	{


		public ProductoController()
		{

		}

		[HttpPost("insertar")]
		public async Task<IActionResult> Create(
	   [FromBody] CreateProductModel model,
	   [FromServices] ICreateProductCommand createProductCommand,
	   [FromServices] IValidator<CreateProductModel> validator)
		{

			var validar = await validator.ValidateAsync(model);
			if(!validar.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest,validar.Errors));


			var data = await createProductCommand.Execute(model);
			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data,Messages.RecordCreated));
		}


		[HttpPut("modificar/{Id}")]
		public async Task<IActionResult> Update(int Id,
	   [FromBody] UpdateProductModel model,
	   [FromServices] IUpdateProductCommand updateProductCommand,
	   [FromServices] IValidator<UpdateProductModel> validator)
		{

			var validar = await validator.ValidateAsync(model);
			if (!validar.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validar.Errors));


			var data = await updateProductCommand.Execute(Id, model);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data,Messages.RecordUpdated));
		}


		[HttpGet("listar")]
		public async Task<IActionResult> GetAll([FromServices] IGetAllProductQuery getAllProductQuery)
		{
			var data = await getAllProductQuery.Execute();

			if (data.Count == 0)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data,Messages.RecordsRetrieved));

		}


		[HttpGet("buscar/{id}")]
		public async Task<IActionResult> GetById(int id, [FromServices] IGetProductByIdQuery getProductByIdQuery)
		{
			var data = await getProductByIdQuery.Execute(id);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Messages.InvalidRecordId));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data,Messages.RecordsRetrieved));
		}


		[HttpGet("buscar")]
		public async Task<IActionResult> GetByName([FromQuery] string nombre, [FromServices] IGetProductByNameQuery getProductByNameQuery)
		{
			var data = await getProductByNameQuery.Execute(nombre);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Messages.NoRecordsFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, Messages.RecordsRetrieved));
		}


		[HttpDelete("eliminar/{Id}")]
		public async Task<IActionResult> Delete(
			int Id,
			[FromServices] IDeleteProductCommand deleteProductCommand)
		{
		
			var data = await deleteProductCommand.Execute(Id);
			if (!data)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound,message:Messages.RecordAlreadyDeleted));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, message: Messages.RecordDeleted));
		}
	}
}
