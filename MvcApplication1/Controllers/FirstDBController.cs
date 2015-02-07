using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAsp.Models;

namespace MvcAsp.Controllers
{
    public class FirstDBController : Controller
    {
        private context db = new context();

        //
        // GET: /FirstDB/

        public ActionResult Index()
        {
            return View(db.TRACKs.ToList());
        }

        //
        // GET: /FirstDB/Details/5

        public ActionResult Details(int id = 0)
        {
            TRACK track = db.TRACKs.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        //
        // GET: /FirstDB/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FirstDB/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TRACK track)
        {
            if (ModelState.IsValid)
            {
                db.TRACKs.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(track);
        }

        //
        // GET: /FirstDB/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TRACK track = db.TRACKs.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        //
        // POST: /FirstDB/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TRACK track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(track);
        }

        //
        // GET: /FirstDB/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TRACK track = db.TRACKs.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        //
        // POST: /FirstDB/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRACK track = db.TRACKs.Find(id);
            db.TRACKs.Remove(track);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}