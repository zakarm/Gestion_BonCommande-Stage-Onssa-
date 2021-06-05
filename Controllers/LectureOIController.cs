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
using Projet_Onssa_Web_Mvc.Controllers;


namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class LectureOIController : Controller
    {
        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();

        // GET: OISets
        public ActionResult Index()
        {
            var oISet = ctx.OISet.Include(o => o.InfoFE);
            return View(oISet.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Export(int? id)
        {
            var query = from oi in ctx.OISet
                        join fe in ctx.FESet on oi.InfoFE.IdFE equals fe.IdFE
                        join bc in ctx.BCSet on fe.InfoBC.IdBC equals bc.IdBC
                        join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                        join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                        m.InfoFournisseur.IdFournisseur
                        where oi.IdOI == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                        select new
                        {
                            total = m.Ttc,
                            NumBc = bc.NumBc,
                            NomFr = m.InfoFournisseur.Nom,
                            idoi = oi.IdOI,
                            NumOi = oi.NumOi,
                            DateBc = bc.DateBC,
                            NumCompte = oi.NumCompteDebit,
                            DateOi = oi.DateOI,
                            Code = bc.InfoMorasse.CodeMorasse,
                            Objet = m.InfoConsultation.ObjetConsultation,
                            Exercice = bc.InfoMorasse.Exercice,
                            Compte = m.InfoFournisseur.Compte_bancaire_n,
                            VisaContol = oi.VisaControle,
                            Visacsrs = oi.VisaCsrs,
                            DatePaiement = oi.DatePaiement,
                            VisaSousOrdo = oi.VisaSordonnateur,
                            VisaTresorier = oi.VisaTresorierPayeur,
                            Lrg = bc.InfoMorasse.Ligne.InfoLrg.NumLrg,
                            Par = bc.InfoMorasse.Ligne.InfoLrg.InfoParagraphe.NumPar,
                            Ligne = bc.InfoMorasse.Ligne.CodeLigne,

                        };

            NumToString cc = new NumToString();
            ReportDocument ce = new ReportDocument();


            if (query.FirstOrDefault() != null)
            {

                ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportOi.rpt"));
                ce.SetParameterValue("lrg", query.FirstOrDefault().Lrg.ToString());
                ce.SetParameterValue("par", query.FirstOrDefault().Par.ToString());
                ce.SetParameterValue("ligne", query.FirstOrDefault().Ligne.ToString());
                ce.SetParameterValue("ttc", query.FirstOrDefault().total.ToString());
                ce.SetParameterValue("numbc", query.FirstOrDefault().NumBc.ToString());
                ce.SetParameterValue("nomfr", query.FirstOrDefault().NomFr.ToString());
                ce.SetParameterValue("numoi", query.FirstOrDefault().NumOi.ToString());
                ce.SetParameterValue("numcompte", query.FirstOrDefault().NumCompte.ToString());
                ce.SetParameterValue("dateoi", query.FirstOrDefault().DateOi.ToString());
                ce.SetParameterValue("datebc", query.FirstOrDefault().DateBc.ToString());
                ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                ce.SetParameterValue("exercice", query.FirstOrDefault().Exercice.ToString());
                ce.SetParameterValue("compte", query.FirstOrDefault().Compte.ToString());
                ce.SetParameterValue("lettre", cc.virgule(query.FirstOrDefault().total.ToString()));
                ce.SetParameterValue("visacontrol", query.FirstOrDefault().VisaContol.ToString());
                ce.SetParameterValue("visacsrs", query.FirstOrDefault().Visacsrs.ToString());
                ce.SetParameterValue("datepaiement", query.FirstOrDefault().DatePaiement.ToString());
                ce.SetParameterValue("visasous", query.FirstOrDefault().VisaSousOrdo.ToString());
                ce.SetParameterValue("visatr", query.FirstOrDefault().VisaTresorier.ToString());
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

            }
            else
            {

            }

            Stream stream = ce.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "application/pdf");

        }
    }
}
