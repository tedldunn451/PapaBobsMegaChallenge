using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Presentation
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void orderButton_Click(object sender, EventArgs e)
		{
			var order = new DTO.OrderDTO();
			order.Size = determineSize();
			order.Crust = determineCrust();
			order.Sausage = sausageCheckBox.Checked;
			order.Pepperoni = pepperoniCheckBox.Checked;
			order.Onions = onionsCheckBox.Checked;
			order.GreenPeppers = greenPepperCheckBox.Checked;
			order.Name = nameTextBox.Text;
			order.Address = addressTextBox.Text;
			order.ZipCode = zipCodeTextBox.Text;
			order.Phone = phoneTextBox.Text;
			order.PaymentType = determinePaymentType();

			Domain.OrderManager.CreateOrder(order);
		}

		private DTO.Enums.SizeType determineSize()
		{
			DTO.Enums.SizeType size;

			if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
				throw new Exception("Could not determine size selection.");

			return size;
		}

		private DTO.Enums.CrustType determineCrust()
		{
			DTO.Enums.CrustType crust;

			if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
				throw new Exception("Could not determine crust selection.");

			return crust;
		}

		private DTO.Enums.PaymentType determinePaymentType()
		{
			DTO.Enums.PaymentType paymentType;

			if (cashRadioButton.Checked)
				paymentType = DTO.Enums.PaymentType.Cash;
			else if (creditRadioButton.Checked)
				paymentType = DTO.Enums.PaymentType.Credit;
			else
				throw new Exception("Payment type not selected.");

			return paymentType;
		}
	}
}