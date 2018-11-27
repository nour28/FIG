using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class FIGController : Controller
    {
        // GET: FIG
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayFIGByBranch(int id)
        {
            JECRCEntities db = new JECRCEntities();
            List<FIG> figlist = db.FIG.Where(i => i.BranchID == id).ToList();
            ViewBag.FIGs = figlist;
            var BranchDetails = db.Branch.Where(i => i.ID == id).FirstOrDefault();
            var branchName = BranchDetails.Name;
            ViewData["branchName"] = branchName;

            return View();

        }
        [HttpGet]
        public ActionResult ListOfAllFIGs()
        {
            JECRCEntities db = new JECRCEntities();

            List<FIG> Figlist = db.FIG.ToList();
            ViewBag.FIGDEtails = Figlist;

            return View();
        }
        [HttpGet]
        public ActionResult ListOfAllFIGsU()
        {
            JECRCEntities db = new JECRCEntities();

            List<FIG> Figlist = db.FIG.ToList();
            ViewBag.FIGDEtails = Figlist;

            return View();
        }
    }
}