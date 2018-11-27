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
    public class StudentsController : Controller
    {
        private JECRCEntities db = new JECRCEntities();

        // GET: Students
        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.Branch).Include(s => s.FIG).Include(s => s.Login).Include(s => s.Organization);
            return View(student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult StudentDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name");
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name");
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username");
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,EmailID,RegNumber,BranchID,ParentMobilenNumber,LetterAlloted,HasApplied,IsPaid,Amount,OrganiID,FigID,LoginID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("LoginForm","Login");
            }

            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", student.BranchID);
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name", student.FigID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", student.LoginID);
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name", student.OrganiID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", student.BranchID);
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name", student.FigID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", student.LoginID);
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name", student.OrganiID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,EmailID,RegNumber,BranchID,ParentMobilenNumber,LetterAlloted,HasApplied,IsPaid,Amount,OrganiID,FigID,LoginID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", student.BranchID);
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name", student.FigID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", student.LoginID);
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name", student.OrganiID);
            return RedirectToAction("Create", "Organizations"); ;
        }
        public ActionResult EditDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", student.BranchID);
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name", student.FigID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", student.LoginID);
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name", student.OrganiID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails([Bind(Include = "ID,Name,EmailID,RegNumber,BranchID,ParentMobilenNumber,LetterAlloted,HasApplied,IsPaid,Amount,OrganiID,FigID,LoginID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StudentDetails","Students", new { id = student.ID});
            }
            ViewBag.BranchID = new SelectList(db.Branch, "ID", "Name", student.BranchID);
            ViewBag.FigID = new SelectList(db.FIG, "ID", "Name", student.FigID);
            ViewBag.LoginID = new SelectList(db.Login, "ID", "Username", student.LoginID);
            ViewBag.OrganiID = new SelectList(db.Organization, "ID", "Name", student.OrganiID);
            return RedirectToAction("Create", "Organizations"); ;
        }
        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
