using System;

namespace FinnishPublicHolidays
{
    public static class DateTimeOffsetExtensions
    {
        public static bool IsWorkDay(this DateTimeOffset datetimeOffset)
        {
            return datetimeOffset.LocalDateTime.IsWorkDay();
        }

        public static bool IsPublicHoliday(this DateTimeOffset datetimeOffset)
        {
            return datetimeOffset.LocalDateTime.IsPublicHoliday();
        }

        public static Holiday GetHoliday(this DateTimeOffset datetimeOffset)
        {
            return datetimeOffset.LocalDateTime.GetHoliday();
        }


    }
}
