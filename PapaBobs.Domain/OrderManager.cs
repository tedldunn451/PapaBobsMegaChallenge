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
		public static void CreateOrder(DTO.OrderDTO dtoOrder)
		{
			//var order = new DTO.OrderDTO();

			dtoOrder.OrderId = Guid.NewGuid();
			dtoOrder.TotalCost = PriceManager.CalculateTotalCost(dtoOrder);

			Data.OrderRepository.CreateOrder(dtoOrder);
		}

		public static List<DTO.OrderDTO> GetOrders()
		{
			var orders = Data.OrderRepository.GetOrders();
			return orders;
		}
    }
}
