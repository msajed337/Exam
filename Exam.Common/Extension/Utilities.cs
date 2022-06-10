using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Exam.Common.Extension
{
    public static class Utilities
    {
        public static DateTime ToGregorian(this string date)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] splitDate;
            splitDate = date.Contains("-") ? date.Split("-") : date.Split("/");
            var intDate = splitDate.Select(i => int.Parse(i)).ToList();
            DateTime dateTime = new DateTime(intDate[0], intDate[1], intDate[2], pc);
            return dateTime;
        }

        public static DateTime ToGregorianVer2(this string date) =>
            DateTime.Parse(date, new CultureInfo("fa-IR"));
    }
}
