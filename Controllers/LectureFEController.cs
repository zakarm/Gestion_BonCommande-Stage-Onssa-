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
    public class LectureFEController : Controller
    {
        private Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();
        DataSetReport ds = new DataSetReport();
        DataRow row;
        Models.DataSetReportTableAdapters.ModeleDevisSetTableAdapter dam = new Models.DataSetReportTableAdapters.ModeleDevisSetTableAdapter();
        Models.DataSetReportTableAdapters.PVJFournisseurTableAdapter dapf = new Models.DataSetReportTableAdapters.PVJFournisseurTableAdapter();
        Models.DataSetReportTableAdapters.ModeleDevisProduitTableAdapter dap = new Models.DataSetReportTableAdapters.ModeleDevisProduitTableAdapter();
        Models.DataSetReportTableAdapters.ConsultationSetTableAdapter dac = new Models.DataSetReportTableAdapters.ConsultationSetTableAdapter();

        // GET: FESets
        public ActionResult Index()
        {
            dapf.Fill(ds.PVJFournisseur);
            dap.Fill(ds.ModeleDevisProduit);
            var fESet = ctx.FESet.Include(f => f.InfoBC);
            return View(fESet.ToList());
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
                    var query = from fe in ctx.FESet
                                join bc in ctx.BCSet on fe.InfoBC.IdBC equals bc.IdBC
                                join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                                join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                                m.InfoFournisseur.IdFournisseur
                                where fe.IdFE == id&& m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation
                                select new
                                {
                                    AdresseFour = m.InfoFournisseur.Adresse,
                                    Cnss = m.InfoFournisseur.CNSS_n,
                                    Ifn = m.InfoFournisseur.IF_n,
                                    Patente = m.InfoFournisseur.Patente_n,
                                    Numfe = fe.NumFe,
                                    NumBc = bc.NumBc,
                                    NomFr = m.InfoFournisseur.Nom,
                                    Code = bc.InfoMorasse.CodeMorasse,
                                    Objet = m.InfoConsultation.ObjetConsultation,
                                    Exercice = bc.InfoMorasse.Exercice,
                                    Compte = m.InfoFournisseur.Compte_bancaire_n,
                                    Lrg = bc.InfoMorasse.Ligne.InfoLrg.NumLrg,
                                    Par = bc.InfoMorasse.Ligne.InfoLrg.InfoParagraphe.NumPar,
                                    Ligne = bc.InfoMorasse.Ligne.CodeLigne,
                                    Credit = fe.CreditsBudgetaires,
                                    Depense = fe.DepensesEngagees,
                                    Dispo = fe.Disponible,
                                    Enga = fe.EngagementDepensesPropose,
                                    NumPvj = pvj.IdPVJ,
                                    NumCon = pvj.InfoConsultation.IdConsultation,
                                    Rc = m.InfoFournisseur.RC_n,
                                    idCon = pvj.InfoConsultation.IdConsultation,
                                    lrgD = bc.InfoMorasse.Ligne.InfoLrg.DescriptionLrg,
                                    ligneD = bc.InfoMorasse.Ligne.DescriptionLigne,
                                    ParD = bc.InfoMorasse.Ligne.InfoLrg.InfoParagraphe.DescriptionPar,


                                };
                
                ReportDocument ce = new ReportDocument();
               ce.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CrystalReportFe.rpt"));

                if (query.FirstOrDefault() != null)
                {

                    int s = 0;
                    foreach (Models.FournisseurSet f in ctx.ConsultationSet.Find(query.FirstOrDefault().idCon).ListFournisseur)
                    {

                        row = ds.Lettre.NewRow();
                        row[0] = ctx.ConsultationSet.Find(query.FirstOrDefault().idCon).NumEnvoi + s;
                        ds.Lettre.Rows.Add(row);
                        s++;
                    }

                    int NumPvj = int.Parse(query.FirstOrDefault().NumPvj.ToString());
                    int NumCon = int.Parse(query.FirstOrDefault().NumCon.ToString());


                    dac.FillByCon(ds.ConsultationSet, NumCon);

                    dam.FillBypvj(ds.ModeleDevisSet, NumPvj, NumCon);
                    
                    ce.SetDataSource(ds);
                    ce.SetParameterValue("lrgD", query.FirstOrDefault().lrgD.ToString());
                    ce.SetParameterValue("ligneD", query.FirstOrDefault().ligneD.ToString());
                    ce.SetParameterValue("ParD", query.FirstOrDefault().ParD.ToString());
                    ce.SetParameterValue("numfe", query.FirstOrDefault().Numfe.ToString());
                    ce.SetParameterValue("if", query.FirstOrDefault().Ifn.ToString());
                    ce.SetParameterValue("cnss", query.FirstOrDefault().Cnss.ToString());
                    ce.SetParameterValue("enga", query.FirstOrDefault().Enga.ToString());
                    ce.SetParameterValue("patent", query.FirstOrDefault().Patente.ToString());
                    ce.SetParameterValue("dispo", query.FirstOrDefault().Dispo.ToString());
                    ce.SetParameterValue("credit", query.FirstOrDefault().Credit.ToString());
                    ce.SetParameterValue("depense", query.FirstOrDefault().Depense.ToString());
                    ce.SetParameterValue("lrg", query.FirstOrDefault().Lrg.ToString());
                    ce.SetParameterValue("par", query.FirstOrDefault().Par.ToString());
                    ce.SetParameterValue("ligne", query.FirstOrDefault().Ligne.ToString());
                    ce.SetParameterValue("numbc", query.FirstOrDefault().NumBc.ToString());
                    ce.SetParameterValue("nom", query.FirstOrDefault().NomFr.ToString());
                    ce.SetParameterValue("objet", query.FirstOrDefault().Objet.ToString());
                    ce.SetParameterValue("exercice", query.FirstOrDefault().Exercice.ToString());
                    ce.SetParameterValue("compte", query.FirstOrDefault().Compte.ToString());
                    ce.SetParameterValue("adresse", query.FirstOrDefault().AdresseFour.ToString());
                    ce.SetParameterValue("rc", query.FirstOrDefault().Rc.ToString());
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
