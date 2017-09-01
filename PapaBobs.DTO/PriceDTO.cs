using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO
{
	public class PriceDTO
	{
		public int Id { get; set; }
		public decimal SmallSizePrice { get; set; }
		public decimal MediumSizePrice { get; set; }
		public decimal LargeSizePrice { get; set; }
		public decimal RegularCrustPrice { get; set; }
		public decimal ThinCrustPrice { get; set; }
		public decimal ThickCrustPrice { get; set; }
		public decimal SausagePrice { get; set; }
		public decimal PepperoniPrice { get; set; }
		public decimal OnionsPrice { get; set; }
		public decimal GreenPeppersPrice { get; set; }
	}
}
