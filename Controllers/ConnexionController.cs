using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projet_Onssa_Web_Mvc.Models;

namespace Projet_Onssa_Web_Mvc.Controllers
{


    public class ConnexionController : Controller
    {
        // GET: Connexion

        Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();
        public ActionResult Connexion()
        {
            return View();
        }


    }
}