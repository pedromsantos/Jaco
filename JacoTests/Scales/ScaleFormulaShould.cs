using System.Collections.Generic;
using FluentAssertions;
using Jaco.Notes;
using Jaco.Scales;
using Xunit;

namespace JacoTests.Scales
{
    public class ScaleFormulaShould
    {
        public static TheoryData<Scale, IEnumerable<Note>> ScaleNotes
            => new TheoryData<Scale, IEnumerable<Note>>
            {
                { ScaleFormula.Ionian.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.F, Note.G, Note.A, Note.B}},
                { ScaleFormula.Dorian.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.EFlat, Note.F, Note.G, Note.A, Note.BFlat}},
                { ScaleFormula.Phrygian.CreateForRoot(Note.C), new [] { Note.C, Note.DFlat, Note.EFlat, Note.F, Note.G, Note.AFlat, Note.BFlat}},
                { ScaleFormula.Lydian.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.FSharp, Note.G, Note.A, Note.B}},
                { ScaleFormula.Mixolydian.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.F, Note.G, Note.A, Note.BFlat}},
                { ScaleFormula.Aolian.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.EFlat, Note.F, Note.G, Note.AFlat, Note.BFlat}},
                { ScaleFormula.Locrian.CreateForRoot(Note.C), new [] { Note.C, Note.DFlat, Note.EFlat, Note.F, Note.GFlat, Note.AFlat, Note.BFlat}},
                { ScaleFormula.MajorPentatonic.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.G, Note.A}},
                { ScaleFormula.MinorPentatonic.CreateForRoot(Note.C), new [] { Note.C, Note.EFlat, Note.F, Note.G, Note.BFlat}},
                { ScaleFormula.Blues.CreateForRoot(Note.C), new [] { Note.C, Note.EFlat, Note.F, Note.GFlat, Note.G, Note.BFlat}},
                { ScaleFormula.HarmonicMinor.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.EFlat, Note.F, Note.G, Note.AFlat, Note.B}},
                { ScaleFormula.MelodicMinor.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.EFlat, Note.F, Note.G, Note.A, Note.B}},
                { ScaleFormula.Dorianb2.CreateForRoot(Note.C), new [] { Note.C, Note.DFlat, Note.EFlat, Note.F, Note.G, Note.A, Note.BFlat}},
                { ScaleFormula.LydianAugmented.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.FSharp, Note.GSharp, Note.A, Note.B}},
                { ScaleFormula.LydianDominant.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.FSharp, Note.G, Note.A, Note.BFlat}},
                { ScaleFormula.Mixolydianb6.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.F, Note.G, Note.AFlat, Note.BFlat}},
                { ScaleFormula.LocrianSharp2.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.EFlat, Note.F, Note.GFlat, Note.AFlat, Note.BFlat}},
                { ScaleFormula.AlteredDominant.CreateForRoot(Note.C), new [] { Note.C, Note.DFlat, Note.DSharp, Note.E, Note.GFlat, Note.GSharp, Note.BFlat}},
                { ScaleFormula.HalfWholeDiminished.CreateForRoot(Note.C), new [] { Note.C, Note.DFlat, Note.EFlat, Note.E, Note.FSharp, Note.G, Note.A, Note.BFlat}},
                { ScaleFormula.WholeTone.CreateForRoot(Note.C), new [] { Note.C, Note.D, Note.E, Note.GFlat, Note.GSharp, Note.BFlat}},
            };

        [Theory, MemberData(nameof(ScaleNotes))]
        public void GenerateCorrectNotesForScale(Scale scale, IEnumerable<Note> expectedNotes)
        {
            scale.Notes.Should().ContainInOrder(expectedNotes);
        }
    }
}