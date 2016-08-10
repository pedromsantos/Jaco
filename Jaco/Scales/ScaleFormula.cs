using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Scales
{
    public class Scale
    {
        private readonly IEnumerable<Note> _notes;

        public Scale(IEnumerable<Note> notes)
        {
            this._notes = notes;
        }

        public IEnumerable<Note> Notes => _notes;

        public Note I => _notes.ElementAt(0);

        public Note II => _notes.ElementAt(1);

        public Note III => _notes.ElementAt(2);

        public Note IV => _notes.ElementAt(3);

        public Note V => _notes.ElementAt(4);

        public Note VI => _notes.ElementAt(5);

        public Note VII => _notes.ElementAt(6);
    }

    public class ScaleFormula
    {
        private readonly IEnumerable<Interval> _intervals;

        public static readonly ScaleFormula Ionian = new ScaleFormula(
            new[] {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MajorSeventh}
        );

        public static readonly ScaleFormula Dorian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MinorSeventh
            }
        );

        public static readonly ScaleFormula Phrygian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MinorSixth,
                Interval.MinorSeventh
            }
        );

        public static readonly ScaleFormula Lydian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.AugmentedForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MajorSeventh
            });

        public static readonly ScaleFormula Mixolydian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula Aolian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MinorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula Locrian = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MinorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.DiminishedFifth,
                Interval.MinorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula MajorPentatonic = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.PerfectFifth,
                Interval.MajorSixth
            });

        public static readonly ScaleFormula MinorPentatonic = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula Blues = new ScaleFormula(
            new[] {
                Interval.Unisson,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.DiminishedFifth,
                Interval.PerfectFifth,
                Interval.MinorSeventh});

        public static readonly ScaleFormula HarmonicMinor = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MinorSixth,
                Interval.MajorSeventh
            });

        public static readonly ScaleFormula MelodicMinor = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MajorSeventh
            });

        public static readonly ScaleFormula Dorianb2 = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MinorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula LydianAugmented = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.AugmentedForth,
                Interval.AugmentedFifth,
                Interval.MajorSixth,
                Interval.MajorSeventh
            });

        public static readonly ScaleFormula LydianDominant = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.AugmentedForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula Mixolydianb6 = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.PerfectForth,
                Interval.PerfectFifth,
                Interval.MinorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula LocrianSharp2 = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MinorThird,
                Interval.PerfectForth,
                Interval.DiminishedFifth,
                Interval.MinorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula AlteredDominant = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MinorSecond,
                Interval.AugmentedSecond,
                Interval.MajorThird,
                Interval.DiminishedFifth,
                Interval.AugmentedFifth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula HalfWholeDiminished = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MinorSecond,
                Interval.MinorThird,
                Interval.MajorThird,
                Interval.AugmentedForth,
                Interval.PerfectFifth,
                Interval.MajorSixth,
                Interval.MinorSeventh
            });

        public static readonly ScaleFormula WholeTone = new ScaleFormula(
            new[]
            {
                Interval.Unisson,
                Interval.MajorSecond,
                Interval.MajorThird,
                Interval.DiminishedFifth,
                Interval.AugmentedFifth,
                Interval.MinorSeventh
            });

        protected ScaleFormula(IEnumerable<Interval> intervals)
        {
            _intervals = intervals;
        }

        public Scale CreateForRoot(Note root)
        {
            return new Scale(_intervals.Select(root.Transpose));
        }
    }
}