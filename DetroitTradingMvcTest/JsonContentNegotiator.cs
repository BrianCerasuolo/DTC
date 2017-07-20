namespace DetroitTradingMvcTest {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Net.Http.Headers;
	using System.Web;

	/// <summary>
	/// JsonContentNegotiator forces the MVC WebApi to use json
	/// </summary>
	public class JsonContentNegotiator : IContentNegotiator {
		/// <summary>
		/// The JsonMediaType formatter that we would like to use.
		/// </summary>
		private readonly JsonMediaTypeFormatter _jsonFormatter;

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonContentNegotiator" /> class.
		/// </summary>
		/// <param name="formatter">The JsonMediaTypeFormatter we want to initialize this class with.</param>
		public JsonContentNegotiator(JsonMediaTypeFormatter formatter) {
			_jsonFormatter = formatter;
		}

		/// <summary>
		/// Appends a mediatype header to all WebApi requests as part of its content negotiation
		/// </summary>
		/// <param name="type">Inherited parameter, not used in our implementation</param>
		/// <param name="request">Inherited paramter, not used in our implementation, we don't need request information</param>
		/// <param name="formatters">Inherited paramter, not used in our implementation, formatters are provided in constructor</param>
		/// <returns>A negotiated content result</returns>
		public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) {
			var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
			return result;
		}
	}
}