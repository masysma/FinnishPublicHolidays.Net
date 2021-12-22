using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinnishPublicHolidays.Tests
{
    [TestClass()]
    public class DateTimeOffsetExtensionsTests
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fi-FI");
        }

        #region GetHoliday tests

        [TestMethod()]
        public void IsWorkDay_DateIsFromAnotherTimezone_ComparedInLocalTimeAndReturnsTrue()
        {
            Assert.IsTrue(new DateTimeOffset(2021, 12, 19, 22, 0, 0, TimeSpan.FromHours(-8)).IsWorkDay());
        }


        #endregion

        #region IsPublicHoliday tests

        [TestMethod()]
        public void IsPublicHoliday_DateIsFromAnotherTimezone_ComparedInLocalTimeAndReturnsTrue()
        {
            Assert.IsTrue(new DateTimeOffset(2021, 12, 31, 22, 0, 0, TimeSpan.FromHours(-8)).IsPublicHoliday());
        }

        #endregion

        #region GetHoliday tests

        [TestMethod()]
        public void GetHoliday_DateIsFromAnotherTimezone_ComparedInLocalTimeAndReturnsHoliday()
        {
            var holiday = new DateTimeOffset(2021, 12, 31, 22, 0, 0, TimeSpan.FromHours(-8)).GetHoliday();

            Assert.IsNotNull(holiday);

            Assert.AreEqual(2022, holiday.Date.Year);
            Assert.AreEqual(1, holiday.Date.Month);
            Assert.AreEqual(1, holiday.Date.Day);

            Assert.AreEqual("Uudenvuodenpäivä", holiday.Name);
        }

        #endregion
    }
}