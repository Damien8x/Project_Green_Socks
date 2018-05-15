using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverPresent.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your admin page.";

            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult Joe()
        {
            return View();
        }

        public ActionResult InactiveStudents()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }
    }
}