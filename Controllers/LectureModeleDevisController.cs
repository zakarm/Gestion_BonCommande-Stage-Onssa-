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

namespace Projet_Onssa_Web_Mvc.Models
{
    public class LectureModeleDevisController : Controller
    {
        private Onssa_ProjetEntities ctx= new Onssa_ProjetEntities();
        DataSetReport ds = new DataSetReport();

        DataSetReportTableAdapters.ModeleDevisSetTableAdapter dam = new DataSetReportTableAdapters.ModeleDevisSetTableAdapter();
        DataSetReportTableAdapters.PVJFournisseurTableAdapter dapf = new DataSetReportTableAdapters.PVJFournisseurTableAdapter();
        DataSetReportTableAdapters.ModeleDevisProduitTableAdapter dap = new DataSetReportTableAdapters.ModeleDevisProduitTableAdapter();
        DataSetReportTableAdapters.ProduitSetTableAdapter dapr = new DataSetReportTableAdapters.ProduitSetTableAdapter();

        // GET: ModeleDevisSets
        public ActionResult Index()
        {
            dapf.Fill(ds.PVJFournisseur);
            dam.Fill(ds.ModeleDevisSet);
            dap.Fill(ds.ModeleDevisProduit);
            var modeleDevisSet = ctx.ModeleDevisSet.Include(m => m.InfoConsultation).Include(m => m.InfoFournisseur);
            return View(modeleDevisSet.ToList());
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


            var query = from m in ctx.ModeleDevisSet
                        where m.IdModeleDevis == id
                        select new
                        {
                            AdresseFour = m.InfoFournisseur.Adresse,
                            Cnss = m.InfoFournisseur.CNSS_n,
                            Ifn = m.InfoFournisseur.IF_n,
                            Patente = m.InfoFournisseur.Patente_n,
                            NomFr = m.InfoFournisseur.Nom,
                            Objet = m.InfoConsultation.ObjetConsultation,
                            Compte = m.InfoFournisseur.Compte_bancaire_n,
                            Rc = m.InfoFournisseur.RC_n,
                            Ice = m.InfoFournisseur.ICE,
                            NumDevis = m.NumDevis,
                            IdDevis = m.IdModeleDevis,
                            Tva = m.Tva,
                            Ttc = m.Ttc,
                            thc = m.Total,
                            DateDevis = m.Date,
                            NumCon = m.InfoConsultation.NumConsultation,

                        };


           
           

            ReportDocument ce = new ReportDocument();
            ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportMd.rpt"));

            if (query.FirstOrDefault() != null)
            {
                int NumDevis = int.Parse(query.FirstOrDefault().IdDevis.ToString());
                NumToString cc = new NumToString();
                dapr.FillByMd(ds.ProduitSet, NumDevis);
                ce.SetDataSource(ds);
                ce.SetParameterValue("numdevis", query.FirstOrDefault().NumDevis.ToString());
                //ce.SetParameterValue("ice", query.FirstOrDefault().Ice.ToString());
                ce.SetParameterValue("rc", query.FirstOrDefault().Rc.ToString());
                ce.SetParameterValue("if", query.FirstOrDefault().Ifn.ToString());
                ce.SetParameterValue("cnss", query.FirstOrDefault().Cnss.ToString());
                ce.SetParameterValue("patente", query.FirstOrDefault().Patente.ToString());
                ce.SetParameterValue("nom", query.FirstOrDefault().NomFr.ToString());
                ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                ce.SetParameterValue("compte", query.FirstOrDefault().Compte.ToString());
                ce.SetParameterValue("adresse", query.FirstOrDefault().AdresseFour.ToString());
                ce.SetParameterValue("thc", query.FirstOrDefault().thc.ToString());
                ce.SetParameterValue("tva", query.FirstOrDefault().Tva.ToString());
                ce.SetParameterValue("ttc", query.FirstOrDefault().Ttc.ToString());
                ce.SetParameterValue("datedevis", query.FirstOrDefault().DateDevis.ToString());
                ce.SetParameterValue("numcon", query.FirstOrDefault().NumCon.ToString());
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
