using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDomoweWF
{
    public static class HolidayClass
    {
        public static bool IsHoliday(this DateTime day)
        {
           
            if (day.DayOfWeek == DayOfWeek.Sunday ||
            day.DayOfWeek == DayOfWeek.Saturday ||
            day.Month == 1 && day.Day == 1 || day.Month == 1 && day.Day == 6 || day.Month == 5 && day.Day == 1 ||
            day.Month == 5 && day.Day == 3 || day.Month == 8 && day.Day == 15 || day.Month == 11 && day.Day == 1 ||
            day.Month == 11 && day.Day == 11 || day.Month == 12 && day.Day == 25 || day.Month == 12 && day.Day == 26) return true;
            int a = day.Year % 19;
            int b = day.Year % 4;
            int c = day.Year % 7;
            int d = (a * 19 + 24) % 30;
            int e = (2 * b + 4 * c + 6 * d + 5) % 7;
            if (d == 29 && e == 6) d -= 7;
            if (d == 28 && e == 6 && a > 10) d -= 7;
            DateTime easter = new DateTime(day.Year, 3, 22).AddDays(d + e);
            if (day.AddDays(-1) == easter)
                return true; // Wielkanoc (poniedziałek).
            if (day.AddDays(-60) == easter)
                return true;
            return false;

        }
    }
}
