using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverPresent.Controllers
{
    public class AdminController : Controller


    {


        // A ViewModel used for the Avatar that contains the AvatarList
        private Models.StudentViewModel studentViewModel = new Models.StudentViewModel();

        // The Backend Data source
        private Backend.StudentBackend studentBackend = Backend.StudentBackend.Instance;
     

        public ActionResult Index()
        {
            return View();
        }

            public ActionResult Roster()
            {

                var myDataList = studentBackend.Index();
                studentViewModel = new Models.StudentViewModel(myDataList);
                return View(studentViewModel);

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

        public ActionResult Andrew()
        {
            return View();
        }

     

        public ActionResult EditAndrewAttendance()
        {
            return View();
        }

        public ActionResult InactiveStudents()
        {
            return View();
        }

        public ActionResult GenerateReports()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }
    }
}