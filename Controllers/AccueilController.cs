using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projet_Onssa_Web_Mvc.Models;


namespace Projet_Onssa_Web_Mvc.Controllers
{
    public class AccueilController : Controller
    {
        Onssa_ProjetEntities ctx = new Onssa_ProjetEntities();
        // GET: Accueil
        [HttpGet]
        public ActionResult Statistique()
        {

                var data1 = from bc in ctx.BCSet
                             where bc.DateBC.Month.Equals(DateTime.Today.Month)
                             select bc;
                ViewBag.Dpns = data1.ToList().Count.ToString();


                var data2 = from bc in ctx.BCSet
                           join pvj in ctx.PVJSet on bc.InfoPVJ.IdPVJ equals pvj.IdPVJ
                           join m in ctx.ModeleDevisSet on pvj.InfoFournisseur.IdFournisseur equals
                           m.InfoFournisseur.IdFournisseur
                           where m.InfoConsultation.IdConsultation == pvj.InfoConsultation.IdConsultation && bc.DateBC.Month.Equals(DateTime.Today.Month)
                           orderby bc.DateBC.Month ascending
                           select m;
                ViewBag.t = data2.AsEnumerable().Sum(o => o.Ttc);

            //Fournisseur_Statistic ---------------------------------------------------------------------- 

                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KCK4EL9\SQLEXPRESS;Initial Catalog=Onssa_Projet;Integrated Security=True"))
                {

                    SqlCommand cmd = new SqlCommand("select count(*) from FournisseurSet f inner join PVJSet pvj on f.IdFournisseur = pvj.InfoFournisseur_IdFournisseur inner join BCSet bc on pvj.IdPVJ = bc.IdBC where f.IdFournisseur in (select distinct pf.ListFournisseursRepondu_IdFournisseur from PVJFournisseur pf ) and month(bc.DateBC) = MONTH( GETDATE())", con);
                    con.Open();
                    string count = cmd.ExecuteScalar().ToString();
                    con.Close();

                    ViewBag.count = count;
                }


            //Tas_Statistic ----------------------------------------------------------------------
               var maxValue = ctx.ConsultationSet.Max(x => x.IdConsultation);

                var queryM = from m in ctx.ModeleDevisSet
                            where m.InfoConsultation.IdConsultation == maxValue 
                            select m;

                ViewBag.tas = "20%";

                if(queryM.FirstOrDefault() != null)
                {
                    ViewBag.tas = "30%";
                }

                var queryPvj = from pvj in ctx.PVJSet
                             where pvj.InfoConsultation.IdConsultation == maxValue
                             select pvj;

                if (queryPvj.FirstOrDefault() != null)
                {
                    ViewBag.tas = "40%";
                }


                var queryBc = from bc in ctx.BCSet
                             where bc.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                             select bc;

                if (queryBc.FirstOrDefault() != null)
                {
                    ViewBag.tas = "50%";
                }

                var queryFe = from fe in ctx.FESet
                               where fe.InfoBC.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                              select fe;

                if (queryFe.FirstOrDefault() != null)
                {
                    ViewBag.tas = "60%";
                }


                var queryOi = from oi in ctx.OISet
                              where oi.InfoFE.InfoBC.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                              select oi;

                if (queryOi.FirstOrDefault() != null)
                {
                    ViewBag.tas = "70%";
                }

                var queryPvr = from pvr in ctx.PVRSet
                              where pvr.InfoOI.InfoFE.InfoBC.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                               select pvr;

                if (queryPvr.FirstOrDefault() != null)
                {
                    ViewBag.tas = "80%";
                }

                var queryOp = from op in ctx.OPSet
                               where op.InfoOI.InfoFE.InfoBC.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                               select op;

                if (queryOp.FirstOrDefault() != null)
                {
                    ViewBag.tas = "90%";
                }

                var queryOv = from ov in ctx.OVSet
                              where ov.InfoOP.InfoOI.InfoFE.InfoBC.InfoPVJ.InfoConsultation.IdConsultation == maxValue
                              select ov;

                if (queryOv.FirstOrDefault() != null)
                {
                    ViewBag.tas =" 100%";
                }


            //Diagram_Statistic ----------------------------------------------------------------------

                for(int i = 0; i<=11;i++)
                {
                    var dataPvr = from pvr in ctx.PVRSet
                                where pvr.DatePVR.Month.Equals(i + 1)
                                select pvr;
                   if(dataPvr.FirstOrDefault() != null && i == 0)
                   {
                      @ViewBag.m1 =dataPvr.ToList().Count + "%";
                      
                   }
                   else
                   {
                        if(dataPvr.FirstOrDefault() != null && i == 2)
                        {
                           @ViewBag.m2 = dataPvr.ToList().Count + "%" ;
                        }
                        else
                        {
                            if(dataPvr.FirstOrDefault() != null && i == 3)
                            {
                                @ViewBag.m3 = dataPvr.ToList().Count + "%";
                            }
                           
                        }
                   }    
                    
                }


            //_______________________Count Ta3 BC Li3andi F 3ans ____________________________//
            var CountBc = from bc in ctx.BCSet
                               where bc.DateBC.Year.Equals(DateTime.Today.Year) || bc.DateBC.Year.Equals(DateTime.Today.Year - 1) || bc.DateBC.Year.Equals(DateTime.Today.Year - 2)
                          select bc;
            int countBc = int.Parse(CountBc.ToList().Count.ToString());
            //____________________Count Ta3 BC Li3andi had L3AM________________//
            var BcTodayYears = from bc in ctx.BCSet
                        where bc.DateBC.Year.Equals(DateTime.Today.Year)
                        select bc;
            int countYear = (int.Parse(BcTodayYears.ToList().Count.ToString())) *100/countBc ;
            ViewBag.BcTodayYears = countYear;
            //__________________Count Ta3 BC Li3andi L3AM LII FAT________________________//
            var BcTodayLYears = from bc in ctx.BCSet
                               where bc.DateBC.Year.Equals(DateTime.Today.Year-1)
                               select bc;
            int countLYear = (int.Parse(BcTodayLYears.ToList().Count.ToString())) * 100/ countBc;
            ViewBag.BcTodayLYears = countLYear;
            //____________________Count Ta3 BC Li3andi Wam L3AM LIFAT 2019_______________//
            var BcTodayLLYears = from bc in ctx.BCSet
                               where bc.DateBC.Year.Equals(DateTime.Today.Year-2)
                               select bc;
            int countLLYear = (int.Parse(BcTodayLLYears.ToList().Count.ToString())) * 100/ countBc;
            ViewBag.BcTodayLLYears = countLLYear;


            return View();
        }
       
    }
}