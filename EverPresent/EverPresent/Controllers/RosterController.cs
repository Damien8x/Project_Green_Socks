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

        /// <summary>
        /// Toggles Status Enum of Student equal to the argument
        /// by calling the ToggleStatusById() method.
        /// Redirects to "IndexOut" view for appropriate toast
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetLogin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("IndexOut");
        }
        /// <summary>
        /// Toggles Status Enum of Student equal to the argument
        /// by calling the ToggleStatusById() method.
        /// Redirects to "IndexIn" view for appropriate toast
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetLogout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("IndexIn");
        }

        /// <summary>
        /// Method for IndexIn View. 
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexIn()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);

        }

        /// <summary>
        /// Method for IndexOut View. 
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexOut()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);

        }


    }
}