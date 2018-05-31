using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EverPresent.Models;
using EverPresent.Backend;


namespace EverPresent.Controllers
{
    public class StudentController : Controller

    {
        // A ViewModel used for the Avatar that contains the AvatarList
        private StudentViewModel studentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend studentBackend = StudentBackend.Instance;

        // GET: Student (id "1"). Will show Andrew's Index page
        public ActionResult Index(string id = null)
        {
            var myData = studentBackend.Read("1");
            return View(myData);
        }

        /// <summary>
        /// Once called a deduction of tokens will be made from 
        /// Andrew's balance and user will be redirected to the 
        /// student either a Marketplace Success view or Marketplace
        /// Denied view based on token balance vs purchase.
        /// </summary>
        /// <returns></returns>
        public ActionResult MogwaiPurchase(int deduct)
        {
            var myData = studentBackend.Read("1");
            if (myData.Tokens >= deduct)
            {
                myData.Tokens = myData.Tokens - deduct;
                studentBackend.Update(myData);
                return RedirectToAction("MarketplaceSuccess", "Student");
            }
            return RedirectToAction("MarketplaceDennied", "Student");
        }
      
        

        // Shows the Mogwai collection of student with ID 1
        public ActionResult Mogwai(string id = null)
        {
            var myData = studentBackend.Read("1");
            return View(myData);
        }

        // Shows the Mogwai marketplace for student with ID 1
        public ActionResult Marketplace(string id = null)
        {
            var myData = studentBackend.Read("1");
            return View(myData);
        }
        //Shows the Mogwai marketplace for student with ID 1 with a toast message
        //displaying a successful transaction has been made
        public ActionResult MarketplaceSuccess(string id = null)
        {
            var myData = studentBackend.Read("1");
            return View(myData);
        }
        //Shows the Mogwai marketplace for student with ID 1 with a toast message
        //displaying a transaction has not been made
        public ActionResult MarketplaceDennied(string id = null)
        {
            var myData = studentBackend.Read("1");
            return View(myData);
        }

        // Shows editable data for student with ID 1
        public ActionResult EditAndrew(string id = null)
        {

            var myData = studentBackend.Read("1");
            return View(myData);
        }

        /// <summary>
        /// Read information on a single student    
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Details/5
        public ActionResult Read(string id = null)
        {
            var myData = studentBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This opens up the make a new Student screen
        /// </summary>
        /// <returns></returns>
        // GET: Student/Create
        public ActionResult AddStudent()
        {
            var myData = new StudentModel();
            return View(myData);
        }



        /// <summary>
        /// Make a new Student sent in by the create Student screen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Student/Create
        [HttpPost]
        public ActionResult AddStudent([Bind(Include=
                                    "Id,"+
                                    "Name,"+
                                    "AvatarId,"+
                                    "Status,"+
                                    "Tokens," +
                                    "")] StudentModel data)
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
                // Sind back for Edit
                return View(data);
            }

            studentBackend.Create(data);

            return RedirectToAction("Index", "Roster");
        }



        /// <summary>
        /// This will show the details of the student to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: student/Edit/5
        public ActionResult Update(string id = null)
        {
            var myData = studentBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This updates the student based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: student/Update/5
        [HttpPost]
        public ActionResult EditAndrew([Bind(Include=
                                    "Id,"+
                                    "Name,"+
                                    "AvatarId,"+
                                    "Status,"+
                                    "Tokens," +
                                    "")] StudentModel data)
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

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This shows the student info to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: student/Delete/5
        public ActionResult Delete(string id = null)
        {
            var myData = studentBackend.Read(id);
            return View(myData);
        }

            /// <summary>
            /// This deletes the student sent up as a post from the student delete page
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            // POST: student/Delete/5
            [HttpPost]
            public ActionResult Delete([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "AvatarId,"+
                                        "Status,"+
                                         "Tokens," +
                                        "")] StudentModel data)
            {
                if (!ModelState.IsValid)
                {
                    // Send back for edit
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

                studentBackend.Delete(data.Id);

                return RedirectToAction("Index");
            }
        }
    }


