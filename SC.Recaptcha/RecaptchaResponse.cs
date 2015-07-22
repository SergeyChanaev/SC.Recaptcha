using System.Collections.Generic;

using Newtonsoft.Json;

namespace SC.Recaptcha
{
	/// <summary>
	/// Response returned from Google Recaptcha Service.
	/// </summary>
	public class RecaptchaResponse
	{
		/// <summary>
		/// Indicates whether validation has been successfully completed.
		/// </summary>
		[JsonProperty("success")]
		public bool Success { get; set; }

		/// <summary>
		/// Returns the possible error codes occurred during validation.
		/// </summary>
		[JsonProperty("error-codes")]
		public IList<string> ErrorCodes { get; set; }
	}
}
