using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiaryManagementSystem_dll {
    public static class Day {
        /**
         * Kullanıcıdan bir tarih alacağız ve o tarih üzerinden o günün hangi gün olduğunu bulacağız
         * 
         */
        public static string FindDay( DateTime date) {

            //DateTime date = new DateTime(InpYear, InpMonth, InpDay);
            string dayName = date.DayOfWeek.ToString();

            return dayName;
        }
        /**
         * kulllanıcıdan aldığımız tarihi bir Id parçası haline getiriyoruz daha sonra onu aşağıda personId ile birleştirip yeni bir Id elde edeceğiz
         * 
         *  
         */
        public static int GenerateUniqueIDFromDate(DateTime date) {
            
            int dateID = int.Parse(date.ToString("yyyyMMdd"));
            return dateID;
        }

        /**
         * kullanıcıId ile ogünün tarihin sayıları birleştirilerek yeni bir uniqeId oluşturulacak yani Pimary key olacak
         *  
         */
        public static int SetId( int personID,  int dateID ) {            
            
            return int.Parse($"{dateID}{personID}");            
        }
    }
}
