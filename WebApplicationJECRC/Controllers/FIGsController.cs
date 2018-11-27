using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class FIGsController : Controller
    {
        private JECRCEntities db = new JECRCEntities();

        // GET: FIGs
        public ActionResult Index()
        {
            var fIG = db.FIG.Include(f => f.Branch).Include(f => f.Login);
            return View(fIG.ToList());
        }

        // GET: FIGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG fIG = db.FIG.Find(id);
            if (fIG == null)
            {
                return HttpNotFound();
            }
            return View(fIG);
        }

        // GET: FIGs/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name");
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username");
            return View();
        }

        // POST: FIGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,EmailID,BranchID,internsNbr,LetterAlloted,Applied,Stipened,NoFeesNoStippend,StudentPaid,Confirmed,LoginID")] FIG fIG)
        {
            if (ModelState.IsValid)
            {
                db.FIG.Add(fIG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", fIG.BranchID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG.LoginID);
            return View(fIG);
        }

        // GET: FIGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG fIG = db.FIG.Find(id);
            if (fIG == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", fIG.BranchID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG.LoginID);
            return View(fIG);
        }

        // POST: FIGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,EmailID,BranchID,internsNbr,LetterAlloted,Applied,Stipened,NoFeesNoStippend,StudentPaid,Confirmed,LoginID")] FIG fIG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fIG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", fIG.BranchID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG.LoginID);
            return View(fIG);
        }

        // GET: FIGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG fIG = db.FIG.Find(id);
            if (fIG == null)
            {
                return HttpNotFound();
            }
            return View(fIG);
        }

        // POST: FIGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FIG fIG = db.FIG.Find(id);
            db.FIG.Remove(fIG);
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
