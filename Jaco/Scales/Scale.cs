using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Scales
{
    public class Scale
    {
        public static readonly Scale AMajor = ScaleFormula.Ionian.CreateForRoot(Note.A);
        public static readonly Scale AFlatMajor = ScaleFormula.Ionian.CreateForRoot(Note.AFlat);
        public static readonly Scale BMajor = ScaleFormula.Ionian.CreateForRoot(Note.B);
        public static readonly Scale BFlatMajor = ScaleFormula.Ionian.CreateForRoot(Note.BFlat);
        public static readonly Scale CMajor = ScaleFormula.Ionian.CreateForRoot(Note.C);
        public static readonly Scale CSharpMajor = ScaleFormula.Ionian.CreateForRoot(Note.CSharp);
        public static readonly Scale DMajor = ScaleFormula.Ionian.CreateForRoot(Note.D);
        public static readonly Scale DFlatMajor = ScaleFormula.Ionian.CreateForRoot(Note.DFlat);
        public static readonly Scale EMajor = ScaleFormula.Ionian.CreateForRoot(Note.E);
        public static readonly Scale EFlatMajor = ScaleFormula.Ionian.CreateForRoot(Note.EFlat);
        public static readonly Scale FMajor = ScaleFormula.Ionian.CreateForRoot(Note.F);
        public static readonly Scale FSharpMajor = ScaleFormula.Ionian.CreateForRoot(Note.FSharp);
        public static readonly Scale GMajor = ScaleFormula.Ionian.CreateForRoot(Note.G);
        public static readonly Scale GFlatMajor = ScaleFormula.Ionian.CreateForRoot(Note.GFlat);

        public static readonly Scale AMinor = ScaleFormula.Aolian.CreateForRoot(Note.A);
        public static readonly Scale AFlatMinor = ScaleFormula.Aolian.CreateForRoot(Note.AFlat);
        public static readonly Scale ASharpMinor = ScaleFormula.Aolian.CreateForRoot(Note.ASharp);
        public static readonly Scale BMinor = ScaleFormula.Aolian.CreateForRoot(Note.B);
        public static readonly Scale BFlatMinor = ScaleFormula.Aolian.CreateForRoot(Note.BFlat);
        public static readonly Scale CMinor = ScaleFormula.Aolian.CreateForRoot(Note.C);
        public static readonly Scale CSharpMinor = ScaleFormula.Aolian.CreateForRoot(Note.CSharp);
        public static readonly Scale DMinor = ScaleFormula.Aolian.CreateForRoot(Note.D);
        public static readonly Scale DSharpMinor = ScaleFormula.Aolian.CreateForRoot(Note.DSharp);
        public static readonly Scale EMinor = ScaleFormula.Aolian.CreateForRoot(Note.E);
        public static readonly Scale FMinor = ScaleFormula.Aolian.CreateForRoot(Note.F);
        public static readonly Scale FSharpMinor = ScaleFormula.Aolian.CreateForRoot(Note.FSharp);
        public static readonly Scale GMinor = ScaleFormula.Aolian.CreateForRoot(Note.G);
        public static readonly Scale GSharpMinor = ScaleFormula.Aolian.CreateForRoot(Note.GSharp);
        public static readonly Scale EFlatMinor = ScaleFormula.Aolian.CreateForRoot(Note.EFlat);

        public static readonly Scale AMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.A);
        public static readonly Scale AFlatMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.AFlat);
        public static readonly Scale ASharpMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.ASharp);
        public static readonly Scale BMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.B);
        public static readonly Scale BFlatMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.BFlat);
        public static readonly Scale CMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.C);
        public static readonly Scale CSharpMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.CSharp);
        public static readonly Scale DMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.D);
        public static readonly Scale DSharpMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.DSharp);
        public static readonly Scale EMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.E);
        public static readonly Scale FMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.F);
        public static readonly Scale FSharpMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.FSharp);
        public static readonly Scale GMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.G);
        public static readonly Scale GSharpMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.GSharp);
        public static readonly Scale EFlatMinorHarmonic = ScaleFormula.HarmonicMinor.CreateForRoot(Note.EFlat);

        private readonly IEnumerable<Note> notes;

        public Scale(IEnumerable<Note> notes)
        {
            this.notes = notes;
        }

        public IEnumerable<Note> Notes => notes;

        public Note I => notes.ElementAt(0);

        public Note II => notes.ElementAt(1);

        public Note III => notes.ElementAt(2);

        public Note IV => notes.ElementAt(3);

        public Note V => notes.ElementAt(4);

        public Note VI => notes.ElementAt(5);

        public Note VII => notes.ElementAt(6);
    }
}