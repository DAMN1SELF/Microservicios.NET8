using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct
{
    public interface IUpdateProductCommand
    {
        Task<UpdateProductModel> Execute(UpdateProductModel model);
    }
}
