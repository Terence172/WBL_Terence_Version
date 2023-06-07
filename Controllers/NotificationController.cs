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

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            reminds reminds = db.reminds.Find(id);
            return View(reminds);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "reminds_id,reminder_title,reminder_desc,reminder_date")] reminds reminds)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing investor record based on the user_id
                reminds reminds1 = db.reminds.SingleOrDefault(i => i.reminder_id == reminds.reminder_id);

                if (reminds1 != null)
                {
                    reminds1.reminder_title = reminds.reminder_title;
                    reminds1.reminder_desc = reminds.reminder_desc;
                    reminds1.reminder_date = reminds.reminder_date;

                    db.Entry(reminds1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            return View(reminds);
        }

        [HttpPost]
        public ActionResult Create(reminds reminds)
        {
            if (ModelState.IsValid)
            {
                db.reminds.Add(reminds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reminds);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            reminds reminds = db.reminds.Find(id);
            return View(reminds);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            reminds reminds = db.reminds.Find(id);
            db.reminds.Remove(reminds);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE reminds");
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}