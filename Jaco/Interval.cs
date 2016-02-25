using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public class Interval : IComparable<Interval>
    {
        public static readonly Interval Unisson = new Interval(0);
        public static readonly Interval MinorSecond = new Interval(1);
        public static readonly Interval MajorSecond = new Interval(2);
        public static readonly Interval MinorThird = new Interval(3);
        public static readonly Interval MajorThird = new Interval(4);
        public static readonly Interval PerfectForth = new Interval(5);
        public static readonly Interval DiminishedFifth = new Interval(6);
        public static readonly Interval PerfectFifth = new Interval(7);
        public static readonly Interval AugmentedFifth = new Interval(8);
        public static readonly Interval MajorSixth = new Interval(9);
        public static readonly Interval MinorSeventh = new Interval(10);
        public static readonly Interval MajorSeventh = new Interval(11);
        public static readonly Interval PerfectOctave = new Interval(12);

        private readonly int distance;

        private Interval(int distance)
        {
            this.distance = distance;
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
            return Intervals.Single(interval => interval.distance == distance);
        }

        public static Interval operator -(Interval intervalA, Interval intervalB)
        {
            var difference = Math.Abs(intervalA.distance - intervalB.distance);
            return Intervals.Single(interval => interval.distance == difference);
        }

        public static bool operator >(Interval intervalA, Interval intervalB)
        {
            return intervalA.distance > intervalB.distance;
        }

        public static bool operator <(Interval intervalA, Interval intervalB)
        {
            return intervalA.distance < intervalB.distance;
        }

        public static bool operator >(Interval intervalA, int distance)
        {
            return intervalA.distance > distance;
        }

        public static bool operator <(Interval intervalA, int distance)
        {
            return intervalA.distance < distance;
        }

        public int CompareTo(Interval other)
        {
            return distance.CompareTo(other.distance);
        }
    }
}