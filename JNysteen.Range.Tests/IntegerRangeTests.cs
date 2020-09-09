using FluentAssertions;
using NUnit.Framework;

namespace JNysteen.Range.Tests
{
    public class IntegerRangeTests
    {
        [Test]
        [TestCase(1, 2, 1, 2, true)]
        [TestCase(1, 4, 2, 3, true)] // Range 2 is fully contained in range 1
        [TestCase( 2, 3, 1, 4,true)] // Range 1 is fully contained in range 2
        [TestCase( null, 3, 1, 4,true)]
        [TestCase( 1, null, 1, 4,true)]
        
        [TestCase(1, 2, 3, 4, false)]
        [TestCase(1, 2, 2, 3, false)]
        [TestCase( 10, null, 1, 4,false)]
        [TestCase( null, 10, 11, 12,false)]
        public void CanDetectRangeOverlap(int? range1Start, int? range1End, int? range2Start, int? range2End, bool expectOverlap)
        {
            var range1 = new Range<int>(range1Start, range1End);
            var range2 = new Range<int>(range2Start, range2End);

            var range1OverlapsWithRange2 = range1.OverlapsWith(range2);
            var range2OverlapsWithRange1 = range1.OverlapsWith(range2);

            range2OverlapsWithRange1.Should().Be(expectOverlap);
            range1OverlapsWithRange2.Should().Be(expectOverlap);
        }
    }
}