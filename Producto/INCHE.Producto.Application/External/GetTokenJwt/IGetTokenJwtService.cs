using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
		string Execute(AuthUserModel model);
	}
}
