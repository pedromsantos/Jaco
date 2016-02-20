using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public class Note
    {
        public static readonly Note C = new Note(Pitch.C, "C");
        public static readonly Note CSharp = new Note(Pitch.CSharp, "C#");
        public static readonly Note DFlat = new Note(Pitch.DFlat, "Db");
        public static readonly Note D = new Note(Pitch.D, "D");
        public static readonly Note DSharp = new Note(Pitch.DSharp, "D#");
        public static readonly Note EFlat = new Note(Pitch.EFlat, "Eb");
        public static readonly Note E = new Note(Pitch.E, "E");
        public static readonly Note F = new Note(Pitch.F, "F");
        public static readonly Note FSharp = new Note(Pitch.FSharp, "F#");
        public static readonly Note GFlat = new Note(Pitch.GFlat, "Gb");
        public static readonly Note G = new Note(Pitch.G, "G");
        public static readonly Note GSharp = new Note(Pitch.GSharp, "G#");
        public static readonly Note AFlat = new Note(Pitch.AFlat, "Ab");
        public static readonly Note A = new Note(Pitch.A, "A");
        public static readonly Note ASharp = new Note(Pitch.ASharp, "A#");
        public static readonly Note BFlat = new Note(Pitch.BFlat, "Bb");
        public static readonly Note B = new Note(Pitch.B, "B");

        public static IEnumerable<Note> Notes
        {
            get
            {
                yield return C;
                yield return CSharp;
                yield return DFlat;
                yield return D;
                yield return DSharp;
                yield return EFlat;
                yield return E;
                yield return F;
                yield return FSharp;
                yield return GFlat;
                yield return G;
                yield return GSharp;
                yield return AFlat;
                yield return A;
                yield return ASharp;
                yield return BFlat;
                yield return B;
            }
        }
 
        public static implicit operator int(Note instance)
        {
            return (int) instance.Pitch;
        }

        private Note(Pitch pitch, string name)
        {
            Pitch = pitch;
            Name = name;
        }

        public string Name { get; }

        public Pitch Pitch { get; } 

        public Note Sharp()
        {
            if (Index <= Notes.Count() - 1)
            {
                var step = 1;

                if (Name.EndsWith("#"))
                {
                    step++;
                }

                if (Index + step <= Notes.Count() - 1)
                {
                    return Notes.ElementAt(Index + step);
                }
            }

            return Notes.First();
        }

        public Note Flat()
        {
            if (Index > 0)
            {
                var step = 1;

                if (Name.EndsWith("b"))
                {
                    step++;
                }

                if (Index - step >= 0)
                {
                    return Notes.ElementAt(Index - step);
                }
            }

            return Notes.Last();
        }

        public Interval IntervalWithOther(Note other)
        {
            var distance = MeasureAbsoluteSemitones(other);

            return Interval.CreateIntervalFromDistance(distance);
        }

        public Note Transpose(Interval transposingInterval)
        {
            var interval = Interval.Unisson;
            var resultingNote = this;

            while (interval != transposingInterval)
            {
                resultingNote = interval - transposingInterval > 0
                    ? resultingNote.Flat()
                    : resultingNote.Sharp();

                interval = IntervalWithOther(resultingNote);
            }

            return resultingNote;
        }

        private int Index
        {
            get
            {
                var index = 0;
                foreach (var element in Notes)
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

        private int MeasureAbsoluteSemitones(Note other)
        {
            var distance = other - this;

            return distance < 0 ? 12 - distance*-1 : distance;
        }
    }
}