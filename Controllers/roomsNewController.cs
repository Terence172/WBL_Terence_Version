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


        public ActionResult ChangeRoom(string floorId)
        {
            var room = db.rooms.FirstOrDefault(r => r.floor_id == floorId);
            if (room != null)
            {
                var newLayout = room.floor.floor_layout;
                TempData["NewLayout"] = newLayout;
                TempData["FloorID"] = floorId; // Store the selected floorId in ViewBag
            }
            else
            {
                TempData["NewLayout"] = null;
                TempData["FloorID"] = null;
            }

            return RedirectToAction("Index");
        }




        // GET: roomsNew/Details/5
        public ActionResult Details(int id, string floorId)
        {

            // Store the floorId in the ViewBag
            ViewBag.FloorID = floorId;

            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr");

            var room1 = db.rooms.FirstOrDefault(r => r.floor_id == floorId);



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            room room = db.rooms.Find(id);
            var newLayout = room1.floor.floor_layout;
            TempData["NewLayout"] = newLayout;

            if (room == null)
            {
                return HttpNotFound();
            }

            var roomCoordinate = JsonConvert.DeserializeObject<dynamic>(room.room_coordinate);

            var roomTop = roomCoordinate.resizableTop;
            var roomLeft = roomCoordinate.resizableLeft;
            var roomWidth = roomCoordinate.resizableWidth;
            var roomHeight = roomCoordinate.resizableHeight;

            room.resizableTop = roomTop;
            room.resizableLeft = roomLeft;
            room.resizableWidth = roomWidth;
            room.resizableHeight = roomHeight;

            return View(room);
        }





        public ActionResult Create(string floorId)
        {
            // Use the floorId parameter as needed in your code

            // Store the floorId in the ViewBag
            ViewBag.FloorID = floorId;

            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr");

            var room = db.rooms.FirstOrDefault(r => r.floor_id == floorId);

            if (room != null)
            {
                var newLayout = room.floor.floor_layout;
                TempData["NewLayout"] = newLayout;
            }
            else
            {
                TempData["NewLayout"] = null;
            }

            return View();
        }


        // POST: roomsNew/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "room_id,room_name,room_status,floor_id,room_price,room_coordinate")] room room)
        {
            if (ModelState.IsValid)
            {

                db.rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }





        // GET: roomsNew/Edit/5
        public ActionResult Edit(int id, string floorId)
        {

            // Store the floorId in the ViewBag
            ViewBag.FloorID = floorId;

            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr");

            var room1 = db.rooms.FirstOrDefault(r => r.floor_id == floorId);


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            room room = db.rooms.Find(id);
            var newLayout = room1.floor.floor_layout;
            TempData["NewLayout"] = newLayout;

            if (room == null)
            {
                return HttpNotFound();
            }

            var roomCoordinate = JsonConvert.DeserializeObject<dynamic>(room.room_coordinate);

            var roomTop = roomCoordinate.resizableTop;
            var roomLeft = roomCoordinate.resizableLeft;
            var roomWidth = roomCoordinate.resizableWidth;
            var roomHeight = roomCoordinate.resizableHeight;

            room.resizableTop = roomTop;
            room.resizableLeft = roomLeft;
            room.resizableWidth = roomWidth;
            room.resizableHeight = roomHeight;

            return View(room);
        }


        // POST: roomsNew/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "room_id,room_name,room_status,floor_id,room_price,room_coordinate")] room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }



        // GET: roomsNew/Delete/5
        public ActionResult Delete(int id, string floorId)
        {
            // Store the floorId in the ViewBag
            ViewBag.FloorID = floorId;

            ViewBag.floor_id = new SelectList(db.floors, "floor_id", "floor_cctvQr");

            var room1 = db.rooms.FirstOrDefault(r => r.floor_id == floorId);


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            room room = db.rooms.Find(id);
            var newLayout = room1.floor.floor_layout;
            TempData["NewLayout"] = newLayout;


            if (room == null)
            {
                return HttpNotFound();
            }
            

            var roomCoordinate = JsonConvert.DeserializeObject<dynamic>(room.room_coordinate);

            var roomTop = roomCoordinate.resizableTop;
            var roomLeft = roomCoordinate.resizableLeft;
            var roomWidth = roomCoordinate.resizableWidth;
            var roomHeight = roomCoordinate.resizableHeight;

            room.resizableTop = roomTop;
            room.resizableLeft = roomLeft;
            room.resizableWidth = roomWidth;
            room.resizableHeight = roomHeight;

            return View(room);
            
        }





        // POST: roomsNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
