using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Data
{
	public class PriceRepository
	{
		public static DTO.PriceDTO GetPrices()
		{
			var db = new PapaBobsDbEntities();
			var prices = db.Prices.First();
			var dtoPrice = convertToDTO(prices);

			return dtoPrice;
		}

		private static DTO.PriceDTO convertToDTO(Price price)
		{
			var dtoPrice = new DTO.PriceDTO();

			dtoPrice.SmallSizePrice = price.SmallSizePrice;
			dtoPrice.MediumSizePrice = price.MediumSizePrice;
			dtoPrice.LargeSizePrice = price.LargeSizePrice;
			dtoPrice.RegularCrustPrice = price.RegularCrustPrice;
			dtoPrice.ThinCrustPrice = price.ThinCrustPrice;
			dtoPrice.ThickCrustPrice = price.ThickCrustPrice;
			dtoPrice.SausagePrice = price.SausagePrice;
			dtoPrice.PepperoniPrice = price.PepperoniPrice;
			dtoPrice.OnionsPrice = price.OnionsPrice;
			dtoPrice.GreenPeppersPrice = price.GreenPeppersPrice;

			return dtoPrice;
		}
	}
}
