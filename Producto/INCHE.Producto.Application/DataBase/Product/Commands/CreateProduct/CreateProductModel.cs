using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Commands.CreateProduct
{
    public class CreateProductModel
    {
		public string FullName { get; set; }
		public string BatchNumber { get; set; }
		public decimal Cost { get; set; }
	}
}
