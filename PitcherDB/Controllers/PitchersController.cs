using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PitcherDB.Models;

namespace PitcherDB.Controllers
{
    public class PitchersController : Controller
    {
        private PitchersEntities db = new PitchersEntities();

        // GET: Pitchers
        public ActionResult Index()
        {
            return View(db.Pitchers.ToList());
        }

        // GET: Pitchers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitcher pitcher = db.Pitchers.Find(id);
            if (pitcher == null)
            {
                return HttpNotFound();
            }
            return View(pitcher);
        }

        // GET: Pitchers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pitchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PitcherID,Name,Fastball,Curve,Slider,ChangeUp,Sinker,Splitter,Cutter")] Pitcher pitcher)
        {
            if (ModelState.IsValid)
            {
                db.Pitchers.Add(pitcher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pitcher);
        }

        // GET: Pitchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitcher pitcher = db.Pitchers.Find(id);
            if (pitcher == null)
            {
                return HttpNotFound();
            }
            return View(pitcher);
        }

        // POST: Pitchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PitcherID,Name,Fastball,Curve,Slider,ChangeUp,Sinker,Splitter,Cutter")] Pitcher pitcher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pitcher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pitcher);
        }

        // GET: Pitchers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitcher pitcher = db.Pitchers.Find(id);
            if (pitcher == null)
            {
                return HttpNotFound();
            }
            return View(pitcher);
        }

        // POST: Pitchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pitcher pitcher = db.Pitchers.Find(id);
            db.Pitchers.Remove(pitcher);
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
