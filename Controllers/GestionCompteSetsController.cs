using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Onssa_Web_Mvc.Models;

namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class GestionCompteSetsController : Controller
    {
        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        // GET: GestionCompteSets
        public ActionResult Index()
        {
            return View(db.GestionCompteSet.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,MotDePasse,TypeCompte")] GestionCompteSet gestionCompteSet)
        {
            if (ModelState.IsValid)
            {
                db.GestionCompteSet.Add(gestionCompteSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gestionCompteSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
