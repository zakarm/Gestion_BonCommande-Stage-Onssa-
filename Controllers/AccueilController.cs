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

                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IRG7UCK\SQLEXPRESS;Initial Catalog=Onssa_Projet;Integrated Security=True"))
                {

                    SqlCommand cmd = new SqlCommand("select count(*) from FournisseurSet f inner join PVJSet pvj on f.IdFournisseur = pvj.InfoFournisseur_IdFournisseur inner join BCSet bc on pvj.IdPVJ = bc.IdBC where f.IdFournisseur in (select distinct pf.ListFournisseursRepondu_IdFournisseur from PVJFournisseur pf ) and month(bc.DateBC) = MONTH( GETDATE())", con);
                    con.Open();
                    string count = cmd.ExecuteScalar().ToString();
                    con.Close();

                    ViewBag.count = count;
                }


            //-----------------------------------Tas_Statistic ----------------------------------------------------------------------
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


            //----------------------------------------------chartèstart------------------------------------------------------

            for (int i = 1; i<=12;i++)
                {
                    var dataPvr = from pvr in ctx.PVRSet
                                where pvr.DatePVR.Month.Equals(i + 1)
                                select pvr;
                   if( i == 1)
                   {
                        if (dataPvr.FirstOrDefault() != null)
                        {
                            @ViewBag.m1 = dataPvr.ToList().Count;
                        }
                        else
                        {
                            @ViewBag.m1 = 0;
                        }

                   }
                   else
                   {
                        if( i == 2)
                        {
                             if(dataPvr.FirstOrDefault() != null)
                             {
                                @ViewBag.m2 = dataPvr.ToList().Count  ;
                             }
                            else
                            {
                                @ViewBag.m2 = 0;
                            }
                           
                        }
                        else
                        {
                            if( i == 3)
                            {
                                if (dataPvr.FirstOrDefault() != null)
                                {
                                    @ViewBag.m3 = dataPvr.ToList().Count;
                                }
                                else
                                {
                                    @ViewBag.m3 = 0;
                                }
                            }
                            else
                            {
                                if ( i == 4)
                                {
                                    if (dataPvr.FirstOrDefault() != null)
                                    {
                                        @ViewBag.m4 = dataPvr.ToList().Count;
                                    }
                                    else
                                    {
                                        @ViewBag.m4 = 0;
                                    }
                                }
                                else
                                {
                                    if ( i == 5)
                                    {
                                        if (dataPvr.FirstOrDefault() != null)
                                        {
                                            @ViewBag.m5 = dataPvr.ToList().Count;
                                        }
                                        else
                                        {
                                            @ViewBag.m5 = 0;
                                        }
                                    }
                                    else
                                    {
                                        if ( i == 6)
                                        {
                                            if (dataPvr.FirstOrDefault() != null)
                                            {
                                                @ViewBag.m6 = dataPvr.ToList().Count;
                                            }
                                            else
                                            {
                                                @ViewBag.m6 = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (i == 7)
                                            {
                                                if (dataPvr.FirstOrDefault() != null)
                                                {
                                                    @ViewBag.m7 = dataPvr.ToList().Count;
                                                }
                                                else
                                                {
                                                    @ViewBag.m7 = 0;
                                                }
                                            }
                                            else
                                            {
                                                if ( i == 8)
                                                {
                                                    if (dataPvr.FirstOrDefault() != null)
                                                    {
                                                        @ViewBag.m8 = dataPvr.ToList().Count;
                                                    }
                                                    else
                                                    {
                                                        @ViewBag.m8 = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    if ( i == 9)
                                                    {
                                                        if (dataPvr.FirstOrDefault() != null)
                                                        {
                                                            @ViewBag.m9 = dataPvr.ToList().Count;
                                                        }
                                                        else
                                                        {
                                                            @ViewBag.m9 = 0;
                                                        }
                                                     }
                                                    else
                                                    {
                                                        if ( i == 10)
                                                        {
                                                            if (dataPvr.FirstOrDefault() != null)
                                                            {
                                                                @ViewBag.m10 = dataPvr.ToList().Count;
                                                            }
                                                            else
                                                            {
                                                                @ViewBag.m10 = 0;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if ( i == 11)
                                                            {
                                                                if (dataPvr.FirstOrDefault() != null)
                                                                {
                                                                    @ViewBag.m11 = dataPvr.ToList().Count;
                                                                }
                                                                else
                                                                {
                                                                    @ViewBag.m11 = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dataPvr.FirstOrDefault() != null)
                                                                {
                                                                    @ViewBag.m12 = dataPvr.ToList().Count;
                                                                }
                                                                else
                                                                {
                                                                    @ViewBag.m12 = 0;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                           
                        }
                   }
                  
                    
             }
            //----------------------------------------------chartend------------------------------------------------------



             return View();
        }
       
    }
}