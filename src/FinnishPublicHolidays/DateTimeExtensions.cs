using System;

namespace FinnishPublicHolidays
{
    public static class DateTimeExtensions
    {
        public static bool IsWorkDay(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            return !date.IsPublicHoliday();
        }

        public static bool IsPublicHoliday(this DateTime date)
        {
            return FinnishHolidayLogic.GetHoliday(date) != null;
        }

        public static Holiday GetHoliday(this DateTime date)
        {
            return FinnishHolidayLogic.GetHoliday(date);
        }


    }
}
