using System;
using System.Web.UI;

using SC.Recaptcha.Resources;

namespace SC.Recaptcha.Sample.WebForms
{
	public partial class Default : Page
	{
		protected void btnClickMe_Click(object sender, EventArgs e)
		{
			string response = Request.Form["g-recaptcha-response"];
			string remoteIP = Request.UserHostAddress;

			RecaptchaValidationService rvs = new RecaptchaValidationService();
			RecaptchaResponse result = rvs.Validate(response, remoteIP);

			if (result.Success)
				lblError.Text = "Hurray! You are human!";
			else
				lblError.Text = Strings.ResponseError_ValidationFailed;

			////Get error details if needed

			//if (!result.Success)
			//{
			//	List<string> errors = new List<string>();

			//	foreach (string error in result.ErrorCodes)
			//	{
			//		switch (error)
			//		{
			//			case ("missing-input-secret"):
			//				errors.Add(Strings.ResponseError_MissingInputSecret);
			//				break;
			//			case ("invalid-input-secret"):
			//				errors.Add(Strings.ResponseError_InvalidInputSecret);
			//				break;
			//			case ("missing-input-response"):
			//				errors.Add(Strings.ResponseError_MissingInputResponse);
			//				break;
			//			case ("invalid-input-response"):
			//				errors.Add(Strings.ResponseError_InvalidInputResponse);
			//				break;
			//			default:
			//				errors.Add(Strings.ResponseError_GeneralError);
			//				break;
			//		}
			//	}
			//}
		}
	}
}
