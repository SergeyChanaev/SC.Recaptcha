using System;
using System.Configuration;
using System.Net.Http;

using Newtonsoft.Json;

namespace SC.Recaptcha
{
	/// <summary>
	/// TODO
	/// </summary>
	public class RecaptchaValidationService
	{
		private const string ApiBaseUrl = "www.google.com/recaptcha/api";

		/// <summary>
		/// Perform validation
		/// </summary>
		/// <param name="response"></param>
		/// <param name="remoteIP"></param>
		/// <returns></returns>
		public RecaptchaResponse Validate(string response, string remoteIP = null)
		{
			if (ConfigurationManager.AppSettings["SC.Recaptcha_Secret"] == null)
				throw new ConfigurationErrorsException("Application Setting \"SC.Recaptcha_Secret\" must be configured!");

			string url = string.Format(
				"https://{0}/siteverify?secret={1}&response={2}",
				ApiBaseUrl,
				ConfigurationManager.AppSettings["SC.Recaptcha_Secret"],
				response);

			if (!string.IsNullOrEmpty(remoteIP))
				url += string.Format("&remoteip={0}", remoteIP);

			try
			{
				using (HttpClient httpClient = new HttpClient())
				{
					HttpResponseMessage hrm = httpClient.GetAsync(url).Result;
					hrm.EnsureSuccessStatusCode();

					string result = hrm.Content.ReadAsStringAsync().Result;

					return JsonConvert.DeserializeObject<RecaptchaResponse>(result);
				}
			}
			catch (HttpRequestException ex)
			{
				//TODO:
			}
			catch (Exception ex)
			{
				//TODO:
			}

			return null;
		}
	}
}
