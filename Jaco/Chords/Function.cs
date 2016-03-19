using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Chords
{
    public class Function
    {
        public static readonly Function Root = new Function("R", new [] {Interval.Unisson});
        public static readonly Function Third = new Function("3", new [] {Interval.MajorThird, Interval.MinorThird });
        public static readonly Function Fifth = new Function("5", new [] {Interval.PerfectFifth, Interval.AugmentedFifth, Interval.DiminishedFifth });
        public static readonly Function Seventh = new Function("7", new [] {Interval.MinorSeventh, Interval.MajorSeventh });
        public static readonly Function Ninth = new Function("9", new List<Interval>());
        public static readonly Function Eleventh = new Function("11", new List<Interval>());
        public static readonly Function Thirteenth = new Function("13", new List<Interval>());

        private readonly IList<Interval> _distanceFromRoot;

        public string Name { get; }

        public Function(string name, IList<Interval> distanceFromRoot)
        {
            Name = name;
            _distanceFromRoot = distanceFromRoot;
        }

        public static IEnumerable<Function> Functions
        {
            get
            {
                yield return Root;
                yield return Third;
                yield return Fifth;
                yield return Seventh;
                yield return Ninth;
                yield return Eleventh;
                yield return Thirteenth;
            }
        }

        public int Index
        {
            get
            {
                var index = 0;
                foreach (var element in Functions)
                {
                    if (element == this)
                    {
                        return index;
                    }

                    index++;
                }

                return index;
            }
        }

        public static Function FunctionForInterval(Interval interval)
        {
            return Functions.First(f => f._distanceFromRoot.Contains(interval));
        }
    }
}