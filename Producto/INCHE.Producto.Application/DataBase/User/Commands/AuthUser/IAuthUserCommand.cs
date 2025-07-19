using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.User.Commands.AuthUser
{
    public interface IAuthUserCommand
    {
        Task<ResponseAuthUserModel> Execute(AuthUserModel model);
    }
}
