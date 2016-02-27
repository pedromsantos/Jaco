using FluentAssertions;
using Jaco.Guitar;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Guitar
{
    public class GuitarStringShould
    {
        public static TheoryData<Note, int> NotesFretsSixthString
            => new TheoryData<Note, int>
            {
                { Note.E, 0 },
                { Note.F, 1 },
                { Note.FSharp, 2 },
                { Note.G, 3 },
                { Note.GSharp, 4 },
                { Note.A, 5 },
                { Note.ASharp, 6 },
                { Note.B, 7 },
                { Note.C, 8 },
                { Note.CSharp, 9 },
                { Note.D, 10 },
                { Note.DSharp, 11 },
            };

        [Theory, MemberData(nameof(NotesFretsSixthString))]
        public void MapNoteToFretOnSixthString(Note note, int expectedFret)
        {
            GuitarString.Sixth.FretForNote(note)
                .Should().Be(expectedFret);
        }

        public static TheoryData<Note, int> NotesFretsFifthString
            => new TheoryData<Note, int>
            {
                { Note.A, 0 },
                { Note.ASharp, 1 },
                { Note.B, 2 },
                { Note.C, 3 },
                { Note.CSharp, 4 },
                { Note.D, 5 },
                { Note.DSharp, 6 },
                { Note.E, 7 },
                { Note.F, 8 },
                { Note.FSharp, 9 },
                { Note.G, 10 },
                { Note.GSharp, 11 },
            };

        [Theory, MemberData(nameof(NotesFretsFifthString))]
        public void MapNoteToFretOnFifthString(Note note, int expectedFret)
        {
            GuitarString.Fifth.FretForNote(note)
                .Should().Be(expectedFret);
        }

        public static TheoryData<Note, int> NotesFretsFourthString
            => new TheoryData<Note, int>
            {
                { Note.D, 0 },
                { Note.DSharp, 1 },
                { Note.E, 2 },
                { Note.F, 3 },
                { Note.FSharp, 4 },
                { Note.G, 5 },
                { Note.GSharp, 6 },
                { Note.A, 7 },
                { Note.ASharp, 8 },
                { Note.B, 9 },
                { Note.C, 10 },
                { Note.CSharp, 11 },
            };

        [Theory, MemberData(nameof(NotesFretsFourthString))]
        public void MapNoteToFretOnFourthString(Note note, int expectedFret)
        {
            GuitarString.Fourth.FretForNote(note)
                .Should().Be(expectedFret);
        }

        public static TheoryData<Note, int> NotesFretsThirdFString
            => new TheoryData<Note, int>
            {
                { Note.G, 0 },
                { Note.GSharp, 1 },
                { Note.A, 2 },
                { Note.ASharp, 3 },
                { Note.B, 4 },
                { Note.C, 5 },
                { Note.CSharp, 6 },
                { Note.D, 7 },
                { Note.DSharp, 8 },
                { Note.E, 9 },
                { Note.F, 10 },
                { Note.FSharp, 11 },
            };

        [Theory, MemberData(nameof(NotesFretsThirdFString))]
        public void MapNoteToFretOnThirdString(Note note, int expectedFret)
        {
            GuitarString.Third.FretForNote(note)
                .Should().Be(expectedFret);
        }

        public static TheoryData<Note, int> NotesFretsSecondString
             => new TheoryData<Note, int>
             {
                { Note.B, 0 },
                { Note.C, 1 },
                { Note.CSharp, 2 },
                { Note.D, 3 },
                { Note.DSharp, 4 },
                { Note.E, 5 },
                { Note.F, 6 },
                { Note.FSharp, 7 },
                { Note.G, 8 },
                { Note.GSharp, 9 },
                { Note.A, 10 },
                { Note.ASharp, 11 },
             };

        [Theory, MemberData(nameof(NotesFretsSecondString))]
        public void MapNoteToFretOnSecondString(Note note, int expectedFret)
        {
            GuitarString.Second.FretForNote(note)
                .Should().Be(expectedFret);
        }

        [Theory, MemberData(nameof(NotesFretsSixthString))]
        public void MapNoteToFretOnFirstString(Note note, int expectedFret)
        {
            GuitarString.First.FretForNote(note)
                .Should().Be(expectedFret);
        }
    }
}
