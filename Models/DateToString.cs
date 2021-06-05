using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Onssa_Web_Mvc.Models
{
    class DateToString
    {

      List<string> DateString = new List<string>();
           

        public void Date()
        {
            DateString.Add("Janvier");
            DateString.Add("Février");
            DateString.Add("Mars");
            DateString.Add("Avril");
            DateString.Add("Mai");
            DateString.Add("Juin");
            DateString.Add("Juillet");
            DateString.Add("Aout");
            DateString.Add("Septembre");
            DateString.Add("Octobre");
            DateString.Add("Novembre");
            DateString.Add("Décembre");

        }

        public string DateMounth(int d)
        {
            Date();
            
            switch (d)
            {
                case 01: return DateString[0].ToString();
                case 02: return DateString[1].ToString(); 
                case 03: return DateString[2].ToString(); 
                case 04: return DateString[3].ToString(); 
                case 05: return DateString[4].ToString(); 
                case 06: return DateString[5].ToString(); 
                case 07: return DateString[6].ToString(); 
                case 08: return DateString[7].ToString(); 
                case 09: return DateString[8].ToString(); 
                case 10: return DateString[9].ToString(); 
                case 11: return DateString[10].ToString(); 

            }
            

                return DateString[11].ToString();
        }
       
    }
}
