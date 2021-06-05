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


namespace Projet_Onssa_Web_Mvc.Views
{
    public class LectureOPController : Controller
    {
        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();

        // GET: OPSets
        public ActionResult Index()
        {
            var oPSet = ctx.OPSet.Include(o => o.InfoOI);
            return View(oPSet.ToList());
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
            var query = from op in ctx.OPSet
                        join oi in ctx.OISet on op.InfoOI.IdOI equals oi.IdOI
                        join fe in ctx.FESet on oi.InfoFE.IdFE equals fe.IdFE
                        join bc in ctx.BCSet on fe.InfoBC.IdBC equals bc.IdBC
                        join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                        join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                        m.InfoFournisseur.IdFournisseur
                        join fr in ctx.FournisseurSet on m.InfoFournisseur.IdFournisseur equals fr.IdFournisseur
                        join pvr in ctx.PVRSet on oi.IdOI equals pvr.IdPVR
                        where op.IdOP == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                        select new
                        {
                            total = m.Ttc,
                            NumBc = bc.NumBc,
                            NomFr = fr.Nom,
                            idoi = oi.IdOI,
                            NumOi = oi.NumOi,
                            DateBc = bc.DateBC,
                            NumCompte = oi.NumCompteDebit,
                            DateOi = oi.DateOI,
                            NumOp = op.NumOP,
                            Code = bc.InfoMorasse.CodeMorasse,
                            DateOp = op.DateOP,
                            Objet = m.InfoConsultation.ObjetConsultation,
                            Exercice = bc.InfoMorasse.Exercice,
                            Compte = fr.Compte_bancaire_n,
                            DatePvr = pvr.DatePVR,
                            VisaContol = oi.VisaControle,
                            Visacsrs = oi.VisaCsrs,
                            DatePaiement = oi.DatePaiement,
                            VisaSousOrdo = oi.VisaSordonnateur,
                            VisaTresorier = oi.VisaTresorierPayeur,

                        };
            
            NumToString cc = new NumToString();
            ReportDocument ce = new ReportDocument();
            

            if (query.FirstOrDefault() != null)
            {
                
                ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportOp.rpt"));
                ce.SetParameterValue("ttc", query.FirstOrDefault().total.ToString());
                ce.SetParameterValue("numbc", query.FirstOrDefault().NumBc.ToString());
                ce.SetParameterValue("nomfr", query.FirstOrDefault().NomFr.ToString());
                ce.SetParameterValue("numoi", query.FirstOrDefault().NumOi.ToString());
                ce.SetParameterValue("numcompte", query.FirstOrDefault().NumCompte.ToString());
                ce.SetParameterValue("dateoi", query.FirstOrDefault().DateOi.ToString());
                ce.SetParameterValue("numop", query.FirstOrDefault().NumOp.ToString());
                ce.SetParameterValue("code", query.FirstOrDefault().Code.ToString());
                ce.SetParameterValue("dateop", query.FirstOrDefault().DateOp.ToString());
                ce.SetParameterValue("datebc", query.FirstOrDefault().DateBc.ToString());
                ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                ce.SetParameterValue("exercice", query.FirstOrDefault().Exercice.ToString());
                ce.SetParameterValue("compte", query.FirstOrDefault().Compte.ToString());
                ce.SetParameterValue("datepvr", query.FirstOrDefault().DatePvr.ToString());
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
