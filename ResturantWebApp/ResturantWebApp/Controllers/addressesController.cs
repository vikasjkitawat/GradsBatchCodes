﻿using System;
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
    public class addressesController : Controller
    {
        private resturantDBEntities db = new resturantDBEntities();

        // GET: addresses
        public ActionResult Index()
        {
            var addresses = db.addresses.Include(a => a.resturant);
            return View(addresses.ToList());
        }

        // GET: addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: addresses/Create
        public ActionResult Create()
        {
            ViewBag.resturantID = new SelectList(db.resturants, "resturantID", "resturantName");
            return View();
        }

        // POST: addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "addressID,street,city,states,resturantID")] address address)
        {
            if (ModelState.IsValid)
            {
                db.addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resturantID = new SelectList(db.resturants, "resturantID", "resturantName", address.resturantID);
            return View(address);
        }

        // GET: addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.resturantID = new SelectList(db.resturants, "resturantID", "resturantName", address.resturantID);
            return View(address);
        }

        // POST: addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "addressID,street,city,states,resturantID")] address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resturantID = new SelectList(db.resturants, "resturantID", "resturantName", address.resturantID);
            return View(address);
        }

        // GET: addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            address address = db.addresses.Find(id);
            db.addresses.Remove(address);
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
