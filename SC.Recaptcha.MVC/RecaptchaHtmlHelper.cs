using System.Configuration;
using System.Web.Mvc;

namespace SC.Recaptcha.MVC
{
	/// <summary>
	/// Provides support for displaying a Google Recaptcha validation widget.
	/// </summary>
	public static class RecaptchaHtmlHelper
	{
		/// <summary>
		/// Displays a Google Recaptcha validation widget.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <returns>A &lt;div&gt; and &lt;script&gt; elements that contains necessary markups.</returns>
		public static MvcHtmlString Recaptcha(this HtmlHelper htmlHelper)
		{
			return Recaptcha(htmlHelper, null);
		}

		/// <summary>
		/// Displays a Google Recaptcha validation widget.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="language">The two-letter ISO language code.</param>
		/// <returns>A &lt;div&gt; and &lt;script&gt; elements that contains necessary markups.</returns>
		public static MvcHtmlString Recaptcha(this HtmlHelper htmlHelper, string language)
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
