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

        public static DateTimeOffset GetNextWorkday(this DateTimeOffset datetimeOffset)
        {
            var nextWorkday = FinnishHolidayLogic.GetNextWorkday(datetimeOffset.LocalDateTime);
            return new DateTimeOffset(nextWorkday, datetimeOffset.Offset);
        }


    }
}
