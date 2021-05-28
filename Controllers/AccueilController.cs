using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpPost , ActionName("Statistique")]
        public ActionResult Statistique_Set()
        {
           
           
             var query1 = from bc in ctx.BCSet
                         where bc.DateBC.Month.Equals(DateTime.Today.Month)
                         select bc;
               
            ViewBag.Dpns = query1.ToList().Count.ToString() ;
            
            return View();
        }
    }
}