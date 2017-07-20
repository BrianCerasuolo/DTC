using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DetroitTradingMvcTest.Models;

namespace DetroitTradingMvcTest.Controllers {
	/// <summary>
	/// Controller that serves the quoting portion of the website
	/// </summary>
	public class QuoteController : Controller {
		/// <summary>
		/// Index action / landing page
		/// </summary>
		/// <returns>A ViewResult</returns>
		public ViewResult Index() {
			return View();
		}

        [HttpPost]
	    public ActionResult Post(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Error", ModelState);
            }
            return PartialView("_ThankYou", vehicle);
        }
	}
}