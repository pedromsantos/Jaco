using System;
using FluentAssertions;
using Jaco;
using Xunit;

namespace JacoTests
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
                { () => new TriadsHarmonizer(Scale.CMajor).VII(),  new Chord(Note.B, ChordFunction.Diminished)},
                { () => new SeventhsHarmonizer(Scale.CMajor).I(),  new Chord(Note.C, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).II(),  new Chord(Note.D, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).III(),  new Chord(Note.E, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).IV(),  new Chord(Note.F, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).V(),  new Chord(Note.G, ChordFunction.Dominant7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).VI(),  new Chord(Note.A, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.CMajor).VII(),  new Chord(Note.B, ChordFunction.Minor7b5)},
                // Minor scales
                { () => new TriadsHarmonizer(Scale.AMinor).I(),  new Chord(Note.A, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.AMinor).II(),  new Chord(Note.B, ChordFunction.Diminished)},
                { () => new TriadsHarmonizer(Scale.AMinor).III(),  new Chord(Note.C, ChordFunction.Augmented)},
                { () => new TriadsHarmonizer(Scale.AMinor).IV(),  new Chord(Note.D, ChordFunction.Minor)},
                { () => new TriadsHarmonizer(Scale.AMinor).V(),  new Chord(Note.E, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.AMinor).VI(),  new Chord(Note.F, ChordFunction.Major)},
                { () => new TriadsHarmonizer(Scale.AMinor).VII(),  new Chord(Note.GSharp, ChordFunction.Diminished)},
                { () => new SeventhsHarmonizer(Scale.AMinor).I(),  new Chord(Note.A, ChordFunction.MinorMaj7)},
                { () => new SeventhsHarmonizer(Scale.AMinor).II(),  new Chord(Note.B, ChordFunction.Minor7b5)},
                { () => new SeventhsHarmonizer(Scale.AMinor).III(),  new Chord(Note.C, ChordFunction.Augmented7)},
                { () => new SeventhsHarmonizer(Scale.AMinor).IV(),  new Chord(Note.D, ChordFunction.Minor7)},
                { () => new SeventhsHarmonizer(Scale.AMinor).V(),  new Chord(Note.E, ChordFunction.Dominant7)},
                { () => new SeventhsHarmonizer(Scale.AMinor).VI(),  new Chord(Note.F, ChordFunction.Major7)},
                { () => new SeventhsHarmonizer(Scale.AMinor).VII(),  new Chord(Note.GSharp, ChordFunction.Diminished7)},
                // Drop2 harmonizer
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop2()},
                { () => new Drop2Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop2()},
                // Drop3 harmonizer
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).I(),  new Chord(Note.C, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).II(),  new Chord(Note.D, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).III(),  new Chord(Note.E, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).IV(),  new Chord(Note.F, ChordFunction.Major7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).V(),  new Chord(Note.G, ChordFunction.Dominant7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VI(),  new Chord(Note.A, ChordFunction.Minor7).ToDrop3()},
                { () => new Drop3Harmonizer(new SeventhsHarmonizer(Scale.CMajor)).VII(),  new Chord(Note.B, ChordFunction.Minor7b5).ToDrop3()},
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleTriads))]
        public void HarmonizeScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }
    }
}
