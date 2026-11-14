using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace _1w4w.CMS.Manager
{
    /// <summary>
    /// https://stackoverflow.com/questions/17391073/how-to-get-the-number-of-weeks-in-a-given-year
    /// </summary>
    public class DateManager
    {
        public static int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            System.Globalization.Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }


        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        // https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
        public static int GetIso8601WeekOfYear(DateTime dt)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dt);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                dt = dt.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static int GetIso8601WeekOfYearNow()
        {
            DateTime dt = DateTime.Now;
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dt);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                dt = dt.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        //public static string GetMonthname(int month)
        //{
        //    if (month >= 1 && month <= 12) { return ""; }
        //    System.Globalization.DateTimeFormatInfo mfi = new
        //    System.Globalization.DateTimeFormatInfo();
        //    return mfi.GetMonthName(month).ToString();
        //}

        public static string GetMonthname(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day).ToString("MMM", CultureInfo.InvariantCulture);
        }
    }
}