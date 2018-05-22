﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverPresent.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mogwai()
        {
            return View();
        }

        public ActionResult Marketplace()
        {
            return View();
        }
        public ActionResult Attendance()
        {
            return View();
        }

        public ActionResult AddStudent()
        {
            var myData = new Models.MogwaiModel();
            var tupleModel = new System.Tuple<Models.StudentModel, Models.MogwaiModel>(new Models.StudentModel(), myData);
            return View(tupleModel);

        }
    }
}