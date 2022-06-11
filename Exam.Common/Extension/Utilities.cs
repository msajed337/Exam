using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Exam.Common.Extension
{
    public static class Utilities
    {
        public static DateTime ToGregorian(this string date) =>
            DateTime.Parse(date, new CultureInfo("fa-IR"));

        public static string ToPersian(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(value)}/{pc.GetMonth(value)}/{pc.GetDayOfMonth(value)}";
        }

    }
}
