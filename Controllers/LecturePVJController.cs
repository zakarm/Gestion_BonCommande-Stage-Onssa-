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
    public class LecturePVJController : Controller
    {
        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();

        // GET: PVJSets
        public ActionResult Index()
        {
            var pVJSet = ctx.PVJSet.Include(p => p.InfoConsultation).Include(p => p.InfoFournisseur);
            return View(pVJSet.ToList());
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


            DataSetPvj ds = new DataSetPvj();
            DataRow row;

            var query = from pvj in ctx.PVJSet
                        join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                        m.InfoFournisseur.IdFournisseur
                        where pvj.IdPVJ == id && m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                        select new
                        {
                            IdCon = pvj.InfoConsultation.IdConsultation,
                            NomFr = m.InfoFournisseur.Nom,
                            Objet = m.InfoConsultation.ObjetConsultation,
                            IdPvj = pvj.IdPVJ,
                            NumCon = pvj.InfoConsultation.NumConsultation,
                            NumDevis = m.NumDevis,
                            IdDevis = m.IdModeleDevis,
                            Tva = m.Tva,
                            Ttc = m.Ttc,
                            thc = m.Total,
                            DatePvj = pvj.DatePvj,

                        };

            NumToString cc = new NumToString();

            ReportDocument ce = new ReportDocument();
            ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportPvj.rpt"));

            if (query.FirstOrDefault() != null)
            {

                foreach (FournisseurSet f in ctx.PVJSet.Find(query.FirstOrDefault().IdPvj).FournisseurSet1)
                {
                    row = ds.FournisseurReponduSet.NewRow();
                    row[0] = f.Nom;
                    ds.FournisseurReponduSet.Rows.Add(row);

                }

                foreach (FournisseurSet f in ctx.ConsultationSet.Find(query.FirstOrDefault().IdCon).ListFournisseur)
                {


                    row = ds.FournisseurCon.NewRow();
                    row[0] = f.Nom;
                    ds.FournisseurCon.Rows.Add(row);

                    var query2 = from md in ctx.ModeleDevisSet
                                 where md.InfoFournisseur.IdFournisseur == f.IdFournisseur && md.InfoConsultation.IdConsultation == query.FirstOrDefault().IdCon
                                 select new
                                 {
                                     IdDevis = md.IdModeleDevis,
                                 };

                    if (query2.FirstOrDefault() != null)
                    {
                        ModeleDevisSet m = ctx.ModeleDevisSet.Find(query2.FirstOrDefault().IdDevis);
                        row = ds.Devis.NewRow();
                        row[0] = m.InfoFournisseur.Nom;
                        row[1] = m.IdModeleDevis;
                        row[2] = m.Date;
                        row[3] = m.Ttc;
                        ds.Devis.Rows.Add(row);
                    }

                }

                foreach (CommissionSet c in ctx.PVJSet.Find(query.FirstOrDefault().IdPvj).CommissionSet)
                {

                    row = ds.CommissionSet.NewRow();
                    row[1] = c.Nom;
                    row[2] = c.Prenom;
                    row[3] = c.Fonction;
                    row[4] = c.Affectation;
                    ds.CommissionSet.Rows.Add(row);
                }


                DateTime d = query.FirstOrDefault().DatePvj;
                NumToString num = new NumToString();
                DateToString dt = new DateToString();
                string s = "L'an " + num.Ninetotwelvedigit(d.Year.ToString()) + " le " + num.Ninetotwelvedigit(d.Day.ToString()) + " du mois de " + dt.DateMounth(d.Month);
              
                ce.SetDataSource(ds);
                ce.SetParameterValue("nom", query.FirstOrDefault().NomFr.ToString());
                ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                ce.SetParameterValue("thc", query.FirstOrDefault().thc.ToString());
                ce.SetParameterValue("tva", query.FirstOrDefault().Tva.ToString());
                ce.SetParameterValue("ttc", query.FirstOrDefault().Ttc.ToString());
                ce.SetParameterValue("datepvj", query.FirstOrDefault().DatePvj.ToString());
                ce.SetParameterValue("numcon", query.FirstOrDefault().NumCon.ToString());
                ce.SetParameterValue("date", s);
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
