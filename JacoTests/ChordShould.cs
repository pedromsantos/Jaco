using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jaco;
using Xunit;

namespace JacoTests
{
    public class ChordShould
    {
        private readonly Chord chord;

        public ChordShould()
        {
            chord = new Chord(Note.C, Note.E, Note.G, Note.B, Note.D, Note.F, Note.A);
        }

        public static TheoryData<Function, Note> FunctionsToNotes
           => new TheoryData<Function, Note>
           {
               { Function.Root, Note.C },
               { Function.Third, Note.E },
               { Function.Fifth, Note.G },
               { Function.Seventh, Note.B },
               { Function.Ninth, Note.D },
               { Function.Eleventh, Note.F },
               { Function.Thirteenth, Note.A },
           };

        [Theory, MemberData(nameof(FunctionsToNotes))]
        public void RelateNoteToFunction(Function function, Note expectedNote)
        {
            chord.NoteForFunction(function).Should().Be(expectedNote);
        }

        [Fact]
        public void ReturnLowestNoteForBass()
        {
            chord.Bass.Should().Be(Note.C);
        }

        [Fact]
        public void ReturnHighestNoteForLead()
        {
            chord.Lead.Should().Be(Note.A);
        }

        [Fact]
        public void BeNamedAfterTheRootNote()
        {
            var cmaj = new Chord(Note.C, Note.E, Note.G);
            cmaj.Name.Should().StartWith("C");
        }

        public static TheoryData<Chord, string> ChordNames
           => new TheoryData<Chord, string>
           {
               { new Chord(Note.C, Note.E, Note.G), "Maj" },
               { new Chord(Note.C, Note.E, Note.GSharp), "Aug" },
               { new Chord(Note.C, Note.EFlat, Note.G), "Min" },
               { new Chord(Note.C, Note.EFlat, Note.GFlat), "Dim" },
               { new Chord(Note.C, Note.E, Note.G, Note.B), "Maj7" },
               { new Chord(Note.C, Note.E, Note.G, Note.BFlat), "Dom7" },
               { new Chord(Note.C, Note.EFlat, Note.G, Note.BFlat), "Min7" },
               { new Chord(Note.C, Note.EFlat, Note.GFlat, Note.BFlat), "Min7b5" },
               { new Chord(Note.C, Note.EFlat, Note.GFlat, Note.A), "Dim7" },
           };

        [Theory, MemberData(nameof(ChordNames))]
        public void BeNamedAfterTheFunction(Chord theChord, string expectedName)
        {
            theChord.Name.Should().Contain(expectedName);
        }

        public static TheoryData<Chord, IEnumerable<Note>> ChordInvertions 
           => new TheoryData<Chord, IEnumerable<Note>>
           {
               { new Chord(Note.C, Note.E, Note.G), new [] {Note.E, Note.G, Note.C} },
               { new Chord(Note.E, Note.G, Note.C), new [] {Note.G, Note.C, Note.E} },
               { new Chord(Note.G, Note.C, Note.E), new [] {Note.C, Note.E, Note.G} },
               { new Chord(Note.C, Note.E, Note.G, Note.B), new [] {Note.E, Note.G, Note.B, Note.C} },
               { new Chord(Note.E, Note.G, Note.B, Note.C), new [] {Note.G, Note.B, Note.C, Note.E} },
               { new Chord(Note.G, Note.B, Note.C, Note.E), new [] {Note.B, Note.C, Note.E, Note.G} },
               { new Chord(Note.B, Note.C, Note.E, Note.G), new [] {Note.C, Note.E, Note.G, Note.B} },
           };

        [Theory, MemberData(nameof(ChordInvertions))]
        public void Invert(Chord theChord, IEnumerable<Note> invertedChordNotes)
        {
            theChord
                .Invert()
                .Notes
                .Should().ContainInOrder(invertedChordNotes);
        }

        [Theory, MemberData(nameof(FunctionsToNotes))]
        public void MaintainRelationFunctionNoteAfterFirstInversion(Function function, Note expectedNote)
        {
            chord
                .Invert()
                .NoteForFunction(function)
                .Should().Be(expectedNote);
        }

