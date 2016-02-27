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
            };

        [Theory, MemberData(nameof(HarmonizationMajorScaleTriads))]
        public void HarmonizeScale(Func<Chord> harmonize, Chord expectedChord)
        {
            harmonize().Notes.Should().ContainInOrder(expectedChord.Notes);
        }
    }
}
