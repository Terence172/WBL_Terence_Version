using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaZero.Views.floorsCropper
{
    public class floorsCropperController : Controller
    {
        // GET: floorsCropper
        public ActionResult Index()
        {
            return View();
        }

        // GET: floorsCropper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: floorsCropper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: floorsCropper/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: floorsCropper/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: floorsCropper/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: floorsCropper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: floorsCropper/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
