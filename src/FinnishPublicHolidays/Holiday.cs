using System;

namespace FinnishPublicHolidays
{
    /// <summary>
    /// Class containing the date and describing a Finnish public holiday
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Name of the holiday
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="date"></param>
        /// <param name="name"></param>
        public Holiday(DateTime date, string name)
        {
            this.Date = date.Date;
            this.Name = name;
        }

        /// <summary>
        /// Compares given date to holidays date. return true if date parts (year, month and day) are the same
        /// </summary>
        /// <param name="date">Date to compare</param>
        /// <returns>True if dates are the same</returns>
        public bool IsDate(DateTime date)
        {
            return this.Date.Year == date.Year
                   && this.Date.Month == date.Month
                   && this.Date.Day == date.Day;
        }
    }
}