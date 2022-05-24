using AligentThomasBaynes.Controllers;
using AligentThomasBaynes.Enums;
using AligentThomasBaynes.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace DateUnitTestProj
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void DaysBetweenTest()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-03T05:00:00+05:00").AddDays(5);

            var result = controller.DaysBetween(dateOne, dateTwo);

            var expectedResult = new DateResult
            { 
                Value = 4,
                CurrentType = DateType.Days
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void DaysBetween_Conversion()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-03T05:00:00+05:00").AddDays(5);

            var result = controller.DaysBetween(dateOne, dateTwo, DateType.Minutes);

            var expectedResult = new DateResult
            {
                Value = 7020,
                CurrentType = DateType.Minutes
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }


        [TestMethod]
        public void WorkingDaysBetweenTest()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-26T05:00:00+05:00").AddDays(5);

            var result = controller.WorkingDaysBetween(dateOne, dateTwo);

            var expectedResult = new DateResult
            {
                Value = 19,
                CurrentType = DateType.Minutes
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void WorkingDaysBetween_Conversion()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-26T05:00:00+05:00").AddDays(5);

            var result = controller.WorkingDaysBetween(dateOne, dateTwo, DateType.Minutes);

            var expectedResult = new DateResult
            {
                Value = 27360,
                CurrentType = DateType.Minutes
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void CompleteWeeksBetween()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-26T05:00:00+05:00").AddDays(5);

            var result = controller.CompleteWeeksBetween(dateOne, dateTwo);

            var expectedResult = new DateResult
            {
                Value = 4,
                CurrentType = DateType.Minutes
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void CompleteWeeksBetween_Conversion()
        {
            var controller = new DateController();
            DateTimeOffset dateOne = DateTime.Parse("2022-01-03T05:00:00+02:00");
            DateTimeOffset dateTwo = DateTime.Parse("2022-01-26T05:00:00+05:00").AddDays(5);

            var result = controller.CompleteWeeksBetween(dateOne, dateTwo, DateType.Minutes);

            var expectedResult = new DateResult
            {
                Value = 40320,
                CurrentType = DateType.Minutes
            };

            Assert.AreEqual(expectedResult.Value, result.Value);
        }

    }
}
