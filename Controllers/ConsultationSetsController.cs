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
    public class ConsultationSetsController : Controller
    {
        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        // GET: ConsultationSets
        public ActionResult Index()
        {
            return View(db.ConsultationSet.ToList());
        }

        // GET: ConsultationSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSet consultationSet = db.ConsultationSet.Find(id);
            if (consultationSet == null)
            {
                return HttpNotFound();
            }
            return View(consultationSet);
        }

        // GET: ConsultationSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultationSets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConsultation,ObjetConsultation,NumConsultation")] ConsultationSet consultationSet)
        {
            if (ModelState.IsValid)
            {
                db.ConsultationSet.Add(consultationSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultationSet);
        }

        // GET: ConsultationSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSet consultationSet = db.ConsultationSet.Find(id);
            if (consultationSet == null)
            {
                return HttpNotFound();
            }
            return View(consultationSet);
        }

        // POST: ConsultationSets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConsultation,ObjetConsultation,NumConsultation")] ConsultationSet consultationSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultationSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultationSet);
        }

        // GET: ConsultationSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationSet consultationSet = db.ConsultationSet.Find(id);
            if (consultationSet == null)
            {
                return HttpNotFound();
            }
            return View(consultationSet);
        }

        // POST: ConsultationSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsultationSet consultationSet = db.ConsultationSet.Find(id);
            db.ConsultationSet.Remove(consultationSet);
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
