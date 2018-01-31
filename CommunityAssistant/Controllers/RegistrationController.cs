using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistant.Models;

namespace CommunityAssistant.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LastName,FirstName,Email,Phone,PlainPassword,Apartment,Street,City,State,Zipcode")]NewPerson r)
        {
            int result = db.usp_Register(
                r.LastName,
                r.FirstName,
                r.Email,
                r.PlainPassword,
                r.Apartment,
                r.Street,
                r.City,
                r.State,
                r.Zipcode,
                r.Phone);
            Message m = new Message();
            if (result != -1)
            {
                m.MessageText = "Thank you for registring";
                return RedirectToAction("Result",m);
            }
            
            m.MessageText = "Error";
            return RedirectToAction("Result",m);
        }
    }
}