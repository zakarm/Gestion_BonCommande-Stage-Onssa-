using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Projet_Onssa_Web_Mvc.Models;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class LectureOvController : Controller
    {

        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();
        // GET: LectureOv
        public ActionResult LectureOv()
        {
            ViewBag.Ov = new SelectList(db.OVSet, "IdOV", "NumOV");
            return View();
        }

       

    }
}