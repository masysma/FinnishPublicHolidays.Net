using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinnishPublicHolidays.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fi-FI");
        }

        #region Localization tests

        [TestMethod()]
        public void Localization_FiCulture_ReturnedNameIsCorrect()
        {

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fi-FI");

            var holiday = new DateTime(2021, 1, 1).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Uudenvuodenpäivä", holiday.Name);
        }

        [TestMethod()]
        public void Localization_EnCulture_ReturnedNameIsCorrect()
        {

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            var holiday = new DateTime(2021, 1, 1).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("New Years Day", holiday.Name);
        }


        #endregion

        #region IsWorkDay tests

        [TestMethod()]
        public void IsWorkDay_RegularWeekDay_ReturnsTrue()
        {
            Assert.IsTrue(new DateTime(2021,2,10).IsWorkDay());
        }


        [TestMethod()]
        public void IsWorkDay_Saturday_ReturnsFalse()
        {
            Assert.IsFalse(new DateTime(2021, 12, 18).IsWorkDay());
        }


        [TestMethod()]
        public void IsWorkDay_Sunday_ReturnsFalse()
        {
            Assert.IsFalse(new DateTime(2021, 12, 19).IsWorkDay());
        }

        #endregion

        #region IsPublicHoliday tests

        [TestMethod()]
        public void IsPublicHoliday_RegularSaturday_ReturnsFalse()
        {
            Assert.IsFalse(new DateTime(2021, 12, 18).IsPublicHoliday());
        }


        [TestMethod()]
        public void IsPublicHoliday_NewYearsDay_ReturnsTrue()
        {
            Assert.IsTrue(new DateTime(2022, 1, 1).IsPublicHoliday());
        }

        #endregion

        #region GetHoliday tests

        [TestMethod()]
        public void GetHoliday_NewYearsDay_ReturnsHoliday()
        {
            var holiday = new DateTime(2021, 1, 1).GetHoliday();

            Assert.IsNotNull(holiday);
        }

        [TestMethod()]
        public void GetHoliday_ChristmasDay_ReturnedHolidayDateIsCorrect()
        {
            var holiday = new DateTime(2021, 12, 25).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual(2021, holiday.Date.Year);
            Assert.AreEqual(12, holiday.Date.Month);
            Assert.AreEqual(25, holiday.Date.Day);
        }

        [TestMethod()]
        public void GetHoliday_NewYearsDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2021, 1, 1).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Uudenvuodenpäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_Epiphany_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 1, 6).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Loppiainen", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_goodFriday_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 4, 15).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Pitkäperjantai", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_Easter_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 4, 17).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Pääsiäispäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_SecondDayOfEaster_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 4, 18).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("2. Pääsiäispäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_LaborDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 5, 1).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Vapunpäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_AscensionDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 5, 26).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Helatorstai", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_Pentecost_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 6, 5).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Helluntai", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_MidsummersEve_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 6, 24).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Juhannusaatto", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_MidsummersDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 6, 25).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Juhannuspäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_AllSaintsDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 11, 5).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Pyhäinpäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_IndependenceDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 12, 6).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Itsenäisyyspäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_ChristmasEve_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 12, 24).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Jouluaatto", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_ChristmasDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 12, 25).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Joulupäivä", holiday.Name);
        }

        [TestMethod()]
        public void GetHoliday_BoxingDay_ReturnedNameIsCorrect()
        {
            var holiday = new DateTime(2022, 12, 26).GetHoliday();

            Assert.IsNotNull(holiday);
            Assert.AreEqual("Tapaninpäivä", holiday.Name);
        }


        #endregion
    }
}