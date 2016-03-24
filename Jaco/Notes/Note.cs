using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaco.Notes
{
    public class Note
    {
        public static readonly Note C = new Lazy<Note>(() => new Note(Pitch.C, "C", Accident.None, MinNoteIndex)).Value;
        public static readonly Note CSharp = new Lazy<Note>(() => new Note(Pitch.CSharp, "C#", Accident.Sharp, 1)).Value;
        public static readonly Note DFlat = new Lazy<Note>(() => new Note(Pitch.DFlat, "Db", Accident.Flat, 2)).Value;
        public static readonly Note D = new Lazy<Note>(() => new Note(Pitch.D, "D", Accident.None, 3)).Value;
        public static readonly Note DSharp = new Lazy<Note>(() => new Note(Pitch.DSharp, "D#", Accident.Sharp, 4)).Value;
        public static readonly Note EFlat = new Lazy<Note>(() => new Note(Pitch.EFlat, "Eb", Accident.Flat, 5)).Value;
        public static readonly Note E = new Lazy<Note>(() => new Note(Pitch.E, "E", Accident.None, 6)).Value;
        public static readonly Note F = new Lazy<Note>(() => new Note(Pitch.F, "F", Accident.None, 7)).Value;
        public static readonly Note FSharp = new Lazy<Note>(() => new Note(Pitch.FSharp, "F#", Accident.Sharp, 8)).Value;
        public static readonly Note GFlat = new Lazy<Note>(() => new Note(Pitch.GFlat, "Gb", Accident.Flat, 9)).Value;
        public static readonly Note G = new Lazy<Note>(() => new Note(Pitch.G, "G", Accident.None, 10)).Value;

        public static readonly Note GSharp =
            new Lazy<Note>(() => new Note(Pitch.GSharp, "G#", Accident.Sharp, 11)).Value;

        public static readonly Note AFlat = new Lazy<Note>(() => new Note(Pitch.AFlat, "Ab", Accident.Flat, 12)).Value;
        public static readonly Note A = new Lazy<Note>(() => new Note(Pitch.A, "A", Accident.None, 13)).Value;

        public static readonly Note ASharp =
            new Lazy<Note>(() => new Note(Pitch.ASharp, "A#", Accident.Sharp, 14)).Value;

        public static readonly Note BFlat = new Lazy<Note>(() => new Note(Pitch.BFlat, "Bb", Accident.Flat, 15)).Value;
        public static readonly Note B = new Lazy<Note>(() => new Note(Pitch.B, "B", Accident.None, MaxNoteIndex)).Value;

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

        private Note(Pitch pitch, string name, Accident accident, int index)
        {
            this.index = index;
            Pitch = pitch;
            Name = name;
            Accident = accident;
        }

        public string Name { get; }

        public Accident Accident { get; }

        public Pitch Pitch { get; }

        public Note Sharp() => Transpose(Accident.Sharp);

        public Note Flat() => Transpose(Accident.Flat);

        public Interval IntervalWithOther(Note other) =>
            Interval.CreateIntervalFromDistance(MeasureAbsoluteSemitones(other));

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
            const int octave = 12;
            const int unisson = 0;

            var distance = other.Pitch - Pitch;

            return distance < unisson ? octave - distance*-1 : distance;
        }

        private Note Transpose(Accident accident) =>
            Notes.ElementAt(CalculateNoteIndexForAccident(accident));

        private int CalculateNoteIndexForAccident(Accident accident) =>
            WrapIndex(index + (int) accident*(Accident == accident ? 2 : 1));

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