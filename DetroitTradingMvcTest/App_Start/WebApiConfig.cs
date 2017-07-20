using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DetroitTradingMvcTest {
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// Web API configuration and services
			var jsonFormatter = new JsonMediaTypeFormatter();
			//optional: set serializer settings here
			config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

			// Web API routes
			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{action}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
