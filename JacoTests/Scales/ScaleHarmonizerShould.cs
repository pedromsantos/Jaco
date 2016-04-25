using System;
using System.Collections.Generic;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Notes;
using Jaco.Scales;
using Xunit;

namespace JacoTests.Scales
{
    public class ScaleHarmonizerShould
    {
        public static TheoryData<Func<Chord>, Chord> HarmonizationMajorScaleTriads
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new TriadsHarmonizer(Scale.CMajor).I(),  new Chord(Note.C, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.CMajor).II(),  new Chord(Note.D, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.CMajor).III(),  new Chord(Note.E, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.CMajor).IV(),  new Chord(Note.F, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.CMajor).V(),  new Chord(Note.G, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.CMajor).VI(),  new Chord(Note.A, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.CMajor).VII(),  new Chord(Note.B, ChordFunction.Diminished)}
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleTriads))]
        public void HarmonizeTriadsMajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationMinorScaleTriads
           => new TheoryData<Func<Chord>, Chord>
           {
                { () => new TriadsHarmonizer(Scale.AMinor).I(),  new Chord(Note.A, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.AMinor).II(),  new Chord(Note.B, ChordFunction.Diminished)},
                { () => new TriadsHarmonizer(Scale.AMinor).III(),  new Chord(Note.C, ChordFunction.Augmented)},
                { () => new TriadsHarmonizer(Scale.AMinor).IV(),  new Chord(Note.D, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.AMinor).V(),  new Chord(
                    new NoteWithFunction(Note.E, Function.Root), 
                    new NoteWithFunction(Note.GSharp, Function.Third), 
                    new NoteWithFunction(Note.B, Function.Fifth))},
                { () => new TriadsHarmonizer(Scale.AMinor).VI(),  new Chord(Note.F, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.AMinor).VII(),  new Chord(Note.GSharp, ChordFunction.Diminished)}
           };

        [Theory, MemberData(nameof(HarmonizationMinorScaleTriads))]
        public void HarmonizeTriadsMinorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationMajorScaleSevents
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new SeventhsHarmonizer(Scale.CMajor).I(),  new Chord(Note.C, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).II(),  new Chord(Note.D, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).III(),  new Chord(Note.E, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).IV(),  new Chord(Note.F, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).V(),  new Chord(Note.G, ChordFunction.Dominant7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).VI(),  new Chord(Note.A, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).VII(),  new Chord(Note.B, ChordFunction.Minor7b5)}
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleSevents))]
        public void HarmonizeSeventsMajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedChord.Notes);
        } 

        public static TheoryData<Func<Chord>, IEnumerable<Note>> HarmonizationMinorScaleSevenths
            => new TheoryData<Func<Chord>, IEnumerable<Note>>
            {
                { () => new SeventhsHarmonizer(Scale.AMinor).I(), new [] {Note.A , Note.C, Note.E, Note.GSharp}},
                { () => new SeventhsHarmonizer(Scale.AMinor).II(),  new [] {Note.B , Note.D, Note.F, Note.A}},
                { () => new SeventhsHarmonizer(Scale.AMinor).III(),  new [] {Note.C , Note.E, Note.GSharp, Note.B}},
                { () => new SeventhsHarmonizer(Scale.AMinor).IV(),  new [] {Note.D , Note.F, Note.A, Note.C}},
                { () => new SeventhsHarmonizer(Scale.AMinor).V(),  new [] {Note.E , Note.GSharp, Note.B, Note.D}},
                { () => new SeventhsHarmonizer(Scale.AMinor).VI(),  new [] {Note.F , Note.A, Note.C, Note.E}},
                { () => new SeventhsHarmonizer(Scale.AMinor).VII(),  new [] {Note.GSharp , Note.B, Note.D, Note.F}}
            };

        [Theory, MemberData(nameof(HarmonizationMinorScaleSevenths))]
        public void HarmonizeSeventsMinorScale(Func<Chord> harmonize, IEnumerable<Note> expectedNotes)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedNotes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationDrop2
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop2()},
            };

        [Theory, MemberData(nameof(HarmonizationDrop2))]
        public void HarmonizeDrop2MajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationDrop3
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop3()},
            };

        [Theory, MemberData(nameof(HarmonizationDrop3))]
        public void HarmonizeDrop3MajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            var notes = harmonize().Notes;
            notes.Should().ContainInOrder(expectedChord.Notes);
        }
    }
}
