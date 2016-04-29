using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PintrestClone.Models;
using System.Web.Services.Protocols;

namespace PintrestClone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllPins()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var currentUser = User.Identity;
            var userInfo = db.Users.FirstOrDefault(x => x.Email == currentUser.Name);

            var allPins = userInfo.Pins.Select(p => new Pin() {Body = p.Body, PinUrl = p.PinUrl, PhotoUrl = p.PhotoUrl}).ToList();

            return Json(allPins, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePin(Pin p)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var currentUser = User.Identity;
            var userInfo = db.Users.FirstOrDefault(x => x.Email == currentUser.Name);

            userInfo.Pins.Add(p);

            db.SaveChanges();

            var sentPin = new Pin()
            {
                PhotoUrl = p.PhotoUrl,
                Body = p.Body,
                PinUrl = p.PinUrl
            };
            return Json(sentPin);
        }
    }
}