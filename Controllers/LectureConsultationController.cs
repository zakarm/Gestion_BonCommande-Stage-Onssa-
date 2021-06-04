using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Projet_Onssa_Web_Mvc.Models;

namespace Projet_Onssa_Web_Mvc.Views
{
    public class LectureConsultationController : Controller
    {
        // GET: LectureConsultation

        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();
        public ActionResult LectureConsultation()
        {
            ViewBag.Cons = new SelectList(db.ConsultationSet, "IdConsultation", "NumConsultation");
            return View();
        }

        public ActionResult RempCombo()
        {
            ViewBag.Four = new SelectList(db.ConsultationSet, "IdConsultation", "NumConsultation");
            return View();
        }
    }
}