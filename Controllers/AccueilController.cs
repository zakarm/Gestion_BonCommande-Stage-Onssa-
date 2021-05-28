using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using Projet_Onssa_Web_Mvc.Models;


namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil
        public ActionResult Statistique()
        {
            return View();
        }

        [HttpPost , ActionName("Statistique")]
        public ActionResult Statistique_Set()
        {
           
           using (Onssa_Model ctx = new Onssa_Model())
            {
                var query1 = from bc in ctx.BCSet
                             where bc.DateBC.Month.Equals(DateTime.Today.Month)
                             select bc;
               
                ViewBag.dpns = query1.Count().ToString();
            }
             
            return View();
        }
    }
}