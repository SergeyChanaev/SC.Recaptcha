using System.Collections.Generic;

using Newtonsoft.Json;

namespace SC.Recaptcha
{
	/// <summary>
	/// Response from Google
	/// </summary>
	public class RecaptchaResponse
	{
		/// <summary>
		/// TODO
		/// </summary>
		[JsonProperty("success")]
		public bool Success { get; set; }

		/// <summary>
		/// TODO
		/// </summary>
		[JsonProperty("error-codes")]
		public ICollection<string> ErrorCodes { get; set; }

		/// <summary>
		/// TODO
		/// </summary>
		public RecaptchaResponse()
		{
			ErrorCodes = new HashSet<string>();
		}
	}
}
