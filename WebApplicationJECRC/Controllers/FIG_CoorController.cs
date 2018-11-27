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
    public class FIG_CoorController : Controller
    {
        private JECRCEntities db = new JECRCEntities();

        // GET: FIG_Coor
        public ActionResult Index()
        {
            var fIG_Coor = db.FIG_Coor.Include(f => f.Login);
            return View(fIG_Coor.ToList());
        }
        public ActionResult ListFIGBranchCoor()
        {
            var fIG_Coor = db.FIG_Coor.Include(f => f.Login);
            return View(fIG_Coor.ToList());
        }

        // GET: FIG_Coor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            if (fIG_Coor == null)
            {
                return HttpNotFound();
            }
            return View(fIG_Coor);
        }

        // GET: FIG_Coor/Create
        public ActionResult Create()
        {
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username");
            return View();
        }

        // POST: FIG_Coor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] FIG_Coor fIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.FIG_Coor.Add(fIG_Coor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }
        public ActionResult CreateU()
        {
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username");
            return View();
        }

        // POST: FIG_Coor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateU([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] FIG_Coor fIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.FIG_Coor.Add(fIG_Coor);
                db.SaveChanges();
                return RedirectToAction("Index", "FIG_University_Coor");
            }

            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }
        // GET: FIG_Coor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            if (fIG_Coor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }

        // POST: FIG_Coor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] FIG_Coor fIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fIG_Coor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }

        public ActionResult EditU(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            if (fIG_Coor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }

        // POST: FIG_Coor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditU([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] FIG_Coor fIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fIG_Coor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FIG_University_Coor");
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", fIG_Coor.LoginID);
            return View(fIG_Coor);
        }

        // GET: FIG_Coor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            if (fIG_Coor == null)
            {
                return HttpNotFound();
            }
            return View(fIG_Coor);
        }

        // POST: FIG_Coor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            db.FIG_Coor.Remove(fIG_Coor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteU(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            if (fIG_Coor == null)
            {
                return HttpNotFound();
            }
            return View(fIG_Coor);
        }

        // POST: FIG_Coor/Delete/5
        [HttpPost, ActionName("DeleteU")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedU(int id)
        {
            FIG_Coor fIG_Coor = db.FIG_Coor.Find(id);
            db.FIG_Coor.Remove(fIG_Coor);
            db.SaveChanges();
            return RedirectToAction("Index", "FIG_University_Coor");
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
