using System.Collections.Generic;
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

        [Fact]
        public void CreateChordFromNotes()
        {
            chord.Notes.Should().ContainInOrder(Note.C, Note.E, Note.G);
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
            theChord.Invert().Notes.Should().ContainInOrder(invertedChordNotes);
        }
    }
}