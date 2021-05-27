using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil
        public ActionResult Statistique()
        {
            return View();
        }
    }
}