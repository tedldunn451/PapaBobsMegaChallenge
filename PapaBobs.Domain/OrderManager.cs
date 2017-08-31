using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
		public static void CreateOrder()
		{
			Data.OrderRepository.CreateOrder();
		}

		public static List<DTO.Order> GetOrders()
		{
			var orders = Data.OrderRepository.GetOrders();
			return orders;
		}
    }
}
