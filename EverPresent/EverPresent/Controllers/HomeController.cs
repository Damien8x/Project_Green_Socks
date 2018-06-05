using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EverPresent.Models;
using EverPresent.Backend;

namespace EverPresent.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Shows the login page for the EverPresent app
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows a web form to submit a Message with user information
        /// </summary>
        /// <returns></returns>
         public ActionResult Contact()
        {
            EverPresent.Models.ContactModel contact = new EverPresent.Models.ContactModel();
            return View(contact);
        }
        
        /// <summary>
        /// Confirmation view for Contact. Re-displays message and information back to user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult ContactSuccess(ContactModel data)
        {
            return View(data);
        }

        /// <summary>
        /// POST for Contact. Takes in form information and passes Model to ContactSuccess ActionResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact([Bind(Include=
                                    "Id,"+
                                    "Name,"+
                                    "Email,"+
                                    "Message," +
                                    "")] ContactModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit, with Error Message
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for Edit
                return View(data);
            }


            return RedirectToAction("ContactSuccess", "Home", data);
        }

    }
}