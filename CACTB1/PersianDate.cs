using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CACTB1
{
    
    public class PersianDateConverter
    {
        static PersianCalendar pc = new PersianCalendar();
        /// <summary>
        /// yyyy/mm/dd
        /// <para></para>
        /// Using <seealso cref="DateTime"/>
        /// returns <see cref="string"/>
        /// </summary>
        /// <returns>string</returns>
        public static string GetDate()
        {
            DateTime date = new DateTime();
            date = DateTime.Today;
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            return string.Format("{0:D4}/{1:D2}/{2:D2}",year,month,day);
        }
    }
}