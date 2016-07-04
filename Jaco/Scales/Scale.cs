using System;
using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Scales
{
    public class Scale
    {
        private static readonly IReadOnlyCollection<Note> Fifths = new List<Note>
        {
            Note.F,
            Note.C,
            Note.G,
            Note.D,
            Note.A,
            Note.E,
            Note.B
        };

        public static readonly Scale AMajor = new Lazy<Scale>(() => new Scale(Note.A, 3, ScaleQuality.Major)).Value;
        public static readonly Scale AFlatMajor = new Lazy<Scale>(() => new Scale(Note.AFlat, -4, ScaleQuality.Major)).Value;
        public static readonly Scale BMajor = new Lazy<Scale>(() => new Scale(Note.B, 5, ScaleQuality.Major)).Value;
        public static readonly Scale BFlatMajor = new Lazy<Scale>(() => new Scale(Note.BFlat, -2, ScaleQuality.Major)).Value;
        public static readonly Scale CMajor = new Lazy<Scale>(() => new Scale(Note.C, 0, ScaleQuality.Major)).Value;
        public static readonly Scale CSharpMajor = new Lazy<Scale>(() => new Scale(Note.CSharp, 7, ScaleQuality.Major)).Value;
        public static readonly Scale DMajor = new Lazy<Scale>(() => new Scale(Note.D, 2, ScaleQuality.Major)).Value;
        public static readonly Scale DFlatMajor = new Lazy<Scale>(() => new Scale(Note.DFlat, -5, ScaleQuality.Major)).Value;
        public static readonly Scale EMajor = new Lazy<Scale>(() => new Scale(Note.E, 4, ScaleQuality.Major)).Value;
        public static readonly Scale EFlatMajor = new Lazy<Scale>(() => new Scale(Note.EFlat, -3, ScaleQuality.Major)).Value;
        public static readonly Scale FMajor = new Lazy<Scale>(() => new Scale(Note.F, -1, ScaleQuality.Major)).Value;
        public static readonly Scale FSharpMajor = new Lazy<Scale>(() => new Scale(Note.FSharp, 6, ScaleQuality.Major)).Value;
        public static readonly Scale GMajor = new Lazy<Scale>(() => new Scale(Note.G, 1, ScaleQuality.Major)).Value;
        public static readonly Scale GFlatMajor = new Lazy<Scale>(() => new Scale(Note.GFlat, -6, ScaleQuality.Major)).Value;
        public static readonly Scale AMinor = new Lazy<Scale>(() => new Scale(Note.A, 0, ScaleQuality.Minor)).Value;
        public static readonly Scale AFlatMinor = new Lazy<Scale>(() => new Scale(Note.AFlat, -7, ScaleQuality.Minor)).Value;
        public static readonly Scale ASharpMinor = new Lazy<Scale>(() => new Scale(Note.ASharp, 7, ScaleQuality.Minor)).Value;
        public static readonly Scale BMinor = new Lazy<Scale>(() => new Scale(Note.B, 2, ScaleQuality.Minor)).Value;
        public static readonly Scale BFlatMinor = new Lazy<Scale>(() => new Scale(Note.BFlat, -5, ScaleQuality.Minor)).Value;
        public static readonly Scale CMinor = new Lazy<Scale>(() => new Scale(Note.C, -3, ScaleQuality.Minor)).Value;
        public static readonly Scale CSharpMinor = new Lazy<Scale>(() => new Scale(Note.CSharp, 4, ScaleQuality.Minor)).Value;
        public static readonly Scale DMinor = new Lazy<Scale>(() => new Scale(Note.D, -1, ScaleQuality.Minor)).Value;
        public static readonly Scale DSharpMinor = new Lazy<Scale>(() => new Scale(Note.DFlat, 6, ScaleQuality.Minor)).Value;
        public static readonly Scale EMinor = new Lazy<Scale>(() => new Scale(Note.E, 1, ScaleQuality.Minor)).Value;
        public static readonly Scale FMinor = new Lazy<Scale>(() => new Scale(Note.F, -4, ScaleQuality.Minor)).Value;
        public static readonly Scale FSharpMinor = new Lazy<Scale>(() => new Scale(Note.FSharp, 3, ScaleQuality.Minor)).Value;
        public static readonly Scale GMinor = new Lazy<Scale>(() => new Scale(Note.G, -2, ScaleQuality.Minor)).Value;
        public static readonly Scale GSharpMinor = new Lazy<Scale>(() => new Scale(Note.GSharp, 5, ScaleQuality.Minor)).Value;
        public static readonly Scale EFlatMinor = new Lazy<Scale>(() => new Scale(Note.EFlat, -6, ScaleQuality.Minor)).Value;

        private readonly int accidentals;

        public ScaleQuality Quality { get; }

        protected Scale(Note root, int accidentals, ScaleQuality quality)
        {
            Quality = quality;
            this.accidentals = accidentals;

            Notes = GenerateScaleNotes();
            OrderScaleNotes(root);

            const string major = "Major";
            const string minor = "Minor";

            Name = root.Name + " " + (quality == ScaleQuality.Major ? major : minor);
        }

        public string Name { get; }

        public IEnumerable<Note> Notes { get; private set; }

        public static IEnumerable<Scale> Scales
        {
            get
            {
                yield return AMajor;
                yield return AFlatMajor;
                yield return BMajor;
                yield return BFlatMajor;
                yield return CMajor;
                yield return CSharpMajor;
                yield return DMajor;
                yield return DFlatMajor;
                yield return EMajor;
                yield return EFlatMajor;
                yield return FMajor;
                yield return FSharpMajor;
                yield return GMajor;
                yield return GFlatMajor;
                yield return AMinor;
                yield return AFlatMinor;
                yield return ASharpMinor;
                yield return BMinor;
                yield return BFlatMinor;
                yield return CMinor;
                yield return CSharpMinor;
                yield return DMinor;
                yield return DSharpMinor;
                yield return EMinor;
                yield return FMinor;
                yield return FSharpMinor;
                yield return GMinor;
                yield return GSharpMinor;
                yield return EFlatMinor;
            }
        }

        public Note I => Notes.ElementAt(0);

        public Note II => Notes.ElementAt(1);

        public Note III => Notes.ElementAt(2);

        public Note IV => Notes.ElementAt(3);

        public Note V => Notes.ElementAt(4);

        public Note VI => Notes.ElementAt(5);

        public Note VII => Notes.ElementAt(6);

        public Note HarmonicI => I;

        public Note HarmonicII => II;

        public Note HarmonicIII => III;

        public Note HarmonicIV => IV;

        public Note HarmonicV => V;

        public Note HarmonicVI => VI;

        public Note HarmonicVII => Quality == ScaleQuality.Minor ? VII.Sharp() : VII;

        public static Scale ScaleForRootAndQuality(Note root, ScaleQuality quality)
        {
            return Scales.First(k => k.I == root && k.Quality == quality);
        }

        public bool DoesNoteBelongToScale(Note note)
        {
            return Notes.Any(n => n.Name == note.Name);
        }

        public Scale Relative()
        {
            return Quality == ScaleQuality.Major
                ? ScaleForRootAndQuality(VI, ScaleQuality.Minor).OrderScaleNotes(VI)
                : ScaleForRootAndQuality(III, ScaleQuality.Major).OrderScaleNotes(III);
        }

        private IEnumerable<Note> GenerateScaleNotes()
        {
            if (accidentals == 0)
            {
                return Fifths;
            }

            return accidentals < 0
                       ? Fifths.Reverse()
                               .Take(-accidentals)
                               .Select(n => n.Flat())
                               .Union(Fifths.Reverse().Skip(-accidentals))
                               .ToList()
                       : Fifths
                            .Take(accidentals)
                            .Select(n => n.Sharp())
                            .Union(Fifths.Skip(accidentals))
                            .ToList();
        }

        private Scale OrderScaleNotes(Note rootNote)
        {
            var enumerable = Notes.OrderBy(n => n.Pitch).ToList();

            Notes =
                enumerable.SkipWhile(n => n.Name != rootNote.Name)
                          .Union(enumerable.TakeWhile(n => n.Name != rootNote.Name));

            return this;
        }
    }
}
