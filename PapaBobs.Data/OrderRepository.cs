using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PapaBobs.Data
{
    public class OrderRepository
    {
		public static void CreateOrder(DTO.OrderDTO dtoOrder)
		{
			var db = new PapaBobsDbEntities();
			var order = convertToEntity(dtoOrder);

			db.Orders.Add(order);
			db.SaveChanges();
		}

		private static Order convertToEntity(DTO.OrderDTO dtoOrder)
		{
			var order = new Order();

			order.OrderId = dtoOrder.OrderId;
			order.Size = dtoOrder.Size;
			order.Crust = dtoOrder.Crust;
			order.Sausage = dtoOrder.Sausage;
			order.Pepperoni = dtoOrder.Pepperoni;
			order.Onions = dtoOrder.Onions;
			order.GreenPeppers = dtoOrder.GreenPeppers;
			order.Name = dtoOrder.Name;
			order.Address = dtoOrder.Address;
			order.Phone = dtoOrder.Phone;
			order.ZipCode = dtoOrder.ZipCode;
			order.TotalCost = dtoOrder.TotalCost;
			order.PaymentType = dtoOrder.PaymentType;
			order.Completed = dtoOrder.Completed;

			return order;
		}
		public static List<DTO.OrderDTO> GetOrders()
		{
			var db = new PapaBobsDbEntities();
			var dbOrders = db.Orders.Where(p=> p.Completed == false).ToList();
			var dtoOrders = new List<DTO.OrderDTO>();

			foreach (var dbOrder in dbOrders)
			{
				var dtoOrder = new DTO.OrderDTO();

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

		public static void CompleteOrder(Guid orderId)
		{
			var db = new PapaBobsDbEntities();

			var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
			order.Completed = true;
			db.SaveChanges();
		}
    }
}
