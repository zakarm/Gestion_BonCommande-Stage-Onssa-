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
    public class LecturePVRController : Controller
    {
        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();
        DataSetReport ds = new DataSetReport();
        Models.DataSetReportTableAdapters.CommissionPVRTableAdapter dacp = new Models.DataSetReportTableAdapters.CommissionPVRTableAdapter();
        Models.DataSetReportTableAdapters.CommissionSetTableAdapter dac = new Models.DataSetReportTableAdapters.CommissionSetTableAdapter();
        Models.DataSetReportTableAdapters.PVRSetTableAdapter dapvr = new Models.DataSetReportTableAdapters.PVRSetTableAdapter();

        // GET: PVRSets
        public ActionResult Index()
        {
            var pVRSet = ctx.PVRSet.Include(p => p.InfoOI);
            return View(pVRSet.ToList());
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
            var query = from pvr in ctx.PVRSet
                        join oi in ctx.OISet on pvr.InfoOI.IdOI equals oi.IdOI
                        join fe in ctx.FESet on oi.InfoFE.IdFE equals fe.IdFE
                        join bc in ctx.BCSet on fe.InfoBC.IdBC equals bc.IdBC
                        join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                        join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                        m.InfoFournisseur.IdFournisseur
                        where pvr.IdPVR == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                        select new
                        {
                            NumBc = bc.NumBc,
                            NomFr = m.InfoFournisseur.Nom,
                            Code = bc.InfoMorasse.CodeMorasse,
                            Mr = bc.InfoMorasse.Ligne.InfoLrg.DescriptionLrg,
                            Objet = m.InfoConsultation.ObjetConsultation,
                            Datebc = bc.DateBC,
                            NumPvr = pvr.IdPVR,
                            DatePvr = pvr.DatePVR,
                        };

            ReportDocument ce = new ReportDocument();
            ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportPvr.rpt"));

            if (query.FirstOrDefault() != null)
            {

                dac.FillByPvr(ds.CommissionSet, int.Parse(query.FirstOrDefault().NumPvr.ToString()));


                DateTime d = query.FirstOrDefault().DatePvr;
                NumToString num = new NumToString();
                DateToString dt = new DateToString();
                string s = "L'an " + num.Ninetotwelvedigit(d.Year.ToString()) + " le " + num.Ninetotwelvedigit(d.Day.ToString()) + " du mois de " + dt.DateMounth(d.Month);

                ce.SetDataSource(ds);
                ce.SetParameterValue("date", s);
                ce.SetParameterValue("mr", query.FirstOrDefault().Mr.ToString());
                ce.SetParameterValue("datepvr", query.FirstOrDefault().DatePvr.ToString());
                ce.SetParameterValue("numbc", query.FirstOrDefault().NumBc.ToString());
                ce.SetParameterValue("nom", query.FirstOrDefault().NomFr.ToString());
                ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                ce.SetParameterValue("datebc", query.FirstOrDefault().Datebc.ToString());
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
