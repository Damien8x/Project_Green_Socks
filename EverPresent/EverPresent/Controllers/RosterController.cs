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
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;
        // GET: Roster
        public ActionResult Index()
        {

            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel); 

        }

        public ActionResult AndrewSignedIn()
        {
            return View();
        }

        public ActionResult SetLogin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("Index");
        }

        // GET: Kiosk/SetLogout/5
        public ActionResult SetLogout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("Index");
        }
    }
}