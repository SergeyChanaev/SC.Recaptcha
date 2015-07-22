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

		#region Properties

		/// <summary>
		/// Secret Key.
		/// </summary>
		public string Secret { get; private set; }

		/// <summary>
		/// Indicates whether application should also pass user IP address to Google Recaptcha Service to perform validation.
		/// </summary>
		public bool UseRemoteIP { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// The class <see cref="T:SC.Recaptcha.RecaptchaValidationService"/> constructor.
		/// </summary>
		public RecaptchaValidationService()
		{
			if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SC.Recaptcha_Secret"]))
				throw new ConfigurationErrorsException("Application Setting \"SC.Recaptcha_Secret\" must be configured!");
			Secret = ConfigurationManager.AppSettings["SC.Recaptcha_Secret"];

			bool useRemoteIP = false;
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SC.Recaptcha_UseRemoteIP"]))
				bool.TryParse(ConfigurationManager.AppSettings["SC.Recaptcha_UseRemoteIP"], out useRemoteIP);
			UseRemoteIP = useRemoteIP;
		}

		#endregion

		#region Methods

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
			string url = string.Format(
				"https://{0}/siteverify?secret={1}&response={2}",
				ApiBaseUrl,
				Secret,
				response);

			if (!string.IsNullOrEmpty(remoteIP) && UseRemoteIP)
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

		#endregion
	}
}
