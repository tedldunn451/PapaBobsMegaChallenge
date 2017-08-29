using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PapaBobs.Data
{
    public class OrderRepository
    {
		public static List<DTO.Order> GetOrders()
		{
			PapaBobsDbEntities db = new PapaBobsDbEntities();
			var dbOrders = db.Orders.ToList();

			var dtoOrders = new List<DTO.Order>();

			foreach (var dbOrder in dbOrders)
			{
				var dtoOrder = new DTO.Order();

				dtoOrder.OrderId = dbOrder.OrderId;
				dtoOrder.Size = dbOrder.Size;
				dtoOrder.Crust = dbOrder.Crust;
				dtoOrder.Sausage = dbOrder.Sausage;
				dtoOrder.Pepperoni = dbOrder.Pepperoni;
				dtoOrder.Onions = dbOrder.Onions;
				dtoOrder.GreenPeppers = dbOrder.GreenPeppers;
				dtoOrder.TotalCost = dbOrder.TotalCost;
				dtoOrder.Name = dbOrder.Name;
				dtoOrder.Address = dbOrder.Address;
				dtoOrder.ZipCode = dbOrder.ZipCode;
				dtoOrder.Phone = dbOrder.Phone;
				dtoOrder.PaymentType = dbOrder.PaymentType;
				dtoOrder.Completed = dbOrder.Completed;

				dtoOrders.Add(dtoOrder);
			}

			return dtoOrders;
		}
    }
}
