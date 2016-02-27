using FluentAssertions;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Notes
{
    public class IntervalShould
    {
        public static TheoryData<int, Interval> IntervalDistances 
            => new TheoryData<int, Interval>
            {
                { 0, Interval.Unisson },
                { 1, Interval.MinorSecond },
                { 2, Interval.MajorSecond },
                { 3, Interval.MinorThird },
                { 4, Interval.MajorThird },
                { 5, Interval.PerfectForth },
                { 6, Interval.DiminishedFifth },
                { 7, Interval.PerfectFifth },
                { 8, Interval.AugmentedFifth },
                { 9, Interval.MajorSixth },
                { 10, Interval.MinorSeventh },
                { 11, Interval.MajorSeventh },
                { 12, Interval.PerfectOctave },
            };

        [Theory, MemberData(nameof(IntervalDistances))]
        public void RelateDistancesToIntervals(int distance, Interval expectedInterval)
        {
            Interval.CreateIntervalFromDistance(distance).Should().Be(expectedInterval);
        }

        [Fact]
        public void SubtractingAMinorSecondFromAnOctaveIsAMajorSeventh()
        {
            Assert.Equal(Interval.PerfectOctave - Interval.MinorSecond, Interval.MajorSeventh);
        }

        [Fact]
        public void OctaveIsGreaterThamMajorSeventh()
        {
            Assert.True(Interval.PerfectOctave > Interval.MajorSeventh);
        }
    }
}