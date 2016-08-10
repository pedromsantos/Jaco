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
        private static readonly Scale CMajor = ScaleFormula.Ionian.CreateForRoot(Note.C);
        private static readonly Scale AMinor = ScaleFormula.Aolian.CreateForRoot(Note.A);

        public static TheoryData<Func<Chord>, Chord> HarmonizationMajorScaleTriads
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new TriadsHarmonizer(CMajor).I(),  new Chord(Note.C, ChordFunction.Major)},
                { () => new TriadsHarmonizer(CMajor).II(),  new Chord(Note.D, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(CMajor).III(),  new Chord(Note.E, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(CMajor).IV(),  new Chord(Note.F, ChordFunction.Major)},
                { () => new TriadsHarmonizer(CMajor).V(),  new Chord(Note.G, ChordFunction.Major)},
                { () => new TriadsHarmonizer(CMajor).VI(),  new Chord(Note.A, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(CMajor).VII(),  new Chord(Note.B, ChordFunction.Diminished)}
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleTriads))]
        public void HarmonizeTriadsMajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationMinorScaleTriads
           => new TheoryData<Func<Chord>, Chord>
           {
                { () => new TriadsHarmonizer(AMinor).I(),  new Chord(Note.A, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(AMinor).II(),  new Chord(Note.B, ChordFunction.Diminished)},
                { () => new TriadsHarmonizer(AMinor).III(),  new Chord(Note.C, ChordFunction.Augmented)},
                { () => new TriadsHarmonizer(AMinor).IV(),  new Chord(Note.D, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(AMinor).V(),  new Chord(
                    new NoteWithFunction(Note.E, Function.Root), 
                    new NoteWithFunction(Note.GSharp, Function.Third), 
                    new NoteWithFunction(Note.B, Function.Fifth))},
                { () => new TriadsHarmonizer(AMinor).VI(),  new Chord(Note.F, ChordFunction.Major)},
                { () => new TriadsHarmonizer(AMinor).VII(),  new Chord(Note.GSharp, ChordFunction.Diminished)}
           };

        [Theory, MemberData(nameof(HarmonizationMinorScaleTriads))]
        public void HarmonizeTriadsMinorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationMajorScaleSevents
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new SeventhsHarmonizer(CMajor).I(),  new Chord(Note.C, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(CMajor).II(),  new Chord(Note.D, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(CMajor).III(),  new Chord(Note.E, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(CMajor).IV(),  new Chord(Note.F, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(CMajor).V(),  new Chord(Note.G, ChordFunction.Dominant7)},
                { () => new SeventhsHarmonizer(CMajor).VI(),  new Chord(Note.A, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(CMajor).VII(),  new Chord(Note.B, ChordFunction.Minor7b5)}
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleSevents))]
        public void HarmonizeSeventsMajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        } 

        public static TheoryData<Func<Chord>, IEnumerable<Note>> HarmonizationMinorScaleSevenths
            => new TheoryData<Func<Chord>, IEnumerable<Note>>
            {
                { () => new SeventhsHarmonizer(AMinor).I(), new [] {Note.A , Note.C, Note.E, Note.GSharp}},
                { () => new SeventhsHarmonizer(AMinor).II(),  new [] {Note.B , Note.D, Note.F, Note.A}},
                { () => new SeventhsHarmonizer(AMinor).III(),  new [] {Note.C , Note.E, Note.GSharp, Note.B}},
                { () => new SeventhsHarmonizer(AMinor).IV(),  new [] {Note.D , Note.F, Note.A, Note.C}},
                { () => new SeventhsHarmonizer(AMinor).V(),  new [] {Note.E , Note.GSharp, Note.B, Note.D}},
                { () => new SeventhsHarmonizer(AMinor).VI(),  new [] {Note.F , Note.A, Note.C, Note.E}},
                { () => new SeventhsHarmonizer(AMinor).VII(),  new [] {Note.GSharp , Note.B, Note.D, Note.F}}
            };

        [Theory, MemberData(nameof(HarmonizationMinorScaleSevenths))]
        public void HarmonizeSeventsMinorScale(Func<Chord> harmonize, IEnumerable<Note> expectedNotes)
        {
            harmonize().Notes.Should().ContainInOrder(expectedNotes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationDrop2
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop2()},
            };

        [Theory, MemberData(nameof(HarmonizationDrop2))]
        public void HarmonizeDrop2MajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }

        public static TheoryData<Func<Chord>, Chord> HarmonizationDrop3
            => new TheoryData<Func<Chord>, Chord>
            {
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop3()},
            };

        [Theory, MemberData(nameof(HarmonizationDrop3))]
        public void HarmonizeDrop3MajorScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }
    }
}