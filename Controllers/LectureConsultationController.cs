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


namespace Projet_Onssa_Web_Mvc.Views
{
    public class LectureConsultationController : Controller
    {
        // GET: LectureConsultation

        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        DataSetReport ds = new DataSetReport();

        Models.DataSetReportTableAdapters.ConsultationSetTableAdapter dac = new Models.DataSetReportTableAdapters.ConsultationSetTableAdapter();
        Models.DataSetReportTableAdapters.ConsultationFournisseurTableAdapter dacf = new Models.DataSetReportTableAdapters.ConsultationFournisseurTableAdapter();
        Models.DataSetReportTableAdapters.FournisseurSetTableAdapter daf = new Models.DataSetReportTableAdapters.FournisseurSetTableAdapter();

        public ActionResult LectureConsultation()
        {
            ViewBag.Cons = new SelectList(db.ConsultationSet, "IdConsultation", "NumConsultation");
            return View();
        }


        public ActionResult GetFList(int? IdCOn)
        {

            var query = from f in ds.FournisseurSet
                        join c in ds.ConsultationFournisseur
                        on f.IdFournisseur equals c.ListFournisseur_IdFournisseur
                        where c.ListConsultation_IdConsultation == IdCOn
                        select f;
            ViewBag.Four = new SelectList(query.ToList(), "IdFournisseur", "Nom");
            return View();

        }
    }
}