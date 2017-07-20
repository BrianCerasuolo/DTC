using System.Web;
using System.Xml.Linq;
using DetroitTradingMvcTest.Models;

namespace DetroitTradingMvcTest {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	/// <summary>
	/// Provides vehicle information
	/// </summary>
	public class VehicleController : ApiController {


		/// <summary>
		/// Returns vehicle makes
		/// api/vehicle/makes
		/// </summary>
		/// <returns>An IEnumberable of vehicle makes</returns>
		[HttpGet]
		public IEnumerable<VehicleMake> Makes() {
			XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/makes.xml"));

		    var makes = doc.Root
		        .Elements("make")
		        .Select(m => new VehicleMake
		        {
		            Id = (int) m.Attribute("id"),
		            Description = (string) m.Attribute("description")
		        })
		        .ToList();
		    return makes;
		}

        /// <summary>
        /// Returns vehicle models
        /// api/vehicle/models
        /// </summary>
        /// <returns>An IEnumberable of vehicle models by make ID</returns>
        [HttpGet]
        public IEnumerable<VehicleModel> Models(int id) {
            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/modelsbymake.xml"));

		    var models = doc.Root
		        .Elements("make").Where(m => (int) m.Attribute("id") == id)
		        .Elements("model")
		        .Select(m => new VehicleModel
		        {
		            Id = (int) m.Attribute("id"),
		            Description = (string) m.Attribute("description")
		        })
		        .ToList();
		    return models;
		}
	}
}