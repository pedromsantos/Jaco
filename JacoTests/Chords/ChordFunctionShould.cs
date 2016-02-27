using System.Collections.Generic;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Chords
{
    public class ChordFunctionShould
    {
        public static TheoryData<ChordFunction, string> FunctionsAndNames
            => new TheoryData<ChordFunction, string>
            {
                {ChordFunction.Major, "Maj"},
                {ChordFunction.Augmented, "Aug"},
                {ChordFunction.Minor, "Min"},
                {ChordFunction.Diminished, "Dim"},
                {ChordFunction.Sus2, "Sus2"},
                {ChordFunction.Sus2Diminished, "Sus2Dim"},
                {ChordFunction.Sus2Augmented, "Sus2Aug"},
                {ChordFunction.Sus4, "Sus4"},
                {ChordFunction.Sus4Diminished, "Sus4Dim"},
                {ChordFunction.Sus4Augmented, "Sus4Aug"},
                {ChordFunction.Major7, "Maj7"},
                {ChordFunction.Dominant7, "Dom7"},
                {ChordFunction.Minor7b5, "Min7b5"},
                {ChordFunction.Diminished7, "Dim7"},
                {ChordFunction.Minor7, "Min7"},
                {ChordFunction.MinorMaj7, "MinMaj7"},
                {ChordFunction.Augmented7, "Aug7"}
            }; 

        [Theory, MemberData(nameof(FunctionsAndNames))]
        public void RelateMajorFunctionWithAbreviatedName(ChordFunction function, string expectedName)
        {
            function.AbreviatedName.Should().Be(expectedName);
        }

        public static TheoryData<ChordFunction, IEnumerable<Interval>> FunctionsAndIntervals
            => new TheoryData<ChordFunction, IEnumerable<Interval>>
            {
                {ChordFunction.Major, new[] {Interval.MajorThird, Interval.PerfectFifth}},
                {ChordFunction.Augmented, new[] {Interval.MajorThird, Interval.AugmentedFifth}},
                {ChordFunction.Minor, new[] {Interval.MinorThird, Interval.PerfectFifth}},
                {ChordFunction.Diminished, new[] {Interval.MinorThird, Interval.DiminishedFifth}},
                {ChordFunction.Sus2, new[] {Interval.MajorSecond, Interval.PerfectFifth}},
                {ChordFunction.Sus2Augmented, new[] {Interval.MajorSecond, Interval.AugmentedFifth}},
                {ChordFunction.Sus2Diminished, new[] {Interval.MajorSecond, Interval.DiminishedFifth}},
                {ChordFunction.Sus4, new[] {Interval.PerfectForth, Interval.PerfectFifth}},
                {ChordFunction.Sus4Augmented, new[] {Interval.PerfectForth, Interval.AugmentedFifth}},
                {ChordFunction.Sus4Diminished, new[] {Interval.PerfectForth, Interval.DiminishedFifth}},
                {ChordFunction.Major7, new[] {Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh}},
                {ChordFunction.Minor7, new[] {Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh}},
                {ChordFunction.Minor7b5, new[] {Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh}},
                {ChordFunction.MinorMaj7, new[] {Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh}},
                {ChordFunction.Augmented7, new[] {Interval.MajorThird, Interval.AugmentedFifth, Interval.MajorSeventh}},
            };

        [Theory]
        [MemberData(nameof(FunctionsAndIntervals))]
        public void RelateFunctionsAndIntervals(ChordFunction expectedFunction, IEnumerable<Interval> intervals)
        {
            ChordFunction.FunctionForIntervals(intervals).Should().Be(expectedFunction);
        }
    }
}