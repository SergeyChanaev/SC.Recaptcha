using System.Configuration;
using System.Web.Mvc;

namespace SC.Recaptcha.MVC
{
	/// <summary>
	/// TODO
	/// </summary>
	public static class RecaptchaHtmlHelper
	{
		/// <summary>
		/// TODO
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <param name="language"></param>
		/// <returns></returns>
		public static MvcHtmlString Recaptcha(this HtmlHelper htmlHelper, string language = null)
		{
			if (ConfigurationManager.AppSettings["SC.Recaptcha_SiteKey"] == null)
				throw new ConfigurationErrorsException("Application Setting \"SC.Recaptcha_SiteKey\" must be configured!");

			TagBuilder script = new TagBuilder("script");

			if (string.IsNullOrEmpty(language))
				script.MergeAttribute("src", "https://www.google.com/recaptcha/api.js");
			else
				script.MergeAttribute("src", "https://www.google.com/recaptcha/api.js?hl=" + language);

			script.MergeAttribute("async", "true");
			script.MergeAttribute("defer", "true");

			TagBuilder div = new TagBuilder("div");
			div.MergeAttribute("class", "g-recaptcha");
			div.MergeAttribute("data-sitekey", ConfigurationManager.AppSettings["SC.Recaptcha_SiteKey"]);

			return new MvcHtmlString(div.ToString(TagRenderMode.Normal) + "\r\n" + script.ToString(TagRenderMode.Normal));
		}
	}
}
