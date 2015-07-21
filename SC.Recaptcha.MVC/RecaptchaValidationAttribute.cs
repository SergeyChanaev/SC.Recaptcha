using System;
using System.Configuration;
using System.Web.Mvc;

using SC.Recaptcha.Resources;

namespace SC.Recaptcha.MVC
{
	/// <summary>
	/// TODO
	/// </summary>
	public class ValidateRecaptchaAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="filterContext"></param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			try
			{
				string response = filterContext.HttpContext.Request.Form["g-recaptcha-response"];
				bool useRemoteIP;
				string remoteIP = string.Empty;

				if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SC.Recaptcha_UseRemoteIP"])
					&& bool.TryParse(ConfigurationManager.AppSettings["SC.Recaptcha_UseRemoteIP"], out useRemoteIP)
					&& useRemoteIP)
					remoteIP = filterContext.HttpContext.Request.UserHostAddress;

				RecaptchaValidationService rvs = new RecaptchaValidationService();
				RecaptchaResponse result = rvs.Validate(response, remoteIP);

				if (!result.Success)
				{
					foreach (string error in result.ErrorCodes)
					{
						switch (error)
						{
							case ("missing-input-secret"):
								filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_MissingInputSecret);
								break;
							case ("invalid-input-secret"):
								filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_InvalidInputSecret);
								break;
							case ("missing-input-response"):
								filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_MissingInputResponse);
								break;
							case ("invalid-input-response"):
								filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_InvalidInputResponse);
								break;
							default:
								filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_GeneralError);
								break;
						}
						
					}
				}

				base.OnActionExecuting(filterContext);
			}
			catch (Exception ex)
			{
				filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_GeneralError);
			}
		}
	}
}
