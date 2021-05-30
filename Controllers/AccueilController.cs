using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projet_Onssa_Web_Mvc.Models;


namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class AccueilController : Controller
    {
        Onssa_Model ctx = new Onssa_Model();
        // GET: Accueil
        [HttpGet]
        public ActionResult Statistique()
        {
            //
            var query1 = from bc in ctx.BCSet
                         where bc.DateBC.Month.Equals(DateTime.Today.Month)
                         select bc;
            ViewBag.Dpns =query1.ToList().Count.ToString();

            //
            var data = from bc in ctx.BCSet
                       join pvj in ctx.PVJSet on bc.PVJSet.IdPVJ equals pvj.IdPVJ
                       join m in ctx.ModeleDevisSet on pvj.FournisseurSet.IdFournisseur equals
                       m.FournisseurSet.IdFournisseur
                       where m.ConsultationSet.IdConsultation == pvj.ConsultationSet.IdConsultation && bc.DateBC.Month.Equals(DateTime.Today.Month)
                       orderby bc.DateBC.Month ascending
                       select m;
            ViewBag.t=data.AsEnumerable().Sum(o => o.Ttc);

            //Fournisseur li repondaw had chhar 
            using(SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KCK4EL9\SQLEXPRESS;Initial Catalog=Onssa_Projet;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from FournisseurSet f inner join PVJSet pvj on f.IdFournisseur = pvj.InfoFournisseur_IdFournisseur inner join BCSet bc on pvj.IdPVJ = bc.IdBC where f.IdFournisseur in (select distinct pf.ListFournisseursRepondu_IdFournisseur from PVJFournisseur pf ) and month(bc.DateBC) = MONTH( GETDATE())", con);
                con.Open();
                string count = cmd.ExecuteScalar().ToString();
                con.Close();

                ViewBag.count = count;
            }


            return View();
        }
       
    }
}