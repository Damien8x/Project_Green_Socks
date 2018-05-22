using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EverPresent.Models;
using EverPresent.Backend;
using EverPresent.Models.Enums;

namespace EverPresent.Controllers
{
    public class RosterController : Controller
    {
        // GET: Roster
        public ActionResult Index()
        {

            return View();

        }

        public ActionResult AndrewSignedIn()
        {
            return View();
        }
    }
}