using System.Collections.Generic;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Chords
{
    public class FunctionShould
    {
        public static TheoryData<Function, string, int> Functions 
           => new TheoryData<Function, string, int>
           {
               { Function.Root, "R", 0 },
               { Function.Third, "3", 1 },
               { Function.Fifth, "5", 2 },
               { Function.Seventh, "7", 3 },
               { Function.Ninth, "9", 4 },
               { Function.Eleventh, "11", 5 },
               { Function.Thirteenth, "13", 6 },
           };

        [Theory, MemberData(nameof(Functions))]
        public void RelateFunctionToNAmeAndIndex(Function function, string name, int index)
        {
            function.Name.Should().Be(name);
            function.Index.Should().Be(index);
        }


        public static TheoryData<Function, IList<Interval>> FunctionsAndIntervals
                   => new TheoryData<Function, IList<Interval>>
                   {
                       { Function.Root, new [] {Interval.Unisson} },
                       { Function.Third, new [] {Interval.MajorThird, Interval.MinorThird } },
                       { Function.Fifth, new [] {Interval.PerfectFifth, Interval.AugmentedFifth, Interval.DiminishedFifth } },
                       { Function.Seventh, new [] {Interval.MinorSeventh, Interval.MajorSeventh } },
                   };

        [Theory, MemberData(nameof(FunctionsAndIntervals))]
        public void RelateFunctionToIntervals(Function function, IEnumerable<Interval> expectedIntervals)
        {
            foreach (var interval in expectedIntervals)
            {
                Function.FunctionForInterval(interval).Should().Be(function);
            }
        }
    }
}