using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BGScheduler.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String Email, String Password)
        {
            ScheduleProdEntities db = new ScheduleProdEntities();

            var user = (from e in db.EmpDemographics where e.EmailAddress == Email && e.Password == Password select e).FirstOrDefault();

            if (user != null)
            {
                // user authenticated
                Session["UserName"] = "Mike Ross";
                return RedirectToAction("Index","Home");
            }
            else 
            { // bad attempt - go away
                ViewBag.Message = "Invalid Credentials. Please Try Again.";
                return View();
            }

            
        }
    }
}