using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistant.Models;

namespace CommunityAssistant.Controllers
{
    public class HomeController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is an MVC example application using the fictional charity Community Assist.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}