using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaZero.Models;

namespace AlphaZero.Controllers
{
    public class floorsCropperController : Controller
    {
        private db_roomrentalEntities db = new db_roomrentalEntities();

        // GET: floorsCropper
        public ActionResult Index()
        {
            var floors = db.floors.Include(f => f.landlord);
            return View(floors.ToList());
        }

        // GET: floorsCropper/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floor floor = db.floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // GET: floorsCropper/Create
        public ActionResult Create()
        {
            ViewBag.landlord_id = new SelectList(db.landlords, "landlord_id", "landlord_name");
            return View();
        }

        // POST: floorsCropper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "floor_id,floor_modemIP,floor_cctvQr,floor_layout,landlord_id")] floor floor)
        {
            if (ModelState.IsValid)
            {
                db.floors.Add(floor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.landlord_id = new SelectList(db.landlords, "landlord_id", "landlord_name", floor.landlord_id);
            return View(floor);
        }

        // GET: floorsCropper/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floor floor = db.floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            ViewBag.landlord_id = new SelectList(db.landlords, "landlord_id", "landlord_name", floor.landlord_id);
            return View(floor);
        }

        // POST: floorsCropper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "floor_id,floor_modemIP,floor_cctvQr,floor_layout,landlord_id")] floor floor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.landlord_id = new SelectList(db.landlords, "landlord_id", "landlord_name", floor.landlord_id);
            return View(floor);
        }

        // GET: floorsCropper/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            floor floor = db.floors.Find(id);
            if (floor == null)
            {
                return HttpNotFound();
            }
            return View(floor);
        }

        // POST: floorsCropper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            floor floor = db.floors.Find(id);
            db.floors.Remove(floor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
