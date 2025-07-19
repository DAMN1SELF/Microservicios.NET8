using AutoMapper;
using INCHE.Producto.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.User.Commands.AuthUser
{
    public class AuthUserCommand: IAuthUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public AuthUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<ResponseAuthUserModel> Execute(AuthUserModel model)
        {

			var user = await _databaseService.User
				.FirstOrDefaultAsync(u => u.UserName == model.UserName);

			if (user == null) throw new Exception("Usuario o contraseña incorrectos");

			bool passwordOk = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

			if (!passwordOk) throw new Exception("Usuario o contraseña incorrectos");

			var result = _mapper.Map<ResponseAuthUserModel>(user);

			return result;
		}
    }
}
