using System.Collections.Generic;
using FluentAssertions;
using Jaco.Notes;
using Jaco.Scales;
using Xunit;

namespace JacoTests.Scales
{
    public class ScaleShould
    {
        public static TheoryData<Scale, IEnumerable<Note>> ScaleNotes 
            => new TheoryData<Scale, IEnumerable<Note>>
            {
                { Scale.CMajor,  new [] { Note.C, Note.D, Note.E, Note.F, Note.G, Note.A, Note.B}},
                { Scale.AMinor,  new [] { Note.A, Note.B, Note.C, Note.D, Note.E, Note.F, Note.G}},
                { Scale.AFlatMajor,  new [] { Note.AFlat, Note.BFlat, Note.C, Note.DFlat, Note.EFlat, Note.F, Note.G}},
                { Scale.GFlatMajor,  new [] { Note.GFlat, Note.AFlat, Note.BFlat, Note.B, Note.DFlat, Note.EFlat, Note.F}},
                { Scale.EFlatMinor,  new [] { Note.EFlat, Note.F, Note.GFlat, Note.AFlat, Note.BFlat, Note.B, Note.DFlat}},
                { Scale.CSharpMajor, new [] { Note.CSharp, Note.DSharp, Note.F, Note.FSharp, Note.GSharp, Note.ASharp, Note.C}},
                { Scale.ASharpMinor, new [] { Note.ASharp, Note.C, Note.CSharp, Note.DSharp, Note.F, Note.FSharp, Note.GSharp}},
            };

        [Theory, MemberData(nameof(ScaleNotes))]
        public void GenerateCorrectNotesForScale(Scale scale, IEnumerable<Note> expectedNotes)
        {
            scale.Notes.Should().ContainInOrder(expectedNotes);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeI()
        {
            Scale.CMajor.I.Should().Be(Note.C);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeII()
        {
            Scale.CMajor.II.Should().Be(Note.D);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeIII()
        {
            Scale.CMajor.III.Should().Be(Note.E);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeIV()
        {
            Scale.CMajor.IV.Should().Be(Note.F);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeV()
        {
            Scale.CMajor.V.Should().Be(Note.G);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeVI()
        {
            Scale.CMajor.VI.Should().Be(Note.A);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeVII()
        {
            Scale.CMajor.VII.Should().Be(Note.B);
        }

        [Fact]
        public void ReturnScaleForRootAndQuality()
        {
            Scale.ScaleForRootAndQuality(Note.A, ScaleQuality.Minor).Should().Be(Scale.AMinor);
        }

        [Fact]
        public void VarifyIfNoteBelongsToScale()
        {
            Scale.CMajor.DoesNoteBelongToScale(Note.ASharp).Should().Be(false);
        }


        public static TheoryData<Scale, IEnumerable<Note>> RelativeScales
            => new TheoryData<Scale, IEnumerable<Note>>
            {
                { Scale.CMajor,  Scale.AMinor.Notes},
                { Scale.AMinor,  Scale.CMajor.Notes},
            };

        [Theory, MemberData(nameof(RelativeScales))]
        public void FindRelativeScale(Scale scale, IEnumerable<Note> expectedScaleNotes)
        {
            scale.Relative().Notes.Should().ContainInOrder(expectedScaleNotes);
        }
    }
}
