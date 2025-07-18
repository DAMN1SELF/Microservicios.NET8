using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct
{
    public interface ICreateProductCommand
    {
        Task<CreateProductModel> Execute(CreateProductModel model);
    }
}
