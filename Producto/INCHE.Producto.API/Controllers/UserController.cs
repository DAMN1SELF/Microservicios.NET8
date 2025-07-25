﻿using FluentValidation;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;
using INCHE.Producto.Application.DataBase.User.Commands.CreateUser;
using INCHE.Producto.Application.DataBase.User.Commands.DeleteUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUser;
using INCHE.Producto.Application.DataBase.User.Commands.UpdateUserPassword;
using INCHE.Producto.Application.DataBase.User.Queries.GetAllUser;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserById;
using INCHE.Producto.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using INCHE.Producto.Application.Exceptions;
using INCHE.Producto.Application.External.GetTokenJwt;
using INCHE.Producto.Application.Features;
using INCHE.Producto.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace INCHE.Producto.API.Controllers
{

	[Authorize]
	[Route("api/v1/usuario")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

		[HttpPost("insertar")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand,
            [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserModel model,
            [FromServices] IUpdateUserCommand updateUserCommand,
            [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

		[AllowAnonymous]
		[HttpPut("actualizar-clave")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdateUserPasswordModel model,
            [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand,
            [FromServices] IValidator<UpdateUserPasswordModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data,message:Messages.RecordsRetrieved));
        }

        [HttpDelete("eliminar/{userId}")]
        public async Task<IActionResult> Delete(
            int userId,
            [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await deleteUserCommand.Execute(userId);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data, message: Messages.RecordNotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordDeleted));

		}

        [HttpGet("listar")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllUserQuery getAllUserQuery)
        {

            var data = await getAllUserQuery.Execute();
            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data, message: Messages.RecordNotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordsRetrieved));
		}

        [HttpGet("obtener/{userId}")]
        public async Task<IActionResult> GetById(
            int userId,
            [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {

            if (userId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await getUserByIdQuery.Execute(userId);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, message: Messages.RecordRetrieved));

		}


     

		[AllowAnonymous]
		[HttpPost("autenticarse")]
		public async Task<IActionResult> Autenticarse(
	    [FromBody] AuthUserModel login,
	    [FromServices] IAuthUserCommand authUserCommand,
	    [FromServices] IValidator<AuthUserModel> validator,
	    [FromServices] IGetTokenJwtService getTokenJwtService)
		{


			var validate = await validator.ValidateAsync(login);
			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await authUserCommand.Execute(login);


			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			var token = getTokenJwtService.Execute(login);
			Response.Headers.Append("Authorization", $"Bearer {token}");
			data.Token = token;

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
		}
	}
}
