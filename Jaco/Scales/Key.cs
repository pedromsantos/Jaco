using System;
using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Scales
{
    public class Key
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

        public static readonly Key AMajor = new Key(Note.A, 3, KeyQuality.Major);
        public static readonly Key AFlatMajor = new Key(Note.AFlat, -4, KeyQuality.Major);
        public static readonly Key BMajor = new Key(Note.B, 5, KeyQuality.Major);
        public static readonly Key BFlatMajor = new Key(Note.BFlat, -2, KeyQuality.Major);
        public static readonly Key CMajor = new Key(Note.C, 0, KeyQuality.Major);
        public static readonly Key CSharpMajor = new Key(Note.CSharp, 7, KeyQuality.Major);
        public static readonly Key DMajor = new Key(Note.D, 2, KeyQuality.Major);
        public static readonly Key DFlatMajor = new Key(Note.DFlat, -5, KeyQuality.Major);
        public static readonly Key EMajor = new Key(Note.E, 4, KeyQuality.Major);
        public static readonly Key EFlatMajor = new Key(Note.EFlat, -3, KeyQuality.Major);
        public static readonly Key FMajor = new Key(Note.F, -1, KeyQuality.Major);
        public static readonly Key FSharpMajor = new Key(Note.FSharp, 6, KeyQuality.Major);
        public static readonly Key GMajor = new Key(Note.G, 1, KeyQuality.Major);
        public static readonly Key GFlatMajor = new Key(Note.GFlat, -6, KeyQuality.Major);
        public static readonly Key AMinor = new Key(Note.A, 0, KeyQuality.Minor);
        public static readonly Key AFlatMinor = new Key(Note.AFlat, -7, KeyQuality.Minor);
        public static readonly Key ASharpMinor = new Key(Note.ASharp, 7, KeyQuality.Minor);
        public static readonly Key BMinor = new Key(Note.B, 2, KeyQuality.Minor);
        public static readonly Key BFlatMinor = new Key(Note.BFlat, -5, KeyQuality.Minor);
        public static readonly Key CMinor = new Key(Note.C, -3, KeyQuality.Minor);
        public static readonly Key CSharpMinor = new Key(Note.CSharp, 4, KeyQuality.Minor);
        public static readonly Key DMinor = new Key(Note.D, -1, KeyQuality.Minor);
        public static readonly Key DSharpMinor = new Key(Note.DFlat, 6, KeyQuality.Minor);
        public static readonly Key EMinor = new Key(Note.E, 1, KeyQuality.Minor);
        public static readonly Key FMinor = new Key(Note.F, -4, KeyQuality.Minor);
        public static readonly Key FSharpMinor = new Key(Note.FSharp, 3, KeyQuality.Minor);
        public static readonly Key GMinor = new Key(Note.G, -2, KeyQuality.Minor);
        public static readonly Key GSharpMinor = new Key(Note.GSharp, 5, KeyQuality.Minor);
        public static readonly Key EFlatMinor = new Key(Note.EFlat, -6, KeyQuality.Minor);

        private readonly int accidentals;

        public KeyQuality Quality { get; }

        protected Key(Note root, int accidentals, KeyQuality quality)
        {
            Quality = quality;
            this.accidentals = accidentals;

            Notes = GenerateScaleNotes();
            OrderScaleNotes(root);

            const string major = "Major";
            const string minor = "Minor";

            Name = root.Name + " " + (quality == KeyQuality.Major ? major : minor);
        }

        public string Name { get; }

        public IEnumerable<Note> Notes { get; private set; }

        public static IEnumerable<Key> Scales
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

        public static Key ScaleForRootAndQuality(Note root, KeyQuality quality)
        {
            return Scales.First(k => k.I == root && k.Quality == quality);
        }

        public bool DoesNoteBelongToKey(Note note)
        {
            return Notes.Any(n => n.Name == note.Name);
        }

        public Key Relative()
        {
            return Quality == KeyQuality.Major
                ? ScaleForRootAndQuality(VI, KeyQuality.Minor).OrderScaleNotes(VI)
                : ScaleForRootAndQuality(III, KeyQuality.Major).OrderScaleNotes(III);
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

        private Key OrderScaleNotes(Note rootNote)
        {
            var enumerable = Notes.OrderBy(n => n.Pitch).ToList();

            Notes =
                enumerable.SkipWhile(n => n.Name != rootNote.Name)
                          .Union(enumerable.TakeWhile(n => n.Name != rootNote.Name));

            return this;
        }
    }
}
