using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace JNysteen.Range.Tests
{
    public class DateRangeTests
    {
        [Test]
        [TestCase("2020-01-01", "2020-01-03", "2020-01-02", true)]
        [TestCase("2020-01-01", "2020-01-02", "2020-01-02", true)]
        [TestCase("2020-01-01", "2020-01-02", "2020-01-01", true)]
        [TestCase("2020-01-01", "2020-01-03", "2020-01-04", false)]
        [TestCase("2020-01-01", "2020-01-03", "2019-01-01", false)]
        public void CanDetectWhenDateIsInRange(string dateRangeStartAsString, string dateRangeEndAsString, string inputDateAsString, bool expectedResult)
        {
            var dateRangeStart = DateTimeOffset.Parse(dateRangeStartAsString, CultureInfo.InvariantCulture);
            var dateRangeEnd = DateTimeOffset.Parse(dateRangeEndAsString, CultureInfo.InvariantCulture);
            
            var inputDate = DateTimeOffset.Parse(inputDateAsString, CultureInfo.InvariantCulture);
            
            var dateRange = new Range<DateTimeOffset>(dateRangeStart, dateRangeEnd);

            var isInRange = dateRange.IsInRange(inputDate);
            isInRange.Should().Be(expectedResult);
        }
    }
}