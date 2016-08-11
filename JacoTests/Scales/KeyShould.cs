using System.Collections.Generic;
using FluentAssertions;
using Jaco.Notes;
using Jaco.Scales;
using Xunit;

namespace JacoTests.Scales
{
    public class KeyShould
    {
        public static TheoryData<Key, IEnumerable<Note>> ScaleNotes 
            => new TheoryData<Key, IEnumerable<Note>>
            {
                { Key.CMajor,  new [] { Note.C, Note.D, Note.E, Note.F, Note.G, Note.A, Note.B}},
                { Key.AMinor,  new [] { Note.A, Note.B, Note.C, Note.D, Note.E, Note.F, Note.G}},
                { Key.AFlatMajor,  new [] { Note.AFlat, Note.BFlat, Note.C, Note.DFlat, Note.EFlat, Note.F, Note.G}},
                { Key.GFlatMajor,  new [] { Note.GFlat, Note.AFlat, Note.BFlat, Note.B, Note.DFlat, Note.EFlat, Note.F}},
                { Key.EFlatMinor,  new [] { Note.EFlat, Note.F, Note.GFlat, Note.AFlat, Note.BFlat, Note.B, Note.DFlat}},
                { Key.CSharpMajor, new [] { Note.CSharp, Note.DSharp, Note.F, Note.FSharp, Note.GSharp, Note.ASharp, Note.C}},
                { Key.ASharpMinor, new [] { Note.ASharp, Note.C, Note.CSharp, Note.DSharp, Note.F, Note.FSharp, Note.GSharp}},
            };

        [Theory, MemberData(nameof(ScaleNotes))]
        public void GenerateCorrectNotesForKey(Key key, IEnumerable<Note> expectedNotes)
        {
            key.Notes.Should().ContainInOrder(expectedNotes);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeI()
        {
            Key.CMajor.I.Should().Be(Note.C);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeII()
        {
            Key.CMajor.II.Should().Be(Note.D);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeIII()
        {
            Key.CMajor.III.Should().Be(Note.E);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeIV()
        {
            Key.CMajor.IV.Should().Be(Note.F);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeV()
        {
            Key.CMajor.V.Should().Be(Note.G);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeVI()
        {
            Key.CMajor.VI.Should().Be(Note.A);
        }

        [Fact]
        public void HaveCorrectNoteForDegreeVII()
        {
            Key.CMajor.VII.Should().Be(Note.B);
        }

        [Fact]
        public void ReturnScaleForRootAndQuality()
        {
            Key.ScaleForRootAndQuality(Note.A, KeyQuality.Minor).Should().Be(Key.AMinor);
        }

        [Fact]
        public void VarifyIfNoteBelongsToScale()
        {
            Key.CMajor.DoesNoteBelongToKey(Note.ASharp).Should().Be(false);
        }


        public static TheoryData<Key, IEnumerable<Note>> RelativeKeys
            => new TheoryData<Key, IEnumerable<Note>>
            {
                { Key.CMajor,  Key.AMinor.Notes},
                { Key.AMinor,  Key.CMajor.Notes},
            };

        [Theory, MemberData(nameof(RelativeKeys))]
        public void FindRelativeScale(Key key, IEnumerable<Note> expectedScaleNotes)
        {
            key.Relative().Notes.Should().ContainInOrder(expectedScaleNotes);
        }
    }
}
