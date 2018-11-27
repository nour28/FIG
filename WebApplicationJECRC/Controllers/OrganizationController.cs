using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationJECRC.Models;

namespace WebApplicationJECRC.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            JECRCEntities db = new JECRCEntities();
            List<Organization> organizations = db.Organization.ToList();
            ViewBag.organizationList = organizations;
            return View();
        }
    }
}