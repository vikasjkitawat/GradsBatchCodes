using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResturantWebApp.Models;

namespace ResturantWebApp.Controllers
{
    public class resturantsController : Controller
    {
        private resturantDBEntities db = new resturantDBEntities();

        // GET: resturants
        public ActionResult Index()
        {
            return View(db.resturants.ToList());
        }

        // GET: resturants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resturant resturant = db.resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }

        // GET: resturants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resturants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resturantID,resturantName")] resturant resturant)
        {
            if (ModelState.IsValid)
            {
                db.resturants.Add(resturant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resturant);
        }

        // GET: resturants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resturant resturant = db.resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }

        // POST: resturants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resturantID,resturantName")] resturant resturant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resturant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resturant);
        }

        // GET: resturants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resturant resturant = db.resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }

        // POST: resturants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resturant resturant = db.resturants.Find(id);
            db.resturants.Remove(resturant);
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