        [Theory, MemberData(nameof(FunctionsToNotes))]
        public void MaintainRelationFunctionNoteAfterSecondInversion(Function function, Note expectedNote)
        {
            chord.
                Invert()
                .Invert()
                .NoteForFunction(function)
                .Should().Be(expectedNote);
        }

        [Theory, MemberData(nameof(FunctionsToNotes))]
        public void MaintainRelationFunctionNoteAfterThirdInversion(Function function, Note expectedNote)
        {
            chord
                .Invert()
                .Invert()
                .Invert()
                .NoteForFunction(function)
                .Should().Be(expectedNote);
        }

        [Fact]
        public void BeAbleToCreateDrop2Chord()
        {
            new Chord(Note.C, Note.E, Note.G, Note.B)
                .ToDrop2()
                .Notes
                .Should().ContainInOrder(Note.C, Note.G, Note.B, Note.E);
        }

        [Fact]
        public void BeAbleToCreateDrop3Chord()
        {
            new Chord(Note.C, Note.E, Note.G, Note.B)
                .ToDrop3()
                .Notes
                .Should().ContainInOrder(Note.C, Note.B, Note.E, Note.G);
        }

        [Fact]
        public void BeAbleToCreateClosedChord()
        {
            new Chord(Note.C, Note.E, Note.G, Note.B)
                .ToDrop2()
                .ToClosed()
                .Notes
                .Should().ContainInOrder(Note.C, Note.E, Note.G, Note.B);
        }

        public static TheoryData<IEnumerable<Note>, IEnumerable<Note>> Drop2Invertions
           => new TheoryData<IEnumerable<Note>, IEnumerable<Note>>
           {
               { new[] { Note.C, Note.G, Note.B, Note.E }, new [] { Note.E, Note.B, Note.C, Note.G } },
               { new[] { Note.E, Note.B, Note.C, Note.G }, new [] { Note.G, Note.C, Note.E, Note.B } },
               { new[] { Note.G, Note.C, Note.E, Note.B }, new [] { Note.B, Note.E, Note.G, Note.C } },
               { new[] { Note.B, Note.E, Note.G, Note.C }, new [] { Note.C, Note.G, Note.B, Note.E } },
           };

        [Theory, MemberData(nameof(Drop2Invertions))]
        public void InvertDrop2Chord(IEnumerable<Note> chordNotes, IEnumerable<Note> expectedChordNotes)
        {
            new Drop2(chordNotes.ToArray())
                .Invert()
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }

        public static TheoryData<IEnumerable<Note>, IEnumerable<Note>> Drop3Invertions
           => new TheoryData<IEnumerable<Note>, IEnumerable<Note>>
           {
               { new[] { Note.C, Note.B, Note.E, Note.G }, new [] { Note.E, Note.C, Note.G, Note.B } },
               { new[] { Note.E, Note.C, Note.G, Note.B }, new [] { Note.G, Note.E, Note.B, Note.C } },
               { new[] { Note.G, Note.E, Note.B, Note.C }, new [] { Note.B, Note.G, Note.C, Note.E } },
               { new[] { Note.B, Note.G, Note.C, Note.E }, new [] { Note.C, Note.B, Note.E, Note.G } },
           };

        [Theory, MemberData(nameof(Drop3Invertions))]
        public void InvertDrop3Chord(IEnumerable<Note> chordNotes, IEnumerable<Note> expectedChordNotes)
        {
            new Drop3(chordNotes.ToArray())
                .Invert()
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }

        public static TheoryData<IEnumerable<Note>, IEnumerable<Note>> Transpose
           => new TheoryData<IEnumerable<Note>, IEnumerable<Note>>
           {
                { new[] { Note.C, Note.E, Note.G }, new [] { Note.F, Note.A, Note.C } },
                { new[] { Note.C, Note.E, Note.G }, new [] { Note.D, Note.GFlat, Note.A } },
           };

        [Theory, MemberData(nameof(Transpose))]
        public void TransposeChord(IEnumerable<Note> chordNotes, IEnumerable<Note> expectedChordNotes)
        {
            new Chord(chordNotes.ToArray())
                .Transpose(expectedChordNotes.First())
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }
    }
}