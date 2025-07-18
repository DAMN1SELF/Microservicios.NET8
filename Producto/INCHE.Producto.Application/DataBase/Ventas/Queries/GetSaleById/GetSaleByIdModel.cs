using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INCHE.Producto.Application.DataBase.Sale.Queries.GetSaleById
{
    public class GetSaleByIdModel
    {
		public int SaleId { get; set; }
		public string FullName { get; set; }
		public string BatchNumber { get; set; }
		public DateTime RegistrationDate { get; set; }
		public decimal Cost { get; set; }
		public decimal SalePrice { get; set; }

	}
}
