using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Chords
{
    public class ChordShould
    {
        private readonly Chord chord;

        public ChordShould()
        {
            chord = new Chord(Note.C, ChordFunction.Major7);
        }

        public static TheoryData<Function, Note> FunctionsToNotes
           => new TheoryData<Function, Note>
           {
               { Function.Root, Note.C },
               { Function.Third, Note.E },
               { Function.Fifth, Note.G },
               { Function.Seventh, Note.B },
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
            chord.Lead.Should().Be(Note.B);
        }

        [Fact]
        public void BeNamedAfterTheRootNote()
        {
            var cmaj = new Chord(Note.C, ChordFunction.Major);
            cmaj.Name.Should().StartWith("C");
        }

        public static TheoryData<ChordFunction, IEnumerable<Note>> ChordFunctions
            => new TheoryData<ChordFunction, IEnumerable<Note>>
            {
                { ChordFunction.Major,  new [] { Note.C, Note.E, Note.G}},
                { ChordFunction.Augmented,  new [] { Note.C, Note.E, Note.GSharp}},
                { ChordFunction.Minor,  new [] { Note.C, Note.EFlat, Note.G}},
                { ChordFunction.Diminished,  new [] { Note.C, Note.EFlat, Note.GFlat}},
                { ChordFunction.Major7,  new [] { Note.C, Note.E, Note.G, Note.B}},
                { ChordFunction.Diminished7,  new [] { Note.C, Note.EFlat, Note.GFlat, Note.A}},
                { ChordFunction.Minor7,  new [] { Note.C, Note.EFlat, Note.G, Note.BFlat}},
                { ChordFunction.Minor7b5,  new [] { Note.C, Note.EFlat, Note.GFlat, Note.BFlat}},
                { ChordFunction.Diminished7,  new [] { Note.C, Note.EFlat, Note.GFlat, Note.A}},
            };

        [Theory, MemberData(nameof(ChordFunctions))]
        public void CreateChordFromRootAndFunctions(ChordFunction function, IEnumerable<Note> expectedNotes)
        {
            new Chord(Note.C, function).Notes
                .Should().ContainInOrder(expectedNotes);
        }

        public static TheoryData<Chord, string> ChordNames
           => new TheoryData<Chord, string>
           {
               { new Chord(Note.C, ChordFunction.Major), "Maj" },
               { new Chord(Note.C, ChordFunction.Augmented), "Aug" },
               { new Chord(Note.C, ChordFunction.Minor), "Min" },
               { new Chord(Note.C, ChordFunction.Diminished), "Dim" },
               { new Chord(Note.C, ChordFunction.Major7), "Maj7" },
               { new Chord(Note.C, ChordFunction.Dominant7), "Dom7" },
               { new Chord(Note.C, ChordFunction.Minor7), "Min7" },
               { new Chord(Note.C, ChordFunction.Minor7b5), "Min7b5" },
               { new Chord(Note.C, ChordFunction.Diminished7), "Dim7" },
           };

        [Theory, MemberData(nameof(ChordNames))]
        public void BeNamedAfterTheFunction(Chord theChord, string expectedName)
        {
            theChord.Name.Should().Contain(expectedName);
        }

        public static TheoryData<Chord, IEnumerable<Note>> ChordInvertions 
           => new TheoryData<Chord, IEnumerable<Note>>
           {
               { new Chord(Note.C,ChordFunction.Major), new [] {Note.E, Note.G, Note.C} },
               { new Chord(Note.C, ChordFunction.Major).Invert(), new [] {Note.G, Note.C, Note.E} },
               { new Chord(Note.C, ChordFunction.Major).Invert().Invert(), new [] {Note.C, Note.E, Note.G} },
               { new Chord(Note.C, ChordFunction.Major7), new [] {Note.E, Note.G, Note.B, Note.C} },
               { new Chord(Note.C, ChordFunction.Major7).Invert(), new [] {Note.G, Note.B, Note.C, Note.E} },
               { new Chord(Note.C, ChordFunction.Major7).Invert().Invert(), new [] {Note.B, Note.C, Note.E, Note.G} },
               { new Chord(Note.C, ChordFunction.Major7).Invert().Invert().Invert(), new [] {Note.C, Note.E, Note.G, Note.B} },
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
            new Chord(Note.C, ChordFunction.Major7)
                .ToDrop2()
                .Notes
                .Should().ContainInOrder(Note.C, Note.G, Note.B, Note.E);
        }

        [Fact]
        public void BeAbleToCreateDrop3Chord()
        {
            new Chord(Note.C, ChordFunction.Major7)
                .ToDrop3()
                .Notes
                .Should().ContainInOrder(Note.C, Note.B, Note.E, Note.G);
        }

        [Fact]
        public void BeAbleToCreateClosedChord()
        {
            new Chord(Note.C, ChordFunction.Major7)
                .ToDrop2()
                .ToClosed()
                .Notes
                .Should().ContainInOrder(Note.C, Note.E, Note.G, Note.B);
        }

        public static TheoryData<Chord, IEnumerable<Note>> Drop2Invertions
           => new TheoryData<Chord, IEnumerable<Note>>
           {
               { new Chord(Note.C, ChordFunction.Major7).ToDrop2(), new [] { Note.E, Note.B, Note.C, Note.G } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop2().Invert(), new [] { Note.G, Note.C, Note.E, Note.B } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop2().Invert().Invert(), new [] { Note.B, Note.E, Note.G, Note.C } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop2().Invert().Invert().Invert(), new [] { Note.C, Note.G, Note.B, Note.E } },
           };

        [Theory, MemberData(nameof(Drop2Invertions))]
        public void InvertDrop2Chord(Chord theChord, IEnumerable<Note> expectedChordNotes)
        {
            theChord
                .Invert()
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }

        public static TheoryData<Chord, IEnumerable<Note>> Drop3Invertions
           => new TheoryData<Chord, IEnumerable<Note>>
           {
               { new Chord(Note.C, ChordFunction.Major7).ToDrop3(), new [] { Note.E, Note.C, Note.G, Note.B } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop3().Invert(), new [] { Note.G, Note.E, Note.B, Note.C } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop3().Invert().Invert(), new [] { Note.B, Note.G, Note.C, Note.E } },
               { new Chord(Note.C, ChordFunction.Major7).ToDrop3().Invert().Invert().Invert(), new [] { Note.C, Note.B, Note.E, Note.G } },
           };

        [Theory, MemberData(nameof(Drop3Invertions))]
        public void InvertDrop3Chord(Chord theChord, IEnumerable<Note> expectedChordNotes)
        {
           theChord 
                .Invert()
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }

        public static TheoryData<Chord, IEnumerable<Note>> Transpose
           => new TheoryData<Chord, IEnumerable<Note>>
           {
                { new Chord(Note.C, ChordFunction.Major), new [] { Note.F, Note.A, Note.C } },
                { new Chord(Note.C, ChordFunction.Major), new [] { Note.D, Note.GFlat, Note.A } },
                { new Chord(Note.C, ChordFunction.Major), new [] { Note.E, Note.AFlat, Note.B } },
           };

        [Theory, MemberData(nameof(Transpose))]
        public void TransposeChord(Chord theChord, IList<Note> expectedChordNotes)
        {
            theChord
                .Transpose(expectedChordNotes.First())
                .Notes
                .Should().ContainInOrder(expectedChordNotes);
        }

        public static TheoryData<Function, Note> InvertionsForFunctionInPosition
           => new TheoryData<Function, Note>
           {
               { Function.Root,  Note.C },
               { Function.Third, Note.E },
               { Function.Fifth, Note.G },
               { Function.Seventh, Note.B },
           };

        [Theory, MemberData(nameof(InvertionsForFunctionInPosition))]
        public void ChooseInvertionThatSatisfiesHavingASpecificNoteAsLead(Function functionAsLead, Note expectedLead)
        {
            chord
                .InversionForFunctionAsLead(functionAsLead)
                .Lead
                .Should().Be(expectedLead);
        }

        [Theory, MemberData(nameof(InvertionsForFunctionInPosition))]
        public void ChooseInvertionThatSatisfiesHavingASpecificNoteAsBass(Function functionAsBass, Note expectedBass)
        {
            chord
                .InversionForFunctionAsBass(functionAsBass)
                .Bass
                .Should().Be(expectedBass);
        }

        public static TheoryData<Note, Note> NotesClosestToPosition 
           => new TheoryData<Note, Note>
           {
               { Note.CSharp,  Note.C },
               { Note.FSharp, Note.G },
               { Note.ASharp, Note.B },
               { Note.F, Note.E },
           };

        [Theory, MemberData(nameof(NotesClosestToPosition))]
        public void FindInvertionWithLeadClosestToNote(Note closeToLead, Note expectedLead)
        {
            new Chord(Note.C, ChordFunction.Major7)
                 .FindInversionWithLeadClosestToNote(closeToLead)
                 .Lead
                 .Should().Be(expectedLead);
        }
    }
}