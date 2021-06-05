using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Onssa_Web_Mvc.Models
{
  public class NumToString
   {
           public string virgule(string f)
           {
                 bool test = false ;
                string ph="";
                string part1 ="";
                string part2 ="";
                int index = 0;
                foreach(char c in f)
                {
                    if(c != ',')
                    {
                         ph = ph + c;
                    }
                    else
                    {
                        index = f.IndexOf(c);
                        part1 = Ninetotwelvedigit(ph);
                        test = true;

                    }
                }

                 ph = "";

                 foreach(char c in f )
                 {
                    if (f.IndexOf(c) > index)
                    {
                        ph = ph + c;
                    }
                   
                 }
                 part2 = Ninetotwelvedigit(ph);

                 if(test == false )
                 {
                    return Ninetotwelvedigit(f);   
                 }
                 else
                 {
                    return part1 + " Virgule " + part2;
                 }

                
           }
            private string SingleDigite(string singledigit)

            {

                int i;

                var r = int.TryParse(singledigit, out i);

                if (r)

                {

                    switch (i)

                    {

                        case 1:

                            return "UN";

                        case 2:

                            return "DEUX";

                        case 3:

                            return "TROIS";

                        case 4:

                            return "QUATRE";

                        case 5:

                            return "CINQ";

                        case 6:

                            return "SIX";

                        case 7:

                            return "SEPT";

                        case 8:

                            return "HUIT";

                        case 9:

                            return "NEUF";

                        default:

                            break;

                    }

                }

                return "";

            }

            private string Twodigite(string twodigit)

            {

                int i = 0;

                var r = int.TryParse(twodigit, out i);

                if (r)

                {

                    if (i <= 20)

                    {

                        switch (i)

                        {

                            case 1:

                                return "UN";

                            case 2:

                                return "DEUX";

                            case 3:

                                return "TROIS";

                            case 4:

                                return "QUATRE";

                            case 5:

                                return "CINQ";

                            case 6:

                                return "SIX";

                            case 7:

                                return "SEPT";

                            case 8:

                                return "HUIT";

                            case 9:

                                return "NEUF";

                            case 10:

                                return "DIX";

                            case 11:

                                return "ONZE";

                            case 12:

                                return "DOUZE";

                            case 13:

                                return "TREIZE";

                            case 14:

                                return "QUATORZE";

                            case 15:

                                return "QUINZE";

                            case 16:

                                return "SEIZE";

                            case 17:

                                return "DIX-SEPT";

                            case 18:

                                return "DIX-HUIT";

                            case 19:

                                return "DIX-NEUF";

                            case 20:

                                return "VINGT";

                            default:

                                break;

                        }

                    }

                    else if (i > 20 & i < 30)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "VINGT ET UN";

                        }

                        else

                        {

                            return "VINGT-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 30)

                    {

                        return "TRENTE";

                    }

                    else if (i > 30 & i < 40)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "TRENTE ET UN";

                        }

                        else

                        {

                            return "TRENTE-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 40)

                    {

                        return "QUARANTE";

                    }

                    else if (i > 40 & i < 50)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "QUARANTE ET UN";

                        }

                        else

                        {

                            return "QUARANTE-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 50)

                    {

                        return "CINQUANTE";

                    }

                    else if (i > 50 & i < 60)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "CINQUANTE ET UN";

                        }

                        else

                        {

                            return "CINQUANTE-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 60)

                    {

                        return "SOIXANTE";

                    }

                    else if (i > 60 & i < 70)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "SOIXANTE ET UN";

                        }

                        else

                        {

                            return "SOIXANTE-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 70)

                    {

                        return "SOIXANTE-DIX";

                    }

                    else if (i > 70 & i < 80)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "SOIXANTE-ONZE";

                        }

                        else

                        {

                            int b = int.Parse(twodigitarray[1].ToString());

                            int plusten = b + 10;

                            return "SOIXANTE-" + Twodigite(plusten.ToString());

                        }

                    }

                    else if (i == 80)

                    {

                        return "QUATRE-VINGTS";

                    }

                    else if (i > 80 & i < 90)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "QUATRE-VINGTS ET UN";

                        }

                        else

                        {

                            return "QUATRE-VINGTS-" + SingleDigite(twodigitarray[1].ToString());

                        }

                    }

                    else if (i == 90)

                    {

                        return "QUATRE-VINGTS-DIX";

                    }

                    else if (i > 90 & i < 100)

                    {

                        var twodigitarray = twodigit.ToCharArray();

                        if (twodigitarray[1].ToString() == "1")

                        {

                            return "QUATRE-VINGTS-ONZE";

                        }

                        else

                        {

                            int b = int.Parse(twodigitarray[1].ToString());

                            int plusten = b + 10;

                            return "QUATRE-VINGTS-" + Twodigite(plusten.ToString());

                        }

                    }

                }

                return "";

            }

            private string ThreeDigite(string threedigit)

            {

                int i = 0;

                var r = int.TryParse(threedigit, out i);

                if (r && i < 1000)

                {

                    var threedigitarray = threedigit.ToCharArray();

                    if (i < 100)

                    {

                        return Twodigite(i.ToString());

                    }

                    else if (i == 100)

                    {

                        return "CENT";

                    }

                    else if (threedigitarray[1].ToString() == "0" && threedigitarray[2].ToString() == "0")

                    {

                        return SingleDigite(threedigitarray[0].ToString()) + " CENT ";

                    }

                    else if (i > 100 & i < 200)

                    {

                        return "CENT " + Twodigite(threedigitarray[1].ToString() + threedigitarray[2].ToString());

                    }

                    else if (i >= 200 & i < 1000)

                    {

                        return SingleDigite(threedigitarray[0].ToString()) + " CENT " + Twodigite(threedigitarray[1].ToString() + threedigitarray[2].ToString());

                    }

                }

                return "";

            }

            private string Foutosixdigit(string fourtosixdigit)

            {

                int i = 0;

                var r = int.TryParse(fourtosixdigit, out i);

                if (r && i < 1000000)

                {

                    var fourtosixdigitarray = fourtosixdigit.ToCharArray();

                    if (i == 1000)

                    {

                        return "MILLE";

                    }

                    else if (i < 1000)

                    {

                        return ThreeDigite(i.ToString());

                    }

                    else if (i > 1000 & i < 2000)

                    {

                        return "MILLE " + ThreeDigite(fourtosixdigitarray[1].ToString() + fourtosixdigitarray[2].ToString() + fourtosixdigitarray[3].ToString());

                    }

                    else if (i >= 2000 & i < 1000000)

                    {

                        string thoudanddigit = fourtosixdigit.Remove(fourtosixdigit.Length - 3);

                        string hundereddisigt = fourtosixdigit.Substring(fourtosixdigit.Length - 3);

                        return ThreeDigite(thoudanddigit) + " MILLE " + ThreeDigite(hundereddisigt);

                    }

                }

                return "";

            }

            private string SixdgigittoNine(string sixtoninedisigt)

            {

                decimal i;

                var r = decimal.TryParse(sixtoninedisigt, out i);

                if (r && i < 1000000000)

                {

                    var sixtoinedigitarray = sixtoninedisigt.ToCharArray();

                    if (i < 1000000000 && i >= 1000000)

                    {

                        string milliondidigt = sixtoninedisigt.Remove(sixtoninedisigt.Length - 6);

                        string thousanddigit = sixtoninedisigt.Substring(sixtoninedisigt.Length - 6, 3);

                        string otherdgit = sixtoninedisigt.Substring(sixtoninedisigt.Length - 3);

                        if (thousanddigit == "000")

                        {

                            return ThreeDigite(milliondidigt) + " MILLION " + ThreeDigite(thousanddigit) + ThreeDigite(otherdgit);

                        }

                        else

                        {

                            return ThreeDigite(milliondidigt) + " MILLION " + ThreeDigite(thousanddigit) + " MILLE " + ThreeDigite(otherdgit);

                        }

                    }

                    else if (i < 1000000)

                    {

                        return Foutosixdigit(i.ToString());

                    }

                }

                return "";

            }

            public string Ninetotwelvedigit(string nicetotwelvedidigt)

            {

                decimal i;

                var r = decimal.TryParse(nicetotwelvedidigt, out i);

                if (r && i < 1000000000000)

                {

                    var sixtoinedigitarray = nicetotwelvedidigt.ToCharArray();

                    if (i < 1000000000000 && i >= 1000000000)

                    {

                        string milliarddigit = nicetotwelvedidigt.Remove(nicetotwelvedidigt.Length - 9);

                        string milliondidigt = nicetotwelvedidigt.Substring(nicetotwelvedidigt.Length - 9, 3);

                        string thousanddigit = nicetotwelvedidigt.Substring(nicetotwelvedidigt.Length - 6, 3);

                        string otherdgit = nicetotwelvedidigt.Substring(nicetotwelvedidigt.Length - 3);

                        //return ThreeDigite(milliarddigit) + " milliard " + ThreeDigite(milliondidigt) + ThreeDigite(thousanddigit) + ThreeDigite(otherdgit);

                        //return milliarddigit + milliondidigt + thousanddigit + otherdgit;

                        if (milliondidigt == "000" & thousanddigit == "000")

                        {

                            return ThreeDigite(milliarddigit) + " MILLIARD " + ThreeDigite(milliondidigt) + ThreeDigite(thousanddigit) + ThreeDigite(otherdgit);

                        }

                        else if (milliondidigt == "000" & thousanddigit != "000")

                        {

                            return ThreeDigite(milliarddigit) + " MILLIARD " + ThreeDigite(milliondidigt) + ThreeDigite(thousanddigit) + " MILLE " + ThreeDigite(otherdgit);

                        }

                        else if (milliondidigt != "000" & thousanddigit == "000")

                        {

                            return ThreeDigite(milliarddigit) + " MILLIARD " + ThreeDigite(milliondidigt) + " MILLION " + ThreeDigite(thousanddigit) + ThreeDigite(otherdgit);

                        }

                        else if (milliondidigt != "000" & thousanddigit != "000")

                        {

                            return ThreeDigite(milliarddigit) + " MILLIARD " + ThreeDigite(milliondidigt) + " MILLION " + ThreeDigite(thousanddigit) + " mille " + ThreeDigite(otherdgit);

                        }

                        else

                        {

                        }

                    }

                    else if (i < 1000000000)

                    {

                        return SixdgigittoNine(i.ToString());

                    }

                }

                return "";

            }

    }

    
}

