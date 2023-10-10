using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiaryManagementSystem_dll {
    public static class day {

        public static string FindDay( int InpYear,int InpMonth,int InpDay) {

            DateTime myDate = new DateTime(InpYear, InpMonth, InpDay);
            string dayName = myDate.DayOfWeek.ToString();

            return dayName;
        }

        
        public static string SetId( int personId,  int date ) {

           //TO DO
           return(personId + "_" + date);
        }
    }
}
