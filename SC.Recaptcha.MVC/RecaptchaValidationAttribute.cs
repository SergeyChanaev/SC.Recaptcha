using System;
using System.Collections.Generic;
using System.Web.Mvc;

using SC.Recaptcha.Resources;

namespace SC.Recaptcha.MVC
{
	/// <summary>
	/// Represents an attribute that is enables Google Recaptcha Service validation.
	/// </summary>
	public class ValidateRecaptchaAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// Overrides default <see cref="M:System.Web.Mvc.ActionFilterAttribute.OnActionExecuting(System.Web.Mvc.ActionExecutingContext)"/> method by adding custom validation logic.
		/// </summary>
		/// <param name="filterContext">Filter Context</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			try
			{
				string response = filterContext.HttpContext.Request.Form["g-recaptcha-response"];
				string remoteIP = filterContext.HttpContext.Request.UserHostAddress;

				RecaptchaValidationService rvs = new RecaptchaValidationService();
				RecaptchaResponse result = rvs.Validate(response, remoteIP);

				if (!result.Success)
				{
					filterContext.Controller.ViewData.ModelState.AddModelError("SC.Recaptcha", Strings.ResponseError_ValidationFailed);

					List<string> errors = new List<string>();
					foreach (string error in result.ErrorCodes)
					{
						switch (error)
						{
							case ("missing-input-secret"):
								errors.Add(Strings.ResponseError_MissingInputSecret);
								break;
							case ("invalid-input-secret"):
								errors.Add(Strings.ResponseError_InvalidInputSecret);
								break;
							case ("missing-input-response"):
								errors.Add(Strings.ResponseError_MissingInputResponse);
								break;
							case ("invalid-input-response"):
								errors.Add(Strings.ResponseError_InvalidInputResponse);
								break;
							default:
								errors.Add(Strings.ResponseError_GeneralError);
								break;
						}
					}
					filterContext.HttpContext.Items["SC.Recaptcha.Errors"] = errors;
				}

				base.OnActionExecuting(filterContext);
			}
			catch (Exception ex)
			{
				//TODO: Add Exception handling logic here.
			}
		}
	}
}
