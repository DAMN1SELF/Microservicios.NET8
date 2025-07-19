using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Sale.Commands.CreateSale
{
    public interface ICreateSaleCommand
	{
        Task<CreateSaleModel> Execute(CreateSaleModel model);
    }
}
