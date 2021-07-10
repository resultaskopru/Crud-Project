﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud_Project.Models;

namespace Crud_Project.Controllers
{
    public class crudController : Controller
    {
        private dbcrudEntities db = new dbcrudEntities();

        
        public ActionResult Index()
        {
            return View(db.crudtablo.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crudtablo crudtablo = db.crudtablo.Find(id);
            if (crudtablo == null)
            {
                return HttpNotFound();
            }
            return View(crudtablo);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: crud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,LASTNAME,PASSWORD")] crudtablo crudtablo)
        {
            if (ModelState.IsValid)
            {
                db.crudtablo.Add(crudtablo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crudtablo);
        }

        // GET: crud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crudtablo crudtablo = db.crudtablo.Find(id);
            if (crudtablo == null)
            {
                return HttpNotFound();
            }
            return View(crudtablo);
        }

        // POST: crud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,LASTNAME,PASSWORD")] crudtablo crudtablo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crudtablo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crudtablo);
        }

        // GET: crud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crudtablo crudtablo = db.crudtablo.Find(id);
            if (crudtablo == null)
            {
                return HttpNotFound();
            }
            return View(crudtablo);
        }

        // POST: crud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            crudtablo crudtablo = db.crudtablo.Find(id);
            db.crudtablo.Remove(crudtablo);
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
