﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverPresent.Controllers
{
    // Controller for the Admin side of the website
    public class AdminController : Controller
    {
        // A ViewModel used for the Avatar that contains the AvatarList
        private Models.StudentViewModel studentViewModel = new Models.StudentViewModel();

        // The Backend Data source
        private Backend.StudentBackend studentBackend = Backend.StudentBackend.Instance;

        //A Model used for a specific student
        private Models.StudentModel studentModel = new Models.StudentModel();

        // return login page
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Returns the index of the Admin
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the current students within the system
        /// </summary>
        /// <returns>All the students currently in the system</returns>
        public ActionResult Roster()
        {
            var myData = studentBackend.Read("1");
            var myDataList = studentBackend.Index();
            studentViewModel = new Models.StudentViewModel(myDataList);
            return View(Tuple.Create(myData, studentViewModel));
        }

        /// <summary>
        /// Shows a page of inactive students
        /// </summary>
        /// <returns></returns>
        public ActionResult InactiveStudents()
        {
            var myDataList = studentBackend.Index();
            studentViewModel = new Models.StudentViewModel(myDataList);
            return View(studentViewModel);
        }

        /// <summary>
        /// Shows the school calendar
        /// </summary>
        /// <returns></returns>
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Activate(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            var myData = studentBackend.Read(id);
            myData.Status = Models.Enums.StudentStatusEnum.Out;
            studentBackend.Update(myData);
            return RedirectToAction("InactiveStudents", "Admin");
        }
        /// <summary>
        /// This updates the student based on the information posted from the update page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: student/Update/5
        [HttpPost]
        public ActionResult Roster([Bind(Prefix= "Item1"
                                    )] EverPresent.Models.StudentModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to error page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for Edit
                return View(data);
            }

            studentBackend.Update(data);

            var myData = studentBackend.Read("1");
            var myDataList = studentBackend.Index();
            studentViewModel = new Models.StudentViewModel(myDataList);
            return View(Tuple.Create(myData, studentViewModel));
        }
    }
}