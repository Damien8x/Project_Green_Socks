﻿using System;
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

        public ActionResult StSignIn()
        {
            return View();
        }
        
    }
}