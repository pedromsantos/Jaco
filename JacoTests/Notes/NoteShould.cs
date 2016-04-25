using FluentAssertions;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Notes
{
    public class NoteShould
    {
        public static TheoryData<Note, string> NoteNames
            => new TheoryData<Note, string>
            {
                {Note.C, "C"},
                {Note.CSharp, "C#"},
                {Note.DFlat, "Db"},
                {Note.D, "D"},
                {Note.DSharp, "D#"},
                {Note.EFlat, "Eb"},
                {Note.E, "E"},
                {Note.F, "F"},
                {Note.FSharp, "F#"},
                {Note.GFlat, "Gb"},
                {Note.G, "G"},
                {Note.GSharp, "G#"},
                {Note.AFlat, "Ab"},
                {Note.A, "A"},
                {Note.ASharp, "A#"},
                {Note.BFlat, "Bb"},
                {Note.B, "B"}
            };

        [Theory, MemberData(nameof(NoteNames))]
        public void RelateNoteWithName(Note note, string expectedName)
        {
            note.Name.Should().Be(expectedName);
        }

        public static TheoryData<Note, Pitch> NotePitches 
            => new TheoryData<Note, Pitch>
            {
                {Note.C, Pitch.C},
                {Note.CSharp, Pitch.CSharp},
                {Note.DFlat, Pitch.DFlat},
                {Note.D, Pitch.D},
                {Note.DSharp, Pitch.DSharp},
                {Note.EFlat, Pitch.EFlat},
                {Note.E, Pitch.E},
                {Note.F, Pitch.F},
                {Note.FSharp, Pitch.FSharp},
                {Note.GFlat, Pitch.GFlat},
                {Note.G, Pitch.G},
                {Note.GSharp, Pitch.GSharp},
                {Note.AFlat, Pitch.AFlat},
                {Note.A, Pitch.A},
                {Note.ASharp, Pitch.ASharp},
                {Note.BFlat, Pitch.BFlat},
                {Note.B, Pitch.B}
            };

        [Theory, MemberData(nameof(NotePitches))]
        public void RelateNoteWithPitch(Note note, Pitch expectedPitch)
        {
            note.Pitch.Should().Be(expectedPitch);
        }

        public static TheoryData<Note, Note> SharpNote 
            => new TheoryData<Note, Note>
            {
                {Note.C, Note.CSharp},
                {Note.CSharp, Note.D},
                {Note.DFlat, Note.D},
                {Note.D, Note.DSharp},
                {Note.DSharp, Note.E},
                {Note.EFlat, Note.E},
                {Note.E, Note.F},
                {Note.F, Note.FSharp},
                {Note.FSharp, Note.G},
                {Note.GFlat, Note.G},
                {Note.G, Note.GSharp},
                {Note.GSharp, Note.A},
                {Note.AFlat, Note.A},
                {Note.A, Note.ASharp},
                {Note.ASharp, Note.B},
                {Note.BFlat, Note.B},
                {Note.B, Note.C}
            };

        [Theory, MemberData(nameof(SharpNote))]
        public void SharpNoteToCorrectNote(Note note,  Note expectedShapedNote)
        {
            note.Sharp().Should().Be(expectedShapedNote);
        }

        public static TheoryData<Note, Note> FlatNote 
            => new TheoryData<Note, Note>
            {
                {Note.C, Note.B},
                {Note.CSharp, Note.C},
                {Note.DFlat, Note.C},
                {Note.D, Note.DFlat},
                {Note.DSharp, Note.D},
                {Note.EFlat, Note.D},
                {Note.E, Note.EFlat},
                {Note.F, Note.E},
                {Note.FSharp, Note.F},
                {Note.GFlat, Note.F},
                {Note.G, Note.GFlat},
                {Note.GSharp, Note.G},
                {Note.AFlat, Note.G},
                {Note.A, Note.AFlat},
                {Note.ASharp, Note.A},
                {Note.BFlat, Note.A},
                {Note.B, Note.BFlat}
            };

        [Theory, MemberData(nameof(FlatNote))]
        public void FlatNoteToCorrectNote(Note note, Note expectedFlatedNote)
        {
            note.Flat().Should().Be(expectedFlatedNote);
        }

        public static TheoryData<Note, Note, Interval> NotesInterval 
            => new TheoryData<Note, Note, Interval>
            {
                {Note.C, Note.DFlat, Interval.MinorSecond },
                {Note.C, Note.D, Interval.MajorSecond },
                {Note.C, Note.EFlat, Interval.MinorThird },
                {Note.C, Note.E, Interval.MajorThird },
                {Note.C, Note.F, Interval.PerfectForth },
                {Note.C, Note.GFlat, Interval.DiminishedFifth },
                {Note.C, Note.G, Interval.PerfectFifth },
                {Note.C, Note.GSharp, Interval.AugmentedFifth },
                {Note.C, Note.A, Interval.MajorSixth },
                {Note.C, Note.BFlat, Interval.MinorSeventh },
                {Note.C, Note.B, Interval.MajorSeventh },
                {Note.C, Note.C, Interval.Unisson },
            };

        [Theory, MemberData(nameof(NotesInterval))]
        public void CalculateIntervalsBetweenNotes(Note noteA, Note noteB, Interval expectedInterval)
        {
            noteA.IntervalWithOther(noteB).Should().Be(expectedInterval);
        }

        [Theory, MemberData(nameof(NotesInterval))]
        public void TransposeNotes(Note noteToTranspose, Note transposedNote, Interval interval)
        {
            noteToTranspose.Transpose(interval).Should().Be(transposedNote);
        }

        public static TheoryData<Note, Note> EqualNotes
            => new TheoryData<Note, Note>
            {
                {Note.C, Note.C},
                {Note.CSharp, Note.CSharp},
                {Note.DFlat, Note.DFlat},
                {Note.D, Note.D},
                {Note.DSharp, Note.DSharp},
                {Note.EFlat, Note.EFlat},
                {Note.E, Note.E},
                {Note.F, Note.F},
                {Note.FSharp, Note.FSharp},
                {Note.GFlat, Note.GFlat},
                {Note.G, Note.G},
                {Note.GSharp, Note.GSharp},
                {Note.AFlat, Note.AFlat},
                {Note.A, Note.A},
                {Note.ASharp, Note.ASharp},
                {Note.BFlat, Note.BFlat},
                {Note.B, Note.B}
            };

        [Theory, MemberData(nameof(EqualNotes))]
        public void BeEqualWhenSameNote(Note note, Note otherNote)
        {
            note.Should().BeSameAs(otherNote);
        }
    }
}