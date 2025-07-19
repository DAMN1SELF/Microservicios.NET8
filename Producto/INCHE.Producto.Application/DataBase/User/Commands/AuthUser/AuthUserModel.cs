using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.User.Commands.AuthUser
{
    public class AuthUserModel
    {
		public string UserName { get; set; }
		public string Password { get; set; }
	}

	public class ResponseAuthUserModel
	{
		public string UserName { get; set; }
		public string Token { get; set; }
	}
}
