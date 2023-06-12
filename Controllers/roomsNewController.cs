using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaZero.Models;
using Newtonsoft.Json;

namespace AlphaZero.Controllers
{
    public class roomsNewController : Controller
    {
        private db_roomrentalEntities db = new db_roomrentalEntities();

        // GET: roomsNew
        // GET: roomsNew
        public ActionResult Index()
        {
            var rooms = db.rooms.Include(r => r.floor).ToList();

            foreach (var room in rooms)
            {
                var roomCoordinate = JsonConvert.DeserializeObject<dynamic>(room.room_coordinate);

                var roomTop = roomCoordinate.resizableTop;
                var roomLeft = roomCoordinate.resizableLeft;
                var roomWidth = roomCoordinate.resizableWidth;
                var roomHeight = roomCoordinate.resizableHeight;

                room.resizableTop = roomTop;
                room.resizableLeft = roomLeft;
                room.resizableWidth = roomWidth;
                room.resizableHeight = roomHeight;

            }

            return View(rooms);
        }


        // GET: roomsNew/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: roomsNew/Create
        public ActionResult Create()
        {
            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr");
            return View();
        }

        // POST: roomsNew/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "room_id,floor_id,room_price,room_status")] room room)
        {
            if (ModelState.IsValid)
            {
                db.rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr", room.floor_id);
            return View(room);
        }

        // GET: roomsNew/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr", room.floor_id);
            return View(room);
        }

        // POST: roomsNew/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "room_id,floor_id,room_price,room_status")] room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr", room.floor_id);
            return View(room);
        }

        // GET: roomsNew/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: roomsNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            room room = db.rooms.Find(id);
            db.rooms.Remove(room);
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
