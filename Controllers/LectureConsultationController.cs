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
    public class LectureConsultationController : Controller
    {

        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();

        DataSetReport ds = new DataSetReport();
        Models.DataSetReportTableAdapters.ConsultationSetTableAdapter dac = new Models.DataSetReportTableAdapters.ConsultationSetTableAdapter();
        Models.DataSetReportTableAdapters.ConsultationFournisseurTableAdapter dacf = new Models.DataSetReportTableAdapters.ConsultationFournisseurTableAdapter();
        Models.DataSetReportTableAdapters.FournisseurSetTableAdapter daf = new Models.DataSetReportTableAdapters.FournisseurSetTableAdapter();

        // GET: ConsultationSets
        public ActionResult Index()
        {

            dacf.Fill(ds.ConsultationFournisseur);
            dac.Fill(ds.ConsultationSet); 
            daf.Fill(ds.FournisseurSet);
            return View(ctx.ConsultationSet.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Export(int id,int id2)
        {
            

            ReportDocument ce = new ReportDocument();
            ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportConsultation.rpt"));
            
            daf.FillByFournniseur(ds.FournisseurSet, id2);
            dac.FillByCon(ds.ConsultationSet, id);

           
                var query = from c in ctx.ConsultationSet
                            where c.IdConsultation == id
                            select new
                            {
                                l = c.NumEnvoi
                            };

                if (query.FirstOrDefault() != null)
                {

                    int sum = query.FirstOrDefault().l + id2;
                    ce.SetDataSource(ds);
                    ce.SetParameterValue("nm", sum.ToString());
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
