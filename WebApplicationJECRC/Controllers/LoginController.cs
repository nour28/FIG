using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class LoginController : Controller
    {
        string conncectionString = @"Data Source=(local)\SQLExpress;Initial Catalog=JECRC;Integrated Security=True";
        public ActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(WebApplicationJECRC.Models.LoginModel loginModel)
        {
            using (JECRCEntities db = new JECRCEntities())
            {
                var loginDetails = db.Login.Where(x => x.Username == loginModel.Username && x.Password == loginModel.Password).FirstOrDefault();
                if (loginDetails == null)
                {
                    loginModel.LoadingErrorMessage = "Wrong username or password";
                    return View("LoginForm", loginModel);
                }
                else
                {
                    Session["ID"] = loginDetails.ID;


                    var FIGUniDetails = db.University_FIG_Coor.Where(x => x.LoginID == loginDetails.ID).FirstOrDefault();
                    var FIGCoorDetails = db.FIG_Coor.Where(x => x.LoginID == loginDetails.ID).FirstOrDefault();
                    var FIGDetails = db.FIG.Where(x => x.LoginID == loginDetails.ID).FirstOrDefault();
                    var studentDetails = db.Student.Where(x => x.LoginID == loginDetails.ID).FirstOrDefault();
                    if (FIGCoorDetails != null)
                    {
                        var branchDetails = db.Branch.Where(i => i.FigCorrID == FIGCoorDetails.ID).FirstOrDefault();
                        var branchID = branchDetails.ID;
                        return RedirectToAction("DisplayFIGByBranch", "FIG", new { id = branchID });
                    }
                    else if (FIGUniDetails != null)
                        return RedirectToAction("Index", "FIG_University_Coor");
                    else if (FIGDetails != null)
                    {


                        return RedirectToAction("DisplayFIGDetails", "Student", new { id = FIGDetails.ID });
                    }
                    else if (studentDetails != null)

                        return RedirectToAction("StudentDetails", "Students", new { id = studentDetails.ID });

                    else if (loginDetails.Username == "admin" && loginDetails.Password == "admin")

                        return RedirectToAction("Index", "Admin");




                }
            }
            return View();
        }

        public ActionResult logOut()
        {
            Session.Abandon();
            return RedirectToAction("LoginForm", "Login");
        }

        public ActionResult Display()
        {
            JECRCEntities db = new JECRCEntities();
            List<Login> logins = db.Login.ToList();
            ViewBag.loginList = logins;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Login login = new Login();
            return View(login);
        }
        [HttpPost]
        public ActionResult Add(Login login)
        {
            using (JECRCEntities db = new JECRCEntities())
            {if (db.Login.Any(x=> x.Username==login.Username))
                {
                    ViewBag.DuplicateMessage = "UserName already taken";
                    return View("Add", login);
                }
                db.Login.Add(login);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage="Registration successful";
            return RedirectToAction("Create","Organizations");
        }

        [HttpGet]
        public ActionResult LoginFIGUniCoor()
        {
            Login login = new Login();
            return View(login);
        }
        [HttpPost]
        public ActionResult LoginFIGUniCoor(Login login)
        {
            using (JECRCEntities db = new JECRCEntities())
            {
                if (db.Login.Any(x => x.Username == login.Username))
                {
                    ViewBag.DuplicateMessage = "UserName already taken";
                    return View("Add", login);
                }
                db.Login.Add(login);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successful";
            return RedirectToAction("Index","Logins");
        }




    }
}