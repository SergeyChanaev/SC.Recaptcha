using System;
using System.Configuration;
using System.Net.Http;

using Newtonsoft.Json;

namespace SC.Recaptcha
{
	/// <summary>
	/// Recaptcha Validation Service class which interacts with Google Recaptcha Service.
	/// </summary>
	public class RecaptchaValidationService
	{
		private const string ApiBaseUrl = "www.google.com/recaptcha/api";

		/// <summary>
		/// Verification of the user's response.
		/// </summary>
		/// <param name="response">The user response token provided by the reCAPTCHA control.</param>
		/// <returns>The method returns an <see cref="T:SC.Recaptcha.RecaptchaResponse"/> instance.</returns>
		public RecaptchaResponse Validate(string response)
		{
			return Validate(response, null);
		}

		/// <summary>
		/// Verification of the user's response.
		/// </summary>
		/// <param name="response">The user response token provided by the reCAPTCHA control.</param>
		/// <param name="remoteIP">The user's IP address.</param>
		/// <returns>The method returns an <see cref="T:SC.Recaptcha.RecaptchaResponse"/> instance.</returns>
		public RecaptchaResponse Validate(string response, string remoteIP)
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
				//TODO: Add HttpRequestException handling logic here.
			}
			catch (Exception ex)
			{
				//TODO: Add Exception handling logic here.
			}

			return null;
		}
	}
}
