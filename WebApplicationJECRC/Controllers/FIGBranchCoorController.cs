using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class FIGBranchCoorController : Controller
    {
        // GET: FIGBranchCoor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BranchCoordinatorDetails()
        {

            JECRCEntities db = new JECRCEntities();
            List<Branch> FigCoorlist = db.Branch.ToList();
            ViewBag.FIGCoordDEtails = FigCoorlist;
            return View();
        }
    }
}