using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public class Note
    {
        private static readonly Lazy<Note> LazzyC = new Lazy<Note>(() => new Note(Pitch.C, "C", Accident.None, MinNoteIndex));
        private static readonly Lazy<Note> LazzyCSharp = new Lazy<Note>(() => new Note(Pitch.CSharp, "C#", Accident.Sharp, 1));
        private static readonly Lazy<Note> LazzyDFlat = new Lazy<Note>(() => new Note(Pitch.DFlat, "Db", Accident.Flat, 2));
        private static readonly Lazy<Note> LazzyD = new Lazy<Note>(() => new Note(Pitch.D, "D", Accident.None, 3));
        private static readonly Lazy<Note> LazzyDSharp = new Lazy<Note>(() => new Note(Pitch.DSharp, "D#", Accident.Sharp, 4));
        private static readonly Lazy<Note> LazzyEFlat = new Lazy<Note>(() => new Note(Pitch.EFlat, "Eb", Accident.Flat, 5));
        private static readonly Lazy<Note> LazzyE = new Lazy<Note>(() => new Note(Pitch.E, "E", Accident.None, 6));
        private static readonly Lazy<Note> LazzyF = new Lazy<Note>(() => new Note(Pitch.F, "F", Accident.None, 7));
        private static readonly Lazy<Note> LazzyFSharp = new Lazy<Note>(() => new Note(Pitch.FSharp, "F#", Accident.Sharp, 8));
        private static readonly Lazy<Note> LazzyGFlat = new Lazy<Note>(() => new Note(Pitch.GFlat, "Gb", Accident.Flat, 9));
        private static readonly Lazy<Note> LazzyG = new Lazy<Note>(() => new Note(Pitch.G, "G", Accident.None, 10));
        private static readonly Lazy<Note> LazzyGSharp = new Lazy<Note>(() => new Note(Pitch.GSharp, "G#", Accident.Sharp, 11));
        private static readonly Lazy<Note> LazzyAFlat = new Lazy<Note>(() => new Note(Pitch.AFlat, "Ab", Accident.Flat, 12));
        private static readonly Lazy<Note> LazzyA = new Lazy<Note>(() => new Note(Pitch.A, "A", Accident.None, 13));
        private static readonly Lazy<Note> LazzyASharp = new Lazy<Note>(() => new Note(Pitch.ASharp, "A#", Accident.Sharp, 14));
        private static readonly Lazy<Note> LazzyBFlat = new Lazy<Note>(() => new Note(Pitch.BFlat, "Bb", Accident.Flat, 15));
        private static readonly Lazy<Note> LazzyB = new Lazy<Note>(() => new Note(Pitch.B, "B", Accident.None, MaxNoteIndex));

        public static Note C => LazzyC.Value;
        public static Note CSharp => LazzyCSharp.Value;
        public static Note DFlat => LazzyDFlat.Value;
        public static Note D => LazzyD.Value;
        public static Note DSharp => LazzyDSharp.Value;
        public static Note EFlat => LazzyEFlat.Value;
        public static Note E => LazzyE.Value;
        public static Note F => LazzyF.Value;
        public static Note FSharp => LazzyFSharp.Value;
        public static Note GFlat => LazzyGFlat.Value;
        public static Note G => LazzyG.Value;
        public static Note GSharp => LazzyGSharp.Value;
        public static Note AFlat => LazzyAFlat.Value;
        public static Note A => LazzyA.Value;
        public static Note ASharp => LazzyASharp.Value;
        public static Note BFlat => LazzyBFlat.Value;
        public static Note B => LazzyB.Value;

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

        private const int MinNoteIndex = 0;
        private const int MaxNoteIndex = 16;

        private readonly int index;

        private Note(Pitch pitch, string name, Accident accident, int index)
        {
            this.index = index;
            Pitch = pitch;
            Name = name;
            Accident = accident;
        }

        public string Name { get; }

        public Accident Accident { get; set; }

        public Pitch Pitch { get; }

        public Note Sharp()
        {
            return Transpose(Accident.Sharp);
        } 

        public Note Flat()
        {
            return Transpose(Accident.Flat);
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

        public int MeasureAbsoluteSemitones(Note other)
        {
            var distance = other - this;

            return distance < 0 ? 12 - distance * -1 : distance;
        }

        private Note Transpose(Accident accident)
        {
            return NoteAtIndex(CalculateNoteIndexForAccident(accident));
        }

        private Note NoteAtIndex(int indexForNote)
        {
            return indexForNote < MinNoteIndex
                ? B
                : indexForNote > MaxNoteIndex
                    ? C
                    : Notes.ElementAt(indexForNote);
        }

        private int CalculateNoteIndexForAccident(Accident accident)
        {
            return index + (int)accident * (Accident == accident ? 2 : 1);
        }

        public static bool operator >(Note noteA, Note noteB)
        {
            return noteA.Pitch > noteB.Pitch;
        }

        public static bool operator <(Note noteA, Note noteB)
        {
            return noteA.Pitch < noteB.Pitch;
        }
    }
}