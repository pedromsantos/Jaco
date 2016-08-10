using System.Collections.Generic;
using System.Linq;

namespace Jaco.Notes
{
    public class Note
    {
        public static readonly Note C = new Note(Pitch.C, "C", Accident.None, MinNoteIndex);
        public static readonly Note CSharp = new Note(Pitch.CSharp, "C#", Accident.Sharp, 1);
        public static readonly Note DFlat = new Note(Pitch.DFlat, "Db", Accident.Flat, 2);
        public static readonly Note D =new Note(Pitch.D, "D", Accident.None, 3);
        public static readonly Note DSharp = new Note(Pitch.DSharp, "D#", Accident.Sharp, 4);
        public static readonly Note EFlat = new Note(Pitch.EFlat, "Eb", Accident.Flat, 5);
        public static readonly Note E = new Note(Pitch.E, "E", Accident.None, 6);
        public static readonly Note F = new Note(Pitch.F, "F", Accident.None, 7);
        public static readonly Note FSharp = new Note(Pitch.FSharp, "F#", Accident.Sharp, 8);
        public static readonly Note GFlat = new Note(Pitch.GFlat, "Gb", Accident.Flat, 9);
        public static readonly Note G = new Note(Pitch.G, "G", Accident.None, 10);
        public static readonly Note GSharp = new Note(Pitch.GSharp, "G#", Accident.Sharp, 11);
        public static readonly Note AFlat = new Note(Pitch.AFlat, "Ab", Accident.Flat, 12);
        public static readonly Note A = new Note(Pitch.A, "A", Accident.None, 13);
        public static readonly Note ASharp = new Note(Pitch.ASharp, "A#", Accident.Sharp, 14);
        public static readonly Note BFlat = new Note(Pitch.BFlat, "Bb", Accident.Flat, 15);
        public static readonly Note B = new Note(Pitch.B, "B", Accident.None, MaxNoteIndex);

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

        private const int MinNoteIndex = 0;
        private const int MaxNoteIndex = 16;

        private readonly int index;
        private readonly Accident accident;

        private Note(Pitch pitch, string name, Accident accident, int index)
        {
            this.index = index;
            this.accident = accident;
            Pitch = pitch;
            Name = name;
        }

        public string Name { get; }

        public Pitch Pitch { get; }

        public Note Sharp() => Transpose(Accident.Sharp);

        public Note Flat() => Transpose(Accident.Flat);

        public Interval IntervalWithOther(Note other) =>
            Interval.CreateIntervalFromDistance(MeasureAbsoluteSemitones(other));

        public Note Transpose(Interval transposingInterval)
        {
            var interval = Interval.Unisson;
            var resultingNote = this;

            while (interval.Distance != transposingInterval.Distance)
            {
                resultingNote = transposingInterval.TransposeNote(resultingNote);
                interval = IntervalWithOther(resultingNote);
            }

            return resultingNote;
        }

        public int MeasureAbsoluteSemitones(Note other)
        {
            const int octave = 12;
            const int unisson = 0;

            var distance = other.Pitch - Pitch;

            return distance < unisson ? octave - distance*-1 : distance;
        }

        private Note Transpose(Accident forAccident) =>
            Notes.ElementAt(NoteIndex(forAccident));

        private int NoteIndex(Accident forAccident) =>
            WrapIndex(index + (int) forAccident*(accident == forAccident ? 2 : 1));

        private static int WrapIndex(int indexForNote)
        {
            return indexForNote < MinNoteIndex
                ? MaxNoteIndex
                : indexForNote > MaxNoteIndex
                    ? MinNoteIndex
                    : indexForNote;
        }
    }
}