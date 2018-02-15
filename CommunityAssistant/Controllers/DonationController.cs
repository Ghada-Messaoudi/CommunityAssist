using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistant.Models;

namespace CommunityAssistant.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donate
        public ActionResult Index()
        {
            if (Session["userKey"] == null)
            {
                Message m = new Message("You must be logged in to donate.");
                return RedirectToAction("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationKey,PersonKey,DonationDate,DonationAmount,DonationConfirmationCode")]Donation d)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();

            int key = (int)Session["userKey"];

            Donation dn = new Donation();

            dn.DonationConfirmationCode = Guid.NewGuid();
            dn.PersonKey = key;
            dn.DonationDate = DateTime.Now;
            dn.DonationAmount = d.DonationAmount;

            db.Donations.Add(dn);
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