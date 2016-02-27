using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaco.Notes
{
    public class Interval : IComparable<Interval>
    {
        public static readonly Interval Unisson = new Interval(0, "Unisson");
        public static readonly Interval MinorSecond = new Interval(1, "Minor second");
        public static readonly Interval MajorSecond = new Interval(2, "Major second");
        public static readonly Interval MinorThird = new Interval(3, "Minor third");
        public static readonly Interval MajorThird = new Interval(4, "Major third");
        public static readonly Interval PerfectForth = new Interval(5, "Perfect fourth");
        public static readonly Interval DiminishedFifth = new Interval(6, "Diminished fifth");
        public static readonly Interval PerfectFifth = new Interval(7, "Perfect fifth");
        public static readonly Interval AugmentedFifth = new Interval(8, "Augmented fifth");
        public static readonly Interval MajorSixth = new Interval(9, "Major sixth");
        public static readonly Interval MinorSeventh = new Interval(10, "Minor seventh");
        public static readonly Interval MajorSeventh = new Interval(11, "Major seventh");
        public static readonly Interval PerfectOctave = new Interval(12, "Perfect octave");

        public int Distance { get; }

        public string Name { get; }

        private Interval(int distance, string name)
        {
            Distance = distance;
            Name = name;
        }

        public static IEnumerable<Interval> Intervals
        {
            get
            {
                yield return Unisson;
                yield return MinorSecond;
                yield return MajorSecond;
                yield return MinorThird;
                yield return MajorThird;
                yield return PerfectForth;
                yield return DiminishedFifth;
                yield return PerfectFifth;
                yield return AugmentedFifth;
                yield return MajorSixth;
                yield return MinorSeventh;
                yield return MajorSeventh;
                yield return PerfectOctave;
            }
        }

        public static Interval CreateIntervalFromDistance(int distance)
        {
            return Intervals.Single(interval => interval.Distance == distance);
        }

        public static Interval operator -(Interval intervalA, Interval intervalB)
        {
            var difference = Math.Abs(intervalA.Distance - intervalB.Distance);
            return Intervals.Single(interval => interval.Distance == difference);
        }

        public static bool operator >(Interval intervalA, Interval intervalB)
        {
            return intervalA.Distance > intervalB.Distance;
        }

        public static bool operator <(Interval intervalA, Interval intervalB)
        {
            return intervalA.Distance < intervalB.Distance;
        }

        public static bool operator >(Interval intervalA, int distance)
        {
            return intervalA.Distance > distance;
        }

        public static bool operator <(Interval intervalA, int distance)
        {
            return intervalA.Distance < distance;
        }

        public int CompareTo(Interval other)
        {
            return Distance.CompareTo(other.Distance);
        }
    }
}