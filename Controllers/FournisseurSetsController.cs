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
    public class FournisseurSetsController : Controller
    {
        private Onssa_Model db = new Onssa_Model();

        // GET: FournisseurSets
        public ActionResult Index()
        {
            return View(db.FournisseurSet.ToList());
        }

        // GET: FournisseurSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FournisseurSet fournisseurSet = db.FournisseurSet.Find(id);
            if (fournisseurSet == null)
            {
                return HttpNotFound();
            }
            return View(fournisseurSet);
        }

        // GET: FournisseurSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FournisseurSets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFournisseur,Nom,Adresse,RC_n,Patente_n,IF_n,CNSS_n,Compte_bancaire_n,ICE,Ville,Banque")] FournisseurSet fournisseurSet)
        {
            if (ModelState.IsValid)
            {
                db.FournisseurSet.Add(fournisseurSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fournisseurSet);
        }

        // GET: FournisseurSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FournisseurSet fournisseurSet = db.FournisseurSet.Find(id);
            if (fournisseurSet == null)
            {
                return HttpNotFound();
            }
            return View(fournisseurSet);
        }

        // POST: FournisseurSets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFournisseur,Nom,Adresse,RC_n,Patente_n,IF_n,CNSS_n,Compte_bancaire_n,ICE,Ville,Banque")] FournisseurSet fournisseurSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fournisseurSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fournisseurSet);
        }

        // GET: FournisseurSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FournisseurSet fournisseurSet = db.FournisseurSet.Find(id);
            if (fournisseurSet == null)
            {
                return HttpNotFound();
            }
            return View(fournisseurSet);
        }

        // POST: FournisseurSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FournisseurSet fournisseurSet = db.FournisseurSet.Find(id);
            db.FournisseurSet.Remove(fournisseurSet);
            db.SaveChanges();
            return RedirectToAction("Index");
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
