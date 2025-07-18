using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Product.Commands.UpdateProduct
{
    public class UpdateProductModel
    {
		public string FullName { get; set; }
		public string BatchNumber { get; set; }
		public string RegistrationDate { get; set; }
		public decimal Cost { get; set; }
		public decimal SalePrice { get; set; }
	}
}
