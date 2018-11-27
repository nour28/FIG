using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class FIG_University_CoorController : Controller
    {
        // GET: FIG_University_Coor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UniversityCoordinatorDetails()
        {

            JECRCEntities db = new JECRCEntities();
            List<University_FIG_Coor> FigCoorunilist = db.University_FIG_Coor.ToList();
            ViewBag.FIGCoordDEtails = FigCoorunilist;
            return View();
        }
        [HttpGet]
        public ActionResult ProfilDetails()
        {

            JECRCEntities db = new JECRCEntities();
            List<University_FIG_Coor> FigCoorunilist = db.University_FIG_Coor.ToList();
            ViewBag.FIGCoordDEtails = FigCoorunilist;
            return View();
        }

    }
}