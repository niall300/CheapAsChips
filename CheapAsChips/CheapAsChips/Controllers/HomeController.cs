using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheapAsChips.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            //we can pass data to the view using the viewbag
            //our variable is called theMessage
            ViewBag.theMessage = "Give us a shout.";

            return View();
        }
        [HttpPost]
        //Note the variable yourmessage must correspond
        //with the same variable in the view
        public ActionResult Contact(string yourmessage)
        {
            //we can pass data to the view using the viewbag
            //our variable is called theMessage
            ViewBag.theMessage = "Your message reads:   " + yourmessage;
            //TODO process message

            return View();
        }

        //Below is an example of how we can tell the method to find an alternative view
        
        public ActionResult Alternative()
        {
            //below we are asking to return the view "contact"
            return View("Contact");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "NIALLCOFFEY";
            if(letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            else if (letterCase == "upper")
            {
                return Content(serial.ToUpper());
            }
            
            return Content(serial);
        }
    }
}