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
    public class CommissionController : Controller
    {
        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        // GET: CommissionSets
        public ActionResult Index()
        {
            return View(db.CommissionSet.ToList());
        }

        // GET: CommissionSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionSet commissionSet = db.CommissionSet.Find(id);
            if (commissionSet == null)
            {
                return HttpNotFound();
            }
            return View(commissionSet);
        }

        // GET: CommissionSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommissionSets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCommission,Nom,Prenom,Fonction,Affectation")] CommissionSet commissionSet)
        {
            if (ModelState.IsValid)
            {
                db.CommissionSet.Add(commissionSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commissionSet);
        }

        // GET: CommissionSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionSet commissionSet = db.CommissionSet.Find(id);
            if (commissionSet == null)
            {
                return HttpNotFound();
            }
            return View(commissionSet);
        }

        // POST: CommissionSets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCommission,Nom,Prenom,Fonction,Affectation")] CommissionSet commissionSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commissionSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commissionSet);
        }

        // GET: CommissionSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionSet commissionSet = db.CommissionSet.Find(id);
            if (commissionSet == null)
            {
                return HttpNotFound();
            }
            return View(commissionSet);
        }

        // POST: CommissionSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommissionSet commissionSet = db.CommissionSet.Find(id);
            db.CommissionSet.Remove(commissionSet);
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
