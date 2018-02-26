using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistant.Models;

namespace CommunityAssistant.Controllers
{
    public class GrantApplicationController : Controller
    {
        // GET: GrantApplication
        public ActionResult Index()
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            if (Session["userKey"] == null)
            {
                Message m = new Message("You must be logged in order to apply for assitance.");
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantTypeKeys = new SelectList(db.GrantTypes,"GrantTypeKey","GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey,GrantApplicationDate," +
            "GrantTypeKey,GrantApplicationRequestAmount,GrantApplicationReason,GrantApplicationStatusKey," +
            "GrantApplicationAllocationAmount")]GrantApplication g)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            
            int key = (int)Session["userKey"];

            //GrantApplication grantApplication = new GrantApplication();

            //grantApplication.GrantTypeKey = g.GrantTypeKey;

            g.GrantApplicationStatusKey = 1; //pending
            g.PersonKey = key;
            g.GrantAppicationDate = DateTime.Now;

            Console.WriteLine("g = ",g.ToString());

            db.GrantApplications.Add(g);
            db.SaveChanges();

            Message m = new Message("Thank you for your contribution to the community.");
            return RedirectToAction("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}