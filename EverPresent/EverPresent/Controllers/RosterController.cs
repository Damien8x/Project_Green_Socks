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

        // A ViewModel used for the Avatar that contains the AvatarList
        private StudentViewModel studentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend studentBackend = StudentBackend.Instance;
        // GET: Roster
        public ActionResult Index()
        {

            studentViewModel.StudentList = studentBackend.Index();
            return View(studentViewModel);

        }

        public ActionResult AndrewSignedIn()
        {
            return View();
        }
    }
}