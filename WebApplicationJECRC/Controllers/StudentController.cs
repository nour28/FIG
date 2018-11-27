using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class StudentController : Controller
    {
        JECRCEntities db = new JECRCEntities();
        string connectionString = @"Data Source=DESKTOP-QIHH965\SQLEXPRESS;initial catalog=JECRC;integrated security=True";
        [HttpGet]
        // GET: Student
        public ActionResult Index()
        {
            JECRCEntities db = new JECRCEntities();
            List<Student> studentlist = db.Student.ToList();
            ViewBag.students = studentlist;
            return View();
        }

        public ActionResult DisplayStudentsByFIG(int id)
        {
            JECRCEntities db = new JECRCEntities();
            List<Student> studentlist = db.Student.Where(i => i.FigID == id).ToList();
            var FIGDetails = db.FIG.Where(i => i.ID == id).FirstOrDefault();
            Session["FIGID"] = FIGDetails.ID;
            ViewData["FIGID"] = FIGDetails.ID;
            ViewData["FIGName"] = FIGDetails.Name;
            ViewBag.students = studentlist;
            return View();
        }

        public ActionResult DisplayStudentsByBranch(int id)
        {
            JECRCEntities db = new JECRCEntities();
            List<Student> studentlist = db.Student.Where(i => i.BranchID == id).ToList();
            ViewBag.students = studentlist;
            return View();
        }

        public ActionResult DisplayFIGDetails(int id)
        {

            JECRCEntities db = new JECRCEntities();


            ViewData["internsNbr"] = db.Student.Where(i => i.FigID == id).Count();
            ViewData["internshipAllotedNbr"] = db.Student.Where(i => i.FigID == id && i.LetterAlloted == true).Count();
            ViewData["applied"] = db.Student.Where(i => i.FigID == id && i.HasApplied == true).Count();
            ViewData["stipened"] = db.Student.Where(i => i.FigID == id && i.IsPaid == true).Count();
            ViewData["NonStipened"] = db.Student.Where(i => i.FigID == id && i.IsPaid == false).Count();

            var Student = db.Student.Where(i => i.FigID == id).FirstOrDefault();
            var branchName = Student.Branch.Name;
            ViewData["BranchName"] = branchName;
            var FIGDetails = db.FIG.Where(i => i.ID == id).FirstOrDefault();
            ViewData["FIGID"] = FIGDetails.ID;
            List<FIG> FIGlist = db.FIG.Where(i => i.ID == id).ToList();
            ViewBag.FIGs = FIGlist;

           return View(id);


        }

        public ActionResult Add()
        {

            ViewBag.BranchList = new SelectList(GetBranchList(), "ID", "Name");
            
            return View();
            
          
        }
        public List<Branch> GetBranchList()
        {
            List<Branch> branches = db.Branch.ToList();
            return branches;
        }

        public ActionResult GetFIGs(int branchID)
        {
            List<FIG> FIGs = db.FIG.Where(x => x.BranchID == branchID).ToList();
            ViewBag.FIGList = new SelectList(FIGs, "ID", "Name");
            return PartialView("FIGListPartial");

        }

        [HttpGet]
        public ActionResult Create()
        {
            JECRCEntities db = new JECRCEntities();
            IEnumerable<SelectListItem> items = db.Branch.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.Name

            });
            ViewBag.Name = items;
            return View(new StudentModel());
        }
        
        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Organization VALUES(@Name,@Location,@Adress,@ContactNumber)";
                string query1 = "INSERT INTO Student VALUES(@Name,@EmailID,@RegNumber,@ParentMobilenNumber,@LetterAlloted,@HasApplied,@IsPaid,@Amount,@BranchID,@OrganiID,@FigID,@LoginID)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", studentModel.OrganizationName);
                sqlCmd.Parameters.AddWithValue("@Location", studentModel.Location);
                sqlCmd.Parameters.AddWithValue("@Adress", studentModel.Adress);
                sqlCmd.Parameters.AddWithValue("@ContactNumber", studentModel.ContactNumber);
                sqlCmd1.Parameters.AddWithValue("@Name", studentModel.Name);
                sqlCmd1.Parameters.AddWithValue("@EmailID", studentModel.EmailID);
                sqlCmd1.Parameters.AddWithValue("@RegNumber", studentModel.RegNumber);
                sqlCmd1.Parameters.AddWithValue("@ParentMobilenNumber", studentModel.ParentMobilenNumber);
                sqlCmd1.Parameters.AddWithValue("@LetterAlloted", studentModel.LetterAlloted);
                sqlCmd1.Parameters.AddWithValue("@HasApplied", studentModel.HasApplied);
                sqlCmd1.Parameters.AddWithValue("@IsPaid", studentModel.IsPaid);
                sqlCmd1.Parameters.AddWithValue("@Amount", studentModel.Amount);
                sqlCmd1.Parameters.AddWithValue("@BranchID", studentModel.BranchID);
                sqlCmd1.Parameters.AddWithValue("@OrganiID", studentModel.OrganiID);
                sqlCmd1.Parameters.AddWithValue("@FigID", studentModel.FigID);
                sqlCmd1.Parameters.AddWithValue("@LoginID", studentModel.LoginID);




                sqlCmd.ExecuteNonQuery();
                sqlCmd1.ExecuteNonQuery();



            }


            return RedirectToAction("index");
        }


    }
}