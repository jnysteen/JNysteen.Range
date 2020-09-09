using System;
using FluentAssertions;
using NUnit.Framework;

namespace JNysteen.Range.Tests
{
    public class RangeConstructionTests
    {
        [Test]
        [TestCase(1, 2)]
        [TestCase(null, 2)]
        [TestCase(1, null)]
        public void CanConstructValidRanges(int? rangeStart, int? rangeEnd)
        {
            var constructedRange = new Range<int>(rangeStart, rangeEnd);
            constructedRange.Should().NotBeNull();
        }
        
        [Test]
        [TestCase(2, 1)]
        [TestCase(1, 1)]
        [TestCase(null, null)]
        public void ThrowsOnInvalidRanges(int? rangeStart, int? rangeEnd)
        {
            var constructorFunc = new Func<Range<int>>(() => new Range<int>(rangeStart, rangeEnd));
            constructorFunc.Should().Throw<ArgumentException>();
        }
    }
}