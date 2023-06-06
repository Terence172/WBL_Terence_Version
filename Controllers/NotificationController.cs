using AlphaZero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlphaZero.Controllers
{
    public class NotificationController : Controller
    {

        private db_roomrentalEntities db = new db_roomrentalEntities();

        // GET: Notification
        [ChildActionOnly]
        public ActionResult GetReminders()
        {
            var reminders = db.reminds.ToList();
            return PartialView("_Notifications", reminders);
        }

        // GET: User
        public ActionResult Index()
        {
            return View(db.reminds.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reminds reminds = db.reminds.Find(id);
            if (reminds == null)
            {
                return HttpNotFound();
            }
            return View(reminds);
        }

    }
}