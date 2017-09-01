using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
	public class PriceManager
	{
		public static decimal CalculateTotalCost(DTO.OrderDTO dtoOrder)
		{
			decimal totalCost = 0.00M;
			var prices = getPrices();

			totalCost += calculateSizeCost(dtoOrder, prices);
			totalCost += calculateCrustCost(dtoOrder, prices);
			totalCost += calculateToppingsCost(dtoOrder, prices);

			return totalCost;
		}

		private static decimal calculateSizeCost(DTO.OrderDTO dtoOrder, DTO.PriceDTO dtoPrice)
		{
			decimal sizeCost = 0.00M;

			switch (dtoOrder.Size)
			{
				case DTO.Enums.SizeType.Small:
					sizeCost = dtoPrice.SmallSizePrice;
					break;
				case DTO.Enums.SizeType.Medium:
					sizeCost = dtoPrice.MediumSizePrice;
					break;
				case DTO.Enums.SizeType.Large:
					sizeCost = dtoPrice.LargeSizePrice;
					break;
				default:
					break;
			}

			return sizeCost;
		}

		private static decimal calculateCrustCost(DTO.OrderDTO dtoOrder, DTO.PriceDTO dtoPrice)
		{
			decimal crustCost = 0.00M;

			switch (dtoOrder.Crust)
			{
				case DTO.Enums.CrustType.Regular:
					crustCost = dtoPrice.RegularCrustPrice;
					break;
				case DTO.Enums.CrustType.Thin:
					crustCost = dtoPrice.ThinCrustPrice;
					break;
				case DTO.Enums.CrustType.Thick:
					crustCost = dtoPrice.ThickCrustPrice;
					break;
				default:
					break;
			}

			return crustCost;
		}

		private static decimal calculateToppingsCost(DTO.OrderDTO dtoOrder, DTO.PriceDTO dtoPrice)
		{
			decimal toppingsCost = 0.00M;

			toppingsCost += (dtoOrder.Sausage) ? dtoPrice.SausagePrice : 0M;
			toppingsCost += (dtoOrder.Pepperoni) ? dtoPrice.PepperoniPrice : 0M;
			toppingsCost += (dtoOrder.Onions) ? dtoPrice.OnionsPrice : 0M;
			toppingsCost += (dtoOrder.GreenPeppers) ? dtoPrice.GreenPeppersPrice : 0M;

			return toppingsCost;
		}

		private static DTO.PriceDTO getPrices()
		{
			var prices = Data.PriceRepository.GetPrices();

			return prices;
		}
	}
}
