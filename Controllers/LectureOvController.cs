using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Projet_Onssa_Web_Mvc.Models;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;


namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class LectureOVController : Controller
    {


        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();

        // GET: OVSets
        public ActionResult Index()
        {
            var oVSet = db.OVSet.Include(o => o.InfoOP);
            return View(oVSet.ToList());
        }

        // GET: OVSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OVSet oVSet = db.OVSet.Find(id);
            if (oVSet == null)
            {
                return HttpNotFound();
            }
            return View(oVSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Export(int? id)
        {
            var query = from ov in db.OVSet
                        join op in db.OPSet on ov.InfoOP.IdOP equals op.IdOP
                        join oi in db.OISet on op.InfoOI.IdOI equals oi.IdOI
                        join fe in db.FESet on oi.InfoFE.IdFE equals fe.IdFE
                        join bc in db.BCSet on fe.InfoBC.IdBC equals bc.IdBC
                        join pvj in db.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                        join m in db.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                        m.InfoFournisseur.IdFournisseur
                        join fr in db.FournisseurSet on m.InfoFournisseur.IdFournisseur equals fr.IdFournisseur

                        where ov.IdOV == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                        select new
                        {
                            ttc = m.Ttc,
                            nom = fr.Nom,
                            compte = fr.Compte_bancaire_n,
                            numop = op.NumOP,
                            sou = ov.SousOrdonnateur,
                            tr = ov.TresorierPayeur,
                            numov = ov.NumOV,
                            banque = fr.Banque,
                        };

            ReportDocument ce = new ReportDocument();
            ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportOv.rpt"));

            if (query.FirstOrDefault() != null)
            {
                ce.SetParameterValue("ttc", query.FirstOrDefault().ttc.ToString());
                ce.SetParameterValue("nom", query.FirstOrDefault().nom.ToString());
                ce.SetParameterValue("compte", query.FirstOrDefault().compte.ToString());
                ce.SetParameterValue("numop", query.FirstOrDefault().numop.ToString());
                ce.SetParameterValue("sou", query.FirstOrDefault().sou.ToString());
                ce.SetParameterValue("tr", query.FirstOrDefault().tr.ToString());
                ce.SetParameterValue("numov", query.FirstOrDefault().numov.ToString());
                ce.SetParameterValue("banque", query.FirstOrDefault().banque.ToString());
            }
            else
            {

            }

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = ce.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
