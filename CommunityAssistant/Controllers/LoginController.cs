using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistant.Models;

namespace CommunityAssistant.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // get the fields from the forms and bind them to the class
        public ActionResult Index([Bind(Include ="UserName,Password")]LoginClass lc)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            int logingResult = db.usp_Login(lc.Username, lc.Password);
            if(logingResult != -1)
            {
                var uid = (from p in db.People
                           where p.PersonEmail.Equals(lc.Username)
                           select p.PersonKey).FirstOrDefault();
                int rKey = (int)uid;
                Session["userKey"] = rKey;
                Session["Username"] = lc.Username;
                Message msg = new Message("Thank you "+lc.Username + " for logging in. You can now donate or apply for assitance");
                return RedirectToAction("Result",msg);
            }

            Message msge = new Message("Invalid Login! Please try again.");
            return View("Result", msge);
        }

        //for every view there has to be a methode
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}