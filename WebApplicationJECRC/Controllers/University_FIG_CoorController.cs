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
    public class University_FIG_CoorController : Controller
    {
        private JECRCEntities db = new JECRCEntities();

        // GET: University_FIG_Coor
        public ActionResult Index()
        {
            var university_FIG_Coor = db.University_FIG_Coor.Include(u => u.Login);
            return View(university_FIG_Coor.ToList());
        }

        // GET: University_FIG_Coor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University_FIG_Coor university_FIG_Coor = db.University_FIG_Coor.Find(id);
            if (university_FIG_Coor == null)
            {
                return HttpNotFound();
            }
            return View(university_FIG_Coor);
        }

        // GET: University_FIG_Coor/Create
        public ActionResult Create()
        {
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username");
            return View();
        }

        // POST: University_FIG_Coor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] University_FIG_Coor university_FIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.University_FIG_Coor.Add(university_FIG_Coor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", university_FIG_Coor.LoginID);
            return View(university_FIG_Coor);
        }

        // GET: University_FIG_Coor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University_FIG_Coor university_FIG_Coor = db.University_FIG_Coor.Find(id);
            if (university_FIG_Coor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", university_FIG_Coor.LoginID);
            return View(university_FIG_Coor);
        }

        // POST: University_FIG_Coor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] University_FIG_Coor university_FIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university_FIG_Coor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", university_FIG_Coor.LoginID);
            return View(university_FIG_Coor);
        }


        public ActionResult EditDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University_FIG_Coor university_FIG_Coor = db.University_FIG_Coor.Find(id);
            if (university_FIG_Coor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", university_FIG_Coor.LoginID);
            return View(university_FIG_Coor);
        }

        // POST: University_FIG_Coor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails([Bind(Include = "ID,LoginID,Name,EmailID,PhoneNumber")] University_FIG_Coor university_FIG_Coor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university_FIG_Coor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","FIG_University_Coor");
            }
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", university_FIG_Coor.LoginID);
            return View(university_FIG_Coor);
        }

        // GET: University_FIG_Coor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University_FIG_Coor university_FIG_Coor = db.University_FIG_Coor.Find(id);
            if (university_FIG_Coor == null)
            {
                return HttpNotFound();
            }
            return View(university_FIG_Coor);
        }

        // POST: University_FIG_Coor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            University_FIG_Coor university_FIG_Coor = db.University_FIG_Coor.Find(id);
            db.University_FIG_Coor.Remove(university_FIG_Coor);
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
