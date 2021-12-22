using System;
using FinnishPublicHolidays.Resources;

namespace FinnishPublicHolidays
{
    internal static class FinnishHolidayLogic
    {
        internal static Holiday GetHoliday(DateTime date)
        {
            // Check if date is from month that does not have holidays
            if (date.Month == 2 || date.Month == 7 || date.Month == 8 || date.Month == 9)
            {
                return null;
            }

            // Check based on month and day
            var holiday = IsYearlyRecurringHoliday(date);

            if (holiday != null)
            {
                return holiday;
            }
            // Check weekday based holidays
            holiday = IsWeekdayBasedHoliday(date);
            if (holiday != null)
            {
                return holiday;
            }

            // Check easter related holidays
            holiday = IsEasterRelatedHoliday(date);
            if (holiday != null)
            {
                return holiday;
            }

            return null;
        }

        private static Holiday IsYearlyRecurringHoliday(DateTime date)
        {

            switch (date.Month)
            {
                case 1:
                    switch (date.Day)
                    {
                        case 1:
                            return new Holiday(date, Holidays.NewYearsDay);
                        case 6:
                            return new Holiday(date, Holidays.Epiphany);
                        default:
                            return null;
                    }

                case 5:
                    switch (date.Day)
                    {
                        case 1:
                            return new Holiday(date, Holidays.FirstOfMay);
                        default:
                            return null;
                    }

                case 12:
                    switch (date.Day)
                    {
                        case 6:
                            return new Holiday(date, Holidays.IndepencenceDay);
                        case 24:
                            return new Holiday(date, Holidays.ChristmasEve);
                        case 25:
                            return new Holiday(date, Holidays.ChristmasDay);
                        case 26:
                            return new Holiday(date, Holidays.BoxingDay);
                        default:
                            return null;
                    }
            }
            return null;
        }

        private static Holiday IsWeekdayBasedHoliday(DateTime date)
        {

            // Midsummer related holidays need to determined if month is June
            if (date.Month == 6)
            {
                var tempDate = new DateTime(date.Year, 6, 19);

                var holiday = GetHolidayForNextGivenWeekday(tempDate, DayOfWeek.Friday, Holidays.MidsummerEve);
                if (holiday.IsDate(date))
                {
                    return holiday;
                }

                holiday = GetHolidayForNextGivenWeekday(tempDate, DayOfWeek.Saturday, Holidays.MidsummerDay);
                if (holiday.IsDate(date))
                {
                    return holiday;
                }

                return null;
            }

            // All Saints' day needs to checked only in October and November
            if (date.Month == 10 || date.Month == 11)
            {
                var tempDate = new DateTime(date.Year, 10, 31);

                var holiday = GetHolidayForNextGivenWeekday(tempDate, DayOfWeek.Saturday, Holidays.AllSaintsDay);
                if (holiday.IsDate(date))
                {
                    return holiday;
                }
            }

            return null;
        }

        private static Holiday GetHolidayForNextGivenWeekday(DateTime date, DayOfWeek weekDay, string description)
        {
            while (date.DayOfWeek != weekDay)
            {
                date = date.AddDays(1);
            }

            return new Holiday(date, description);
        }

        private static Holiday IsEasterRelatedHoliday(DateTime date)
        {
            // Easter is calculated with Gauss's algorithm.
            // See for example: https://www.whydomath.org/Reading_Room_Material/ian_stewart/2000_03.html

            // Calculation is only needed if the month is between March and June
            if (date.Month >= 1 && date.Month <= 6)
            {
                int easterMonth;
                int easterDay;

                var a = date.Year % 19;
                var b = date.Year % 4;
                var c = date.Year % 7;
                var d = (24 + 19 * a) % 30;
                var e = (5 + 2 * b + 4 * c + 6 * d) % 7;
                var f = 22 + d + e;

                if (f <= 31)
                {
                    easterMonth = 3;
                    easterDay = f;
                }
                else
                {
                    easterMonth = 4;
                    var g = d + e - 9;

                    // First exception : if g=26-> easter = 19.4.
                    if (g == 26)
                    {
                        easterDay = 19;
                    }

                    // Second exception: if g=25, d=28 and a>10-> easter = 18.4.
                    else if (g == 25 && d == 28 && a > 10)
                    {
                        easterDay = 18;
                    }
                    // General rule: easter -> g
                    else
                    {
                        easterDay = g;
                    }
                }

                var easter = new Holiday(new DateTime(date.Year, easterMonth, easterDay), Holidays.Easter);
                if (easter.IsDate(date))
                {
                    return easter;
                }

                var goodFriday = new Holiday(easter.Date.AddDays(-2), Holidays.GoodFriday);
                if (goodFriday.IsDate(date))
                {
                    return goodFriday;
                }

                var secondEasterDay = new Holiday(easter.Date.AddDays(1), Holidays.EasterSunday);
                if (secondEasterDay.IsDate(date))
                {
                    return secondEasterDay;
                }

                var ascensionDay = new Holiday(easter.Date.AddDays(39), Holidays.AscensionDay);
                if (ascensionDay.IsDate(date))
                {
                    return ascensionDay;
                }

                var pentecost = new Holiday(easter.Date.AddDays(49), Holidays.Pentecost);
                if (pentecost.IsDate(date))
                {
                    return pentecost;
                }
            }

            return null;
        }
    }
}
