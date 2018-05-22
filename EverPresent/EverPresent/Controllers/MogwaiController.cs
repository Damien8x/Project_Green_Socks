using System.Web.Mvc;
using EverPresent.Models;
using EverPresent.Backend;

namespace EverPresent.Controllers
{
    /// <summary>
    /// Mogwai Contoller manages the mogwai web pages including how to make new ones, change them, and delete them
    /// </summary>
    public class MogwaiController : Controller
    {
        // A ViewModel used for the Avatar that contains the AvatarList
        private MogwaiViewModel mogwaiViewModel = new MogwaiViewModel();

        // The Backend Data source
        private MogwaiBackend mogwaiBackend = MogwaiBackend.Instance;

        // GET: Mogwai
        /// <summary>
        /// Index, the page that shows all the mogwais
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Load the list of data into the MogwaList
            mogwaiViewModel.MogwaiList = mogwaiBackend.Index();
            return View(mogwaiViewModel);
        }

        /// <summary>
        /// Read information on a single mogwai
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Mogwai/Details/5
        public ActionResult Read(string id = null)
        {
            var myData = mogwaiBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This opens up the make a new Mogwai screen
        /// </summary>
        /// <returns></returns>
        // GET: Mogwai/Create
        public ActionResult Create()
        {
            var myData = new MogwaiModel();
            return View(myData);
        }

        public ActionResult AddStudent()
        {
            var myData = new MogwaiModel();
            return View(myData);
        }

        /// <summary>
        /// Make a new mogwai sent in by the create mogwai screen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Mogwai/Create
        [HttpPost]
        public ActionResult Create([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "")] MogwaiModel data)
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

            mogwaiBackend.Create(data);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This will show the details of the mogwai to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Mogwai/Edit/5
        public ActionResult Update(string id = null)
        {
            var myData = mogwaiBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This updates the mogwai based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Mogwai/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "")] MogwaiModel data)
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

            mogwaiBackend.Update(data);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This shows the mogwai info to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Mogwai/Delete/5
        public ActionResult Delete(string id = null)
        {
            var myData = mogwaiBackend.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This deletes the mogwai sent up as a post from the mogwai delete page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Mogwai/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "")] MogwaiModel data)
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

            mogwaiBackend.Delete(data.Id);

            return RedirectToAction("Index");
        }
    }
}
