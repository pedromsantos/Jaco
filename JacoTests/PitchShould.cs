using FluentAssertions;
using Jaco;

namespace JacoTests;


public class PitchShould
{
    [Fact]
    public void PitchesStringRepresentationIsThePitchName()
    {
        Pitch.C.ToString().Should().Be("C");
        Pitch.CSharp.ToString().Should().Be("C#");
        Pitch.DFlat.ToString().Should().Be("Db");
        Pitch.D.ToString().Should().Be("D");
        Pitch.DSharp.ToString().Should().Be("D#");
        Pitch.EFlat.ToString().Should().Be("Eb");
        Pitch.E.ToString().Should().Be("E");
        Pitch.ESharp.ToString().Should().Be("E#");
        Pitch.FFlat.ToString().Should().Be("Fb");
        Pitch.F.ToString().Should().Be("F");
        Pitch.FSharp.ToString().Should().Be("F#");
        Pitch.GFlat.ToString().Should().Be("Gb");
        Pitch.G.ToString().Should().Be("G");
        Pitch.GSharp.ToString().Should().Be("G#");
        Pitch.AFlat.ToString().Should().Be("Ab");
        Pitch.A.ToString().Should().Be("A");
        Pitch.ASharp.ToString().Should().Be("A#");
        Pitch.BFlat.ToString().Should().Be("Bb");
        Pitch.B.ToString().Should().Be("B");
        Pitch.BSharp.ToString().Should().Be("B#");
    }

    [Fact]
    public void PitchesWithSameValueAndAccidentalsAreEqual()
    {
        Pitch.CSharp.Should().Be(Pitch.DFlat);
        Pitch.DSharp.Should().Be(Pitch.EFlat);
        Pitch.ESharp.Should().Be(Pitch.FFlat);
        Pitch.FSharp.Should().Be(Pitch.GFlat);
        Pitch.GSharp.Should().Be(Pitch.AFlat);
        Pitch.ASharp.Should().Be(Pitch.BFlat);
        Pitch.BSharp.Should().Be(Pitch.CFlat);
        Pitch.DFlat.Should().Be(Pitch.CSharp);
        Pitch.EFlat.Should().Be(Pitch.DSharp);
        Pitch.FFlat.Should().Be(Pitch.ESharp);
        Pitch.GFlat.Should().Be(Pitch.FSharp);
        Pitch.AFlat.Should().Be(Pitch.GSharp);
        Pitch.BFlat.Should().Be(Pitch.ASharp);
        Pitch.CFlat.Should().Be(Pitch.BSharp);
    }

    [Fact]
    public void SharppeningAPitchReturnsAPitchHalfToneAbove()
    {
        Pitch.C.Sharp().Should().Be(Pitch.CSharp);
        Pitch.CSharp.Sharp().Should().Be(Pitch.D);
        Pitch.DFlat.Sharp().Should().Be(Pitch.D);
        Pitch.DSharp.Sharp().Should().Be(Pitch.E);
        Pitch.ESharp.Sharp().Should().Be(Pitch.F);
        Pitch.FSharp.Sharp().Should().Be(Pitch.G);
        Pitch.GSharp.Sharp().Should().Be(Pitch.A);
        Pitch.ASharp.Sharp().Should().Be(Pitch.B);
        Pitch.BSharp.Sharp().Should().Be(Pitch.C);
    }

    [Fact]
    public void FlateningAPitchReturnsAPitchHalfToneBelow()
    {
        Pitch.C.Flat().Should().Be(Pitch.BFlat);
        Pitch.CSharp.Flat().Should().Be(Pitch.C);
        Pitch.DFlat.Flat().Should().Be(Pitch.C);
        Pitch.D.Flat().Should().Be(Pitch.DFlat);
        Pitch.DSharp.Flat().Should().Be(Pitch.D);
        Pitch.ESharp.Flat().Should().Be(Pitch.E);
        Pitch.F.Flat().Should().Be(Pitch.E);
        Pitch.FSharp.Flat().Should().Be(Pitch.F);
        Pitch.GFlat.Flat().Should().Be(Pitch.F);
        Pitch.G.Flat().Should().Be(Pitch.GFlat);
        Pitch.GSharp.Flat().Should().Be(Pitch.G);
        Pitch.AFlat.Flat().Should().Be(Pitch.G);
        Pitch.A.Flat().Should().Be(Pitch.AFlat);
        Pitch.ASharp.Flat().Should().Be(Pitch.A);
        Pitch.BFlat.Flat().Should().Be(Pitch.A);
        Pitch.B.Flat().Should().Be(Pitch.BFlat);
        Pitch.BSharp.Flat().Should().Be(Pitch.B);
        Pitch.CFlat.Flat().Should().Be(Pitch.B);
    }

    [Fact]
    public void NaturalPitchReturnsThePitchWithoutAccidentals()
    {
        Pitch.CSharp.Natural().Should().Be(Pitch.C);
        Pitch.DFlat.Natural().Should().Be(Pitch.D);
        Pitch.DSharp.Natural().Should().Be(Pitch.D);
        Pitch.ESharp.Natural().Should().Be(Pitch.E);
        Pitch.FFlat.Natural().Should().Be(Pitch.F);
        Pitch.FSharp.Natural().Should().Be(Pitch.F);
        Pitch.GFlat.Natural().Should().Be(Pitch.G);
        Pitch.GSharp.Natural().Should().Be(Pitch.G);
        Pitch.AFlat.Natural().Should().Be(Pitch.A);
        Pitch.ASharp.Natural().Should().Be(Pitch.A);
        Pitch.BFlat.Natural().Should().Be(Pitch.B);
        Pitch.BSharp.Natural().Should().Be(Pitch.B);
        Pitch.CFlat.Natural().Should().Be(Pitch.C);
    }
}