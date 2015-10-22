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
    }
}