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

        [HttpPost]
        public ActionResult Connexion(GestionCompteSet compte)
        {
             using (Onssa_ProjetEntities ctx = new Onssa_ProjetEntities())
             {
                    var user = ctx.GestionCompteSet.Where(x => x.Nom == compte.Nom && x.MotDePasse == compte.MotDePasse).FirstOrDefault();

                    if (user == null)
                    {
                        return View("Connexion", compte);

                    
                }
                    else
                    {

                        Session["UserID"] = user.Id.ToString();
                        Session["UserName"] = user.Nom.ToString();
                        return RedirectToAction("Statistique", "Accueil");
                    }
             }
        }
        
    

}
}