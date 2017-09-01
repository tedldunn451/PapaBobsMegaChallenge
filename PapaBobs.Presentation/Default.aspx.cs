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
			if (nameTextBox.Text.Trim().Length == 0)
			{
				validateLabel.Text = "Please enter a name.";
				validateLabel.Visible = true;
				return;
			}

			if (addressTextBox.Text.Trim().Length == 0)
			{
				validateLabel.Text = "Please enter an address.";
				validateLabel.Visible = true;
				return;
			}

			if (zipCodeTextBox.Text.Trim().Length == 0)
			{
				validateLabel.Text = "Please enter a zip code.";
				validateLabel.Visible = true;
				return;
			}

			if (phoneTextBox.Text.Trim().Length == 0)
			{
				validateLabel.Text = "Please enter a phone number.";
				validateLabel.Visible = true;
				return;
			}

			try
			{
				var order = buildOrder();
				Domain.OrderManager.CreateOrder(order);
				Response.Redirect("success.aspx");
			}
			catch (Exception ex)
			{
				validateLabel.Text = ex.Message;
				validateLabel.Visible = true;
				return;
			}
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
			else 
				paymentType = DTO.Enums.PaymentType.Credit;

			return paymentType;
		}

		protected void recalculateTotalCost (object sender, EventArgs e)
		{
			if (sizeDropDownList.SelectedValue == String.Empty) return;
			if (crustDropDownList.SelectedValue == String.Empty) return;

			var dtoOrder = buildOrder();

			try
			{
				totalCostLabel.Text = Domain.PriceManager.CalculateTotalCost(dtoOrder).ToString("C");
			}
			catch
			{

			}
		}

		private DTO.OrderDTO buildOrder()
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

			return order;
		}
	}
}