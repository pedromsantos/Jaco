using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public class ChordFunction
    {
        public static readonly ChordFunction Major = new ChordFunction("Maj", Interval.MajorThird, Interval.PerfectFifth);
        public static readonly ChordFunction Augmented = new ChordFunction("Aug", Interval.MajorThird, Interval.AugmentedFifth);
        public static readonly ChordFunction Minor = new ChordFunction("Min", Interval.MinorThird, Interval.PerfectFifth);
        public static readonly ChordFunction Diminished = new ChordFunction("Dim", Interval.MinorThird, Interval.DiminishedFifth);
        public static readonly ChordFunction Sus2 = new ChordFunction("Sus2", Interval.MajorSecond, Interval.PerfectFifth);
        public static readonly ChordFunction Sus2Diminished = new ChordFunction("Sus2Dim", Interval.MajorSecond, Interval.DiminishedFifth);
        public static readonly ChordFunction Sus2Augmented = new ChordFunction("Sus2Aug", Interval.MajorSecond, Interval.AugmentedFifth);
        public static readonly ChordFunction Sus4 = new ChordFunction("Sus4", Interval.PerfectForth, Interval.PerfectFifth);
        public static readonly ChordFunction Sus4Diminished = new ChordFunction("Sus4Dim", Interval.PerfectForth, Interval.DiminishedFifth);
        public static readonly ChordFunction Sus4Augmented = new ChordFunction("Sus4Aug", Interval.PerfectForth, Interval.AugmentedFifth);
        public static readonly ChordFunction Major7 = new ChordFunction("Maj7", Interval.MajorThird, Interval.PerfectFifth, Interval.MajorSeventh);
        public static readonly ChordFunction Dominant7 = new ChordFunction("Dom7", Interval.MajorThird, Interval.PerfectFifth, Interval.MinorSeventh);
        public static readonly ChordFunction Minor7b5 = new ChordFunction("Min7b5", Interval.MinorThird, Interval.DiminishedFifth, Interval.MinorSeventh);
        public static readonly ChordFunction Diminished7 = new ChordFunction("Dim7", Interval.MinorThird, Interval.DiminishedFifth, Interval.MajorSixth);
        public static readonly ChordFunction Minor7 = new ChordFunction("Min7", Interval.MinorThird, Interval.PerfectFifth, Interval.MinorSeventh);
        public static readonly ChordFunction MinorMaj7 = new ChordFunction("MinMaj7", Interval.MinorThird, Interval.PerfectFifth, Interval.MajorSeventh);
        public static readonly ChordFunction Augmented7 = new ChordFunction("Aug7", Interval.MajorThird, Interval.AugmentedFifth, Interval.MajorSeventh);

        public ChordFunction(string abreviatedName, params Interval[] intervals)
        {
            AbreviatedName = abreviatedName;
            Intervals = intervals;
        }

        public string AbreviatedName { get; }

        public IEnumerable<Interval> Intervals { get; }

        public static ChordFunction FunctionForIntervals(IEnumerable<Interval> intervals)
        {
            return Functions.First(f => f.Intervals.SequenceEqual(intervals));
        }

        private static IEnumerable<ChordFunction> Functions
        {
            get
            {
                yield return Major;
                yield return Augmented;
                yield return Minor;
                yield return Diminished;
                yield return Sus2;
                yield return Sus2Diminished;
                yield return Sus2Augmented;
                yield return Sus4;
                yield return Sus4Diminished;
                yield return Sus4Augmented;
                yield return Major7;
                yield return Dominant7;
                yield return Minor7b5;
                yield return Diminished7;
                yield return Minor7;
                yield return MinorMaj7;
                yield return Augmented7;
            }
        }
    }
}