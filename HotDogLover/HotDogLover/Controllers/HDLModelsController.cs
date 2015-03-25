using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotDogLover.Models;

namespace HotDogLover.Controllers
{
    public class HDLModelsController : Controller
    {
        private HDLModelDBContext db = new HDLModelDBContext();

        // GET: HDLModels
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: HDLModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDLModel hDLModel = db.Movies.Find(id);
            if (hDLModel == null)
            {
                return HttpNotFound();
            }
            return View(hDLModel);
        }

        // GET: HDLModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HDLModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,FavoriteDog,LastAte,Date,Price,Rating")] HDLModel hDLModel)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(hDLModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hDLModel);
        }

        // GET: HDLModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDLModel hDLModel = db.Movies.Find(id);
            if (hDLModel == null)
            {
                return HttpNotFound();
            }
            return View(hDLModel);
        }

        // POST: HDLModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,FavoriteDog,LastAte,Date,Price,Rating")] HDLModel hDLModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hDLModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hDLModel);
        }

        // GET: HDLModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HDLModel hDLModel = db.Movies.Find(id);
            if (hDLModel == null)
            {
                return HttpNotFound();
            }
            return View(hDLModel);
        }

        // POST: HDLModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HDLModel hDLModel = db.Movies.Find(id);
            db.Movies.Remove(hDLModel);
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
