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
    public class LrgSetsController : Controller
    {
        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        // GET: LrgSets
        public ActionResult Index()
        {
            var lrgSet = db.LrgSet.Include(l => l.ParagrapheSet);
            return View(lrgSet.ToList());
        }

        // GET: LrgSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrgSet lrgSet = db.LrgSet.Find(id);
            if (lrgSet == null)
            {
                return HttpNotFound();
            }
            return View(lrgSet);
        }

        // GET: LrgSets/Create
        public ActionResult Create()
        {
            ViewBag.InfoParagraphe_NumPar = new SelectList(db.ParagrapheSet, "NumPar", "DescriptionPar");
            return View();
        }

        // POST: LrgSets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodeLrg,DescriptionLrg,NumLrg,InfoParagraphe_NumPar")] LrgSet lrgSet)
        {
            if (ModelState.IsValid)
            {
                db.LrgSet.Add(lrgSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InfoParagraphe_NumPar = new SelectList(db.ParagrapheSet, "NumPar", "DescriptionPar", lrgSet.InfoParagraphe_NumPar);
            return View(lrgSet);
        }

        // GET: LrgSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrgSet lrgSet = db.LrgSet.Find(id);
            if (lrgSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.InfoParagraphe_NumPar = new SelectList(db.ParagrapheSet, "NumPar", "DescriptionPar", lrgSet.InfoParagraphe_NumPar);
            return View(lrgSet);
        }

        // POST: LrgSets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodeLrg,DescriptionLrg,NumLrg,InfoParagraphe_NumPar")] LrgSet lrgSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lrgSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InfoParagraphe_NumPar = new SelectList(db.ParagrapheSet, "NumPar", "DescriptionPar", lrgSet.InfoParagraphe_NumPar);
            return View(lrgSet);
        }

        // GET: LrgSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrgSet lrgSet = db.LrgSet.Find(id);
            if (lrgSet == null)
            {
                return HttpNotFound();
            }
            return View(lrgSet);
        }

        // POST: LrgSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LrgSet lrgSet = db.LrgSet.Find(id);
            db.LrgSet.Remove(lrgSet);
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
