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
    public class LectureBCController : Controller
    {
        private Onssa_ProjetEntities db = new Onssa_ProjetEntities();


        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();
        DataSetReport ds = new DataSetReport();
        Models.DataSetReportTableAdapters.ModeleDevisSetTableAdapter dam = new Models.DataSetReportTableAdapters.ModeleDevisSetTableAdapter();
        Models.DataSetReportTableAdapters.PVJFournisseurTableAdapter dapf = new Models.DataSetReportTableAdapters.PVJFournisseurTableAdapter();
        Models.DataSetReportTableAdapters.ModeleDevisProduitTableAdapter dap = new Models.DataSetReportTableAdapters.ModeleDevisProduitTableAdapter();
        Models.DataSetReportTableAdapters.ProduitSetTableAdapter dapr = new Models.DataSetReportTableAdapters.ProduitSetTableAdapter();

        // GET: BCSets
        public ActionResult Index()
        {
            dapf.Fill(ds.PVJFournisseur);
            dam.Fill(ds.ModeleDevisSet);
            dap.Fill(ds.ModeleDevisProduit);
            var bCSet = db.BCSet.Include(b => b.InfoMorasse).Include(b => b.InfoPVJ);
            return View(bCSet.ToList());
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

                var query = from bc in ctx.BCSet
                            join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                            join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                            m.InfoFournisseur.IdFournisseur
                            where bc.IdBC == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                            select new
                            {
                                AdresseFour = m.InfoFournisseur.Adresse,
                                Cnss = m.InfoFournisseur.CNSS_n,
                                Ifn = m.InfoFournisseur.IF_n,
                                Patente = m.InfoFournisseur.Patente_n,
                                NumBc = bc.NumBc,
                                NomFr = m.InfoFournisseur.Nom,
                                Code = bc.InfoMorasse.CodeMorasse,
                                Objet = m.InfoConsultation.ObjetConsultation,
                                Exercice = bc.InfoMorasse.Exercice,
                                Compte = m.InfoFournisseur.Compte_bancaire_n,
                                Lrg = bc.InfoMorasse.Ligne.InfoLrg.NumLrg,
                                Par = bc.InfoMorasse.Ligne.InfoLrg.InfoParagraphe.NumPar,
                                Ligne = bc.InfoMorasse.Ligne.CodeLigne,
                                NumPvj = pvj.IdPVJ,
                                NumCon = pvj.InfoConsultation.IdConsultation,
                                Budget = bc.InfoMorasse.Budget,
                                Rc = m.InfoFournisseur.RC_n,
                                Ice = m.InfoFournisseur.ICE,
                                NumDevis = m.NumDevis,
                                IdDevis = m.IdModeleDevis,
                                Tva = m.Tva,
                                Ttc = m.Ttc,
                                thc = m.Total,
                                DateBc = bc.DateBC,

                            };

                ReportDocument ce = new ReportDocument();
                ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportBC.rpt"));

                if (query.FirstOrDefault() != null)
                {
                    int NumDevis = int.Parse(query.FirstOrDefault().IdDevis.ToString());
                    NumToString cc = new NumToString();
                    dapr.FillByMd(ds.ProduitSet, NumDevis);
                    ce.SetDataSource(ds);
                    ce.SetParameterValue("numdevis", query.FirstOrDefault().NumDevis.ToString());
                    ce.SetParameterValue("ice", query.FirstOrDefault().Ice.ToString());
                    ce.SetParameterValue("rc", query.FirstOrDefault().Rc.ToString());
                    ce.SetParameterValue("budget", query.FirstOrDefault().Budget.ToString());
                    ce.SetParameterValue("if", query.FirstOrDefault().Ifn.ToString());
                    ce.SetParameterValue("cnss", query.FirstOrDefault().Cnss.ToString());
                    ce.SetParameterValue("patente", query.FirstOrDefault().Patente.ToString());
                    ce.SetParameterValue("lrg", query.FirstOrDefault().Lrg.ToString());
                    ce.SetParameterValue("par", query.FirstOrDefault().Par.ToString());
                    ce.SetParameterValue("ligne", query.FirstOrDefault().Ligne.ToString());
                    ce.SetParameterValue("numbc", query.FirstOrDefault().NumBc.ToString());
                    ce.SetParameterValue("nom", query.FirstOrDefault().NomFr.ToString());
                    ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                    ce.SetParameterValue("exercice", query.FirstOrDefault().Exercice.ToString());
                    ce.SetParameterValue("compte", query.FirstOrDefault().Compte.ToString());
                    ce.SetParameterValue("adresse", query.FirstOrDefault().AdresseFour.ToString());
                    ce.SetParameterValue("thc", query.FirstOrDefault().thc.ToString());
                    ce.SetParameterValue("tva", query.FirstOrDefault().Tva.ToString());
                    ce.SetParameterValue("ttc", query.FirstOrDefault().Ttc.ToString());
                    ce.SetParameterValue("datebc", query.FirstOrDefault().DateBc.ToString());
                    ce.SetParameterValue("numm", cc.virgule(query.FirstOrDefault().Ttc.ToString()));
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                }

                Stream stream = ce.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);

                return new FileStreamResult(stream, "application/pdf");

        }
    }
}
