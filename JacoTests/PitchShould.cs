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
        Pitch.C.Flat().Should().Be(Pitch.B);
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

    [Fact]
    public void MeasureSemitonesBetweenPitches()
    {
        Assert.Equal(0, Pitch.C.AbsoluteDistanceTo(Pitch.C));
        Assert.Equal(1, Pitch.C.AbsoluteDistanceTo(Pitch.CSharp));
        Assert.Equal(1, Pitch.C.AbsoluteDistanceTo(Pitch.DFlat));
        Assert.Equal(2, Pitch.C.AbsoluteDistanceTo(Pitch.D));
        Assert.Equal(3, Pitch.C.AbsoluteDistanceTo(Pitch.EFlat));
        Assert.Equal(4, Pitch.C.AbsoluteDistanceTo(Pitch.E));
        Assert.Equal(5, Pitch.C.AbsoluteDistanceTo(Pitch.F));
        Assert.Equal(6, Pitch.C.AbsoluteDistanceTo(Pitch.FSharp));
        Assert.Equal(6, Pitch.C.AbsoluteDistanceTo(Pitch.GFlat));
        Assert.Equal(7, Pitch.C.AbsoluteDistanceTo(Pitch.G));
        Assert.Equal(8, Pitch.C.AbsoluteDistanceTo(Pitch.GSharp));
        Assert.Equal(8, Pitch.C.AbsoluteDistanceTo(Pitch.AFlat));
        Assert.Equal(9, Pitch.C.AbsoluteDistanceTo(Pitch.A));
        Assert.Equal(10, Pitch.C.AbsoluteDistanceTo(Pitch.ASharp));
        Assert.Equal(10, Pitch.C.AbsoluteDistanceTo(Pitch.BFlat));
        Assert.Equal(11, Pitch.C.AbsoluteDistanceTo(Pitch.B));
    }

    [Fact]
    public void TransposeUsingUnison()
    {
        Pitch.C.Transpose(Interval.Unison).Should().Be(Pitch.C);
        Pitch.CSharp.Transpose(Interval.Unison).Should().Be(Pitch.CSharp);
        Pitch.DFlat.Transpose(Interval.Unison).Should().Be(Pitch.DFlat);
        Pitch.D.Transpose(Interval.Unison).Should().Be(Pitch.D);
        Pitch.DSharp.Transpose(Interval.Unison).Should().Be(Pitch.DSharp);
        Pitch.EFlat.Transpose(Interval.Unison).Should().Be(Pitch.EFlat);
        Pitch.E.Transpose(Interval.Unison).Should().Be(Pitch.E);
        Pitch.F.Transpose(Interval.Unison).Should().Be(Pitch.F);
        Pitch.FSharp.Transpose(Interval.Unison).Should().Be(Pitch.FSharp);
        Pitch.GFlat.Transpose(Interval.Unison).Should().Be(Pitch.GFlat);
        Pitch.G.Transpose(Interval.Unison).Should().Be(Pitch.G);
        Pitch.GSharp.Transpose(Interval.Unison).Should().Be(Pitch.GSharp);
        Pitch.AFlat.Transpose(Interval.Unison).Should().Be(Pitch.AFlat);
        Pitch.A.Transpose(Interval.Unison).Should().Be(Pitch.A);
        Pitch.ASharp.Transpose(Interval.Unison).Should().Be(Pitch.ASharp);
        Pitch.BFlat.Transpose(Interval.Unison).Should().Be(Pitch.BFlat);
        Pitch.B.Transpose(Interval.Unison).Should().Be(Pitch.B);
    }

    [Fact]
    public void TransposeUsingMinorSecond()
    {
        Pitch.C.Transpose(Interval.MinorSecond).Should().Be(Pitch.DFlat);
        Pitch.CSharp.Transpose(Interval.MinorSecond).Should().Be(Pitch.D);
        Pitch.DFlat.Transpose(Interval.MinorSecond).Should().Be(Pitch.D);
        Pitch.D.Transpose(Interval.MinorSecond).Should().Be(Pitch.EFlat);
        Pitch.DSharp.Transpose(Interval.MinorSecond).Should().Be(Pitch.E);
        Pitch.EFlat.Transpose(Interval.MinorSecond).Should().Be(Pitch.E);
        Pitch.E.Transpose(Interval.MinorSecond).Should().Be(Pitch.F);
        Pitch.F.Transpose(Interval.MinorSecond).Should().Be(Pitch.GFlat);
        Pitch.FSharp.Transpose(Interval.MinorSecond).Should().Be(Pitch.G);
        Pitch.GFlat.Transpose(Interval.MinorSecond).Should().Be(Pitch.G);
        Pitch.G.Transpose(Interval.MinorSecond).Should().Be(Pitch.AFlat);
        Pitch.GSharp.Transpose(Interval.MinorSecond).Should().Be(Pitch.A);
        Pitch.AFlat.Transpose(Interval.MinorSecond).Should().Be(Pitch.A);
        Pitch.A.Transpose(Interval.MinorSecond).Should().Be(Pitch.BFlat);
        Pitch.ASharp.Transpose(Interval.MinorSecond).Should().Be(Pitch.B);
        Pitch.BFlat.Transpose(Interval.MinorSecond).Should().Be(Pitch.B);
        Pitch.B.Transpose(Interval.MinorSecond).Should().Be(Pitch.C);
    }

    [Fact]
    public void TransposeUsingMajorSecond()
    {
        Pitch.C.Transpose(Interval.MajorSecond).Should().Be(Pitch.D);
        Pitch.CSharp.Transpose(Interval.MajorSecond).Should().Be(Pitch.DSharp);
        Pitch.DFlat.Transpose(Interval.MajorSecond).Should().Be(Pitch.EFlat);
        Pitch.D.Transpose(Interval.MajorSecond).Should().Be(Pitch.E);
        Pitch.DSharp.Transpose(Interval.MajorSecond).Should().Be(Pitch.F);
        Pitch.EFlat.Transpose(Interval.MajorSecond).Should().Be(Pitch.F);
        Pitch.E.Transpose(Interval.MajorSecond).Should().Be(Pitch.FSharp);
        Pitch.F.Transpose(Interval.MajorSecond).Should().Be(Pitch.G);
        Pitch.FSharp.Transpose(Interval.MajorSecond).Should().Be(Pitch.GSharp);
        Pitch.GFlat.Transpose(Interval.MajorSecond).Should().Be(Pitch.AFlat);
        Pitch.G.Transpose(Interval.MajorSecond).Should().Be(Pitch.A);
        Pitch.GSharp.Transpose(Interval.MajorSecond).Should().Be(Pitch.ASharp);
        Pitch.AFlat.Transpose(Interval.MajorSecond).Should().Be(Pitch.BFlat);
        Pitch.A.Transpose(Interval.MajorSecond).Should().Be(Pitch.B);
        Pitch.ASharp.Transpose(Interval.MajorSecond).Should().Be(Pitch.C);
        Pitch.BFlat.Transpose(Interval.MajorSecond).Should().Be(Pitch.C);
        Pitch.B.Transpose(Interval.MajorSecond).Should().Be(Pitch.CSharp);
    }

    [Fact]
    public void TransposeUsingMinorThird()
    {
        Pitch.C.Transpose(Interval.MinorThird).Should().Be(Pitch.EFlat);
        Pitch.CSharp.Transpose(Interval.MinorThird).Should().Be(Pitch.E);
        Pitch.DFlat.Transpose(Interval.MinorThird).Should().Be(Pitch.E);
        Pitch.D.Transpose(Interval.MinorThird).Should().Be(Pitch.F);
        Pitch.DSharp.Transpose(Interval.MinorThird).Should().Be(Pitch.FSharp);
        Pitch.EFlat.Transpose(Interval.MinorThird).Should().Be(Pitch.GFlat);
        Pitch.E.Transpose(Interval.MinorThird).Should().Be(Pitch.G);
        Pitch.F.Transpose(Interval.MinorThird).Should().Be(Pitch.AFlat);
        Pitch.FSharp.Transpose(Interval.MinorThird).Should().Be(Pitch.A);
        Pitch.GFlat.Transpose(Interval.MinorThird).Should().Be(Pitch.A);
        Pitch.G.Transpose(Interval.MinorThird).Should().Be(Pitch.BFlat);
        Pitch.GSharp.Transpose(Interval.MinorThird).Should().Be(Pitch.B);
        Pitch.AFlat.Transpose(Interval.MinorThird).Should().Be(Pitch.B);
        Pitch.A.Transpose(Interval.MinorThird).Should().Be(Pitch.C);
        Pitch.ASharp.Transpose(Interval.MinorThird).Should().Be(Pitch.CSharp);
        Pitch.BFlat.Transpose(Interval.MinorThird).Should().Be(Pitch.CSharp);
        Pitch.B.Transpose(Interval.MinorThird).Should().Be(Pitch.D);
    }

    [Fact]
    public void TransposeUsingMajorThird()
    {
        Pitch.C.Transpose(Interval.MajorThird).Should().Be(Pitch.E);
        Pitch.CSharp.Transpose(Interval.MajorThird).Should().Be(Pitch.F);
        Pitch.DFlat.Transpose(Interval.MajorThird).Should().Be(Pitch.F);
        Pitch.D.Transpose(Interval.MajorThird).Should().Be(Pitch.FSharp);
        Pitch.DSharp.Transpose(Interval.MajorThird).Should().Be(Pitch.G);
        Pitch.EFlat.Transpose(Interval.MajorThird).Should().Be(Pitch.G);
        Pitch.E.Transpose(Interval.MajorThird).Should().Be(Pitch.GSharp);
        Pitch.F.Transpose(Interval.MajorThird).Should().Be(Pitch.A);
        Pitch.FSharp.Transpose(Interval.MajorThird).Should().Be(Pitch.ASharp);
        Pitch.GFlat.Transpose(Interval.MajorThird).Should().Be(Pitch.BFlat);
        Pitch.G.Transpose(Interval.MajorThird).Should().Be(Pitch.B);
        Pitch.GSharp.Transpose(Interval.MajorThird).Should().Be(Pitch.C);
        Pitch.AFlat.Transpose(Interval.MajorThird).Should().Be(Pitch.C);
        Pitch.A.Transpose(Interval.MajorThird).Should().Be(Pitch.CSharp);
        Pitch.ASharp.Transpose(Interval.MajorThird).Should().Be(Pitch.D);
        Pitch.BFlat.Transpose(Interval.MajorThird).Should().Be(Pitch.D);
        Pitch.B.Transpose(Interval.MajorThird).Should().Be(Pitch.DSharp);
    }

    [Fact]
    public void TransposeUsingPerfectFourth()
    {
        Pitch.C.Transpose(Interval.PerfectFourth).Should().Be(Pitch.F);
        Pitch.CSharp.Transpose(Interval.PerfectFourth).Should().Be(Pitch.FSharp);
        Pitch.DFlat.Transpose(Interval.PerfectFourth).Should().Be(Pitch.GFlat);
        Pitch.D.Transpose(Interval.PerfectFourth).Should().Be(Pitch.G);
        Pitch.DSharp.Transpose(Interval.PerfectFourth).Should().Be(Pitch.GSharp);
        Pitch.EFlat.Transpose(Interval.PerfectFourth).Should().Be(Pitch.AFlat);
        Pitch.E.Transpose(Interval.PerfectFourth).Should().Be(Pitch.A);
        Pitch.F.Transpose(Interval.PerfectFourth).Should().Be(Pitch.B);
        Pitch.FSharp.Transpose(Interval.PerfectFourth).Should().Be(Pitch.C);
        Pitch.GFlat.Transpose(Interval.PerfectFourth).Should().Be(Pitch.B);
        Pitch.G.Transpose(Interval.PerfectFourth).Should().Be(Pitch.C);
        Pitch.GSharp.Transpose(Interval.PerfectFourth).Should().Be(Pitch.CSharp);
        Pitch.AFlat.Transpose(Interval.PerfectFourth).Should().Be(Pitch.DFlat);
        Pitch.A.Transpose(Interval.PerfectFourth).Should().Be(Pitch.D);
        Pitch.ASharp.Transpose(Interval.PerfectFourth).Should().Be(Pitch.DSharp);
        Pitch.BFlat.Transpose(Interval.PerfectFourth).Should().Be(Pitch.EFlat);
        Pitch.B.Transpose(Interval.PerfectFourth).Should().Be(Pitch.E);
    }

    [Fact]
    public void TransposeUsingAugmentedFourth()
    {
        Pitch.C.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.FSharp);
        Pitch.CSharp.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.G);
        Pitch.DFlat.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.G);
        Pitch.D.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.GSharp);
        Pitch.DSharp.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.A);
        Pitch.EFlat.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.A);
        Pitch.E.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.ASharp);
        Pitch.F.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.BSharp);
        Pitch.FSharp.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.C);
        Pitch.GFlat.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.C);
        Pitch.G.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.CSharp);
        Pitch.GSharp.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.D);
        Pitch.AFlat.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.D);
        Pitch.A.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.DSharp);
        Pitch.ASharp.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.E);
        Pitch.BFlat.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.E);
        Pitch.B.Transpose(Interval.AugmentedFourth).Should().Be(Pitch.ESharp);
    }

    [Fact]
    public void TransposeUsingDiminishedFifth()
    {
        Pitch.C.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.GFlat);
        Pitch.CSharp.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.G);
        Pitch.DFlat.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.G);
        Pitch.D.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.AFlat);
        Pitch.DSharp.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.A);
        Pitch.EFlat.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.A);
        Pitch.E.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.BFlat);
        Pitch.F.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.C);
        Pitch.FSharp.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.CSharp);
        Pitch.GFlat.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.C);
        Pitch.G.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.DFlat);
        Pitch.GSharp.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.D);
        Pitch.AFlat.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.D);
        Pitch.A.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.EFlat);
        Pitch.ASharp.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.E);
        Pitch.BFlat.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.FFlat);
        Pitch.B.Transpose(Interval.DiminishedFifth).Should().Be(Pitch.F);
    }

    [Fact]
    public void TransposeUsingTritone()
    {
        Pitch.C.Transpose(Interval.Tritone).Should().Be(Pitch.GFlat);
        Pitch.CSharp.Transpose(Interval.Tritone).Should().Be(Pitch.G);
        Pitch.DFlat.Transpose(Interval.Tritone).Should().Be(Pitch.G);
        Pitch.D.Transpose(Interval.Tritone).Should().Be(Pitch.AFlat);
        Pitch.DSharp.Transpose(Interval.Tritone).Should().Be(Pitch.A);
        Pitch.EFlat.Transpose(Interval.Tritone).Should().Be(Pitch.A);
        Pitch.E.Transpose(Interval.Tritone).Should().Be(Pitch.BFlat);
        Pitch.F.Transpose(Interval.Tritone).Should().Be(Pitch.C);
        Pitch.FSharp.Transpose(Interval.Tritone).Should().Be(Pitch.CSharp);
        Pitch.GFlat.Transpose(Interval.Tritone).Should().Be(Pitch.C);
        Pitch.G.Transpose(Interval.Tritone).Should().Be(Pitch.DFlat);
        Pitch.GSharp.Transpose(Interval.Tritone).Should().Be(Pitch.D);
        Pitch.AFlat.Transpose(Interval.Tritone).Should().Be(Pitch.D);
        Pitch.A.Transpose(Interval.Tritone).Should().Be(Pitch.EFlat);
        Pitch.ASharp.Transpose(Interval.Tritone).Should().Be(Pitch.E);
        Pitch.BFlat.Transpose(Interval.Tritone).Should().Be(Pitch.FFlat);
        Pitch.B.Transpose(Interval.Tritone).Should().Be(Pitch.F);
    }

    [Fact]
    public void TransposeUsingPerfectFifth()
    {
        Pitch.C.Transpose(Interval.PerfectFifth).Should().Be(Pitch.G);
        Pitch.CSharp.Transpose(Interval.PerfectFifth).Should().Be(Pitch.GSharp);
        Pitch.DFlat.Transpose(Interval.PerfectFifth).Should().Be(Pitch.AFlat);
        Pitch.D.Transpose(Interval.PerfectFifth).Should().Be(Pitch.A);
        Pitch.DSharp.Transpose(Interval.PerfectFifth).Should().Be(Pitch.ASharp);
        Pitch.EFlat.Transpose(Interval.PerfectFifth).Should().Be(Pitch.BFlat);
        Pitch.E.Transpose(Interval.PerfectFifth).Should().Be(Pitch.B);
        Pitch.F.Transpose(Interval.PerfectFifth).Should().Be(Pitch.CSharp);
        Pitch.FSharp.Transpose(Interval.PerfectFifth).Should().Be(Pitch.D);
        Pitch.GFlat.Transpose(Interval.PerfectFifth).Should().Be(Pitch.DFlat);
        Pitch.G.Transpose(Interval.PerfectFifth).Should().Be(Pitch.D);
        Pitch.GSharp.Transpose(Interval.PerfectFifth).Should().Be(Pitch.DSharp);
        Pitch.AFlat.Transpose(Interval.PerfectFifth).Should().Be(Pitch.EFlat);
        Pitch.A.Transpose(Interval.PerfectFifth).Should().Be(Pitch.E);
        Pitch.ASharp.Transpose(Interval.PerfectFifth).Should().Be(Pitch.F);
        Pitch.BFlat.Transpose(Interval.PerfectFifth).Should().Be(Pitch.F);
        Pitch.B.Transpose(Interval.PerfectFifth).Should().Be(Pitch.FSharp);
    }

    [Fact]
    public void TransposeUsingAugmentedFifth()
    {
        Pitch.C.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.GSharp);
        Pitch.CSharp.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.A);
        Pitch.DFlat.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.A);
        Pitch.D.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.ASharp);
        Pitch.DSharp.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.B);
        Pitch.EFlat.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.B);
        Pitch.E.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.BSharp);
        Pitch.F.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.D);
        Pitch.FSharp.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.DSharp);
        Pitch.GFlat.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.D);
        Pitch.G.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.DSharp);
        Pitch.GSharp.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.E);
        Pitch.AFlat.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.E);
        Pitch.A.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.ESharp);
        Pitch.ASharp.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.F);
        Pitch.BFlat.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.FSharp);
        Pitch.B.Transpose(Interval.AugmentedFifth).Should().Be(Pitch.G);
    }

    [Fact]
    public void TransposeUsingMinorSixth()
    {
        Pitch.C.Transpose(Interval.MinorSixth).Should().Be(Pitch.AFlat);
        Pitch.CSharp.Transpose(Interval.MinorSixth).Should().Be(Pitch.A);
        Pitch.DFlat.Transpose(Interval.MinorSixth).Should().Be(Pitch.A);
        Pitch.D.Transpose(Interval.MinorSixth).Should().Be(Pitch.BFlat);
        Pitch.DSharp.Transpose(Interval.MinorSixth).Should().Be(Pitch.B);
        Pitch.EFlat.Transpose(Interval.MinorSixth).Should().Be(Pitch.B);
        Pitch.E.Transpose(Interval.MinorSixth).Should().Be(Pitch.C);
        Pitch.F.Transpose(Interval.MinorSixth).Should().Be(Pitch.DFlat);
        Pitch.FSharp.Transpose(Interval.MinorSixth).Should().Be(Pitch.D);
        Pitch.GFlat.Transpose(Interval.MinorSixth).Should().Be(Pitch.D);
        Pitch.G.Transpose(Interval.MinorSixth).Should().Be(Pitch.EFlat);
        Pitch.GSharp.Transpose(Interval.MinorSixth).Should().Be(Pitch.E);
        Pitch.AFlat.Transpose(Interval.MinorSixth).Should().Be(Pitch.E);
        Pitch.A.Transpose(Interval.MinorSixth).Should().Be(Pitch.F);
        Pitch.ASharp.Transpose(Interval.MinorSixth).Should().Be(Pitch.FSharp);
        Pitch.BFlat.Transpose(Interval.MinorSixth).Should().Be(Pitch.GFlat);
        Pitch.B.Transpose(Interval.MinorSixth).Should().Be(Pitch.G);
    }

    [Fact]
    public void TransposeUsingMajorSixth()
    {
        Pitch.C.Transpose(Interval.MajorSixth).Should().Be(Pitch.A);
        Pitch.CSharp.Transpose(Interval.MajorSixth).Should().Be(Pitch.ASharp);
        Pitch.DFlat.Transpose(Interval.MajorSixth).Should().Be(Pitch.BFlat);
        Pitch.D.Transpose(Interval.MajorSixth).Should().Be(Pitch.B);
        Pitch.DSharp.Transpose(Interval.MajorSixth).Should().Be(Pitch.C);
        Pitch.EFlat.Transpose(Interval.MajorSixth).Should().Be(Pitch.C);
        Pitch.E.Transpose(Interval.MajorSixth).Should().Be(Pitch.CSharp);
        Pitch.F.Transpose(Interval.MajorSixth).Should().Be(Pitch.D);
        Pitch.FSharp.Transpose(Interval.MajorSixth).Should().Be(Pitch.DSharp);
        Pitch.GFlat.Transpose(Interval.MajorSixth).Should().Be(Pitch.EFlat);
        Pitch.G.Transpose(Interval.MajorSixth).Should().Be(Pitch.E);
        Pitch.GSharp.Transpose(Interval.MajorSixth).Should().Be(Pitch.F);
        Pitch.AFlat.Transpose(Interval.MajorSixth).Should().Be(Pitch.F);
        Pitch.A.Transpose(Interval.MajorSixth).Should().Be(Pitch.FSharp);
        Pitch.ASharp.Transpose(Interval.MajorSixth).Should().Be(Pitch.G);
        Pitch.BFlat.Transpose(Interval.MajorSixth).Should().Be(Pitch.G);
        Pitch.B.Transpose(Interval.MajorSixth).Should().Be(Pitch.GSharp);
    }

    [Fact]
    public void TransposeUsingDiminishedSeventh()
    {
        Pitch.C.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.A);
        Pitch.CSharp.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.ASharp);
        Pitch.DFlat.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.BFlat);
        Pitch.D.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.B);
        Pitch.DSharp.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.C);
        Pitch.EFlat.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.C);
        Pitch.E.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.CSharp);
        Pitch.F.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.EFlat);
        Pitch.FSharp.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.E);
        Pitch.GFlat.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.E);
        Pitch.G.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.FFlat);
        Pitch.GSharp.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.F);
        Pitch.AFlat.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.F);
        Pitch.A.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.FSharp);
        Pitch.ASharp.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.G);
        Pitch.BFlat.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.G);
        Pitch.B.Transpose(Interval.DiminishedSeventh).Should().Be(Pitch.GSharp);
    }

    [Fact]
    public void TransposeUsingMinorSeventh()
    {
        Pitch.C.Transpose(Interval.MinorSeventh).Should().Be(Pitch.BFlat);
        Pitch.CSharp.Transpose(Interval.MinorSeventh).Should().Be(Pitch.B);
        Pitch.DFlat.Transpose(Interval.MinorSeventh).Should().Be(Pitch.B);
        Pitch.D.Transpose(Interval.MinorSeventh).Should().Be(Pitch.C);
        Pitch.DSharp.Transpose(Interval.MinorSeventh).Should().Be(Pitch.CSharp);
        Pitch.EFlat.Transpose(Interval.MinorSeventh).Should().Be(Pitch.DFlat);
        Pitch.E.Transpose(Interval.MinorSeventh).Should().Be(Pitch.D);
        Pitch.F.Transpose(Interval.MinorSeventh).Should().Be(Pitch.E);
        Pitch.FSharp.Transpose(Interval.MinorSeventh).Should().Be(Pitch.F);
        Pitch.GFlat.Transpose(Interval.MinorSeventh).Should().Be(Pitch.E);
        Pitch.G.Transpose(Interval.MinorSeventh).Should().Be(Pitch.F);
        Pitch.GSharp.Transpose(Interval.MinorSeventh).Should().Be(Pitch.GFlat);
        Pitch.AFlat.Transpose(Interval.MinorSeventh).Should().Be(Pitch.GFlat);
        Pitch.A.Transpose(Interval.MinorSeventh).Should().Be(Pitch.G);
        Pitch.ASharp.Transpose(Interval.MinorSeventh).Should().Be(Pitch.AFlat);
        Pitch.BFlat.Transpose(Interval.MinorSeventh).Should().Be(Pitch.AFlat);
        Pitch.B.Transpose(Interval.MinorSeventh).Should().Be(Pitch.A);
    }

    [Fact]
    public void TransposeUsingMajorSeventh()
    {
        Pitch.C.Transpose(Interval.MajorSeventh).Should().Be(Pitch.B);
        Pitch.CSharp.Transpose(Interval.MajorSeventh).Should().Be(Pitch.C);
        Pitch.DFlat.Transpose(Interval.MajorSeventh).Should().Be(Pitch.C);
        Pitch.D.Transpose(Interval.MajorSeventh).Should().Be(Pitch.CSharp);
        Pitch.DSharp.Transpose(Interval.MajorSeventh).Should().Be(Pitch.D);
        Pitch.EFlat.Transpose(Interval.MajorSeventh).Should().Be(Pitch.D);
        Pitch.E.Transpose(Interval.MajorSeventh).Should().Be(Pitch.DSharp);
        Pitch.F.Transpose(Interval.MajorSeventh).Should().Be(Pitch.ESharp);
        Pitch.FSharp.Transpose(Interval.MajorSeventh).Should().Be(Pitch.F);
        Pitch.GFlat.Transpose(Interval.MajorSeventh).Should().Be(Pitch.F);
        Pitch.G.Transpose(Interval.MajorSeventh).Should().Be(Pitch.FSharp);
        Pitch.GSharp.Transpose(Interval.MajorSeventh).Should().Be(Pitch.G);
        Pitch.AFlat.Transpose(Interval.MajorSeventh).Should().Be(Pitch.G);
        Pitch.A.Transpose(Interval.MajorSeventh).Should().Be(Pitch.GSharp);
        Pitch.ASharp.Transpose(Interval.MajorSeventh).Should().Be(Pitch.A);
        Pitch.BFlat.Transpose(Interval.MajorSeventh).Should().Be(Pitch.A);
        Pitch.B.Transpose(Interval.MajorSeventh).Should().Be(Pitch.ASharp);
    }

    [Fact]
    public void TransposeUsingPerfectEleventh()
    {
        Pitch.C.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.F);
        Pitch.CSharp.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.FSharp);
        Pitch.DFlat.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.GFlat);
        Pitch.D.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.G);
        Pitch.DSharp.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.GSharp);
        Pitch.EFlat.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.AFlat);
        Pitch.E.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.A);
        Pitch.F.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.B);
        Pitch.FSharp.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.C);
        Pitch.GFlat.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.B);
        Pitch.G.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.C);
        Pitch.GSharp.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.CSharp);
        Pitch.AFlat.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.DFlat);
        Pitch.A.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.D);
        Pitch.ASharp.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.DSharp);
        Pitch.BFlat.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.EFlat);
        Pitch.B.Transpose(Interval.PerfectEleventh).Should().Be(Pitch.E);
    }

    [Fact]
    public void TransposeUsingAugmentedEleventh()
    {
        Pitch.C.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.FSharp);
        Pitch.CSharp.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.G);
        Pitch.DFlat.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.G);
        Pitch.D.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.GSharp);
        Pitch.DSharp.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.A);
        Pitch.EFlat.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.A);
        Pitch.E.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.ASharp);
        Pitch.F.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.BSharp);
        Pitch.FSharp.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.C);
        Pitch.GFlat.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.C);
        Pitch.G.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.CSharp);
        Pitch.GSharp.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.D);
        Pitch.AFlat.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.D);
        Pitch.A.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.DSharp);
        Pitch.ASharp.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.E);
        Pitch.BFlat.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.E);
        Pitch.B.Transpose(Interval.AugmentedEleventh).Should().Be(Pitch.ESharp);
    }

    [Fact]
    public void TransposeUsingMinorThirteen()
    {
        Pitch.C.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.AFlat);
        Pitch.CSharp.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.A);
        Pitch.DFlat.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.A);
        Pitch.D.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.BFlat);
        Pitch.DSharp.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.B);
        Pitch.EFlat.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.B);
        Pitch.E.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.C);
        Pitch.F.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.DFlat);
        Pitch.FSharp.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.D);
        Pitch.GFlat.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.EFlat);
        Pitch.G.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.E);
        Pitch.GSharp.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.F);
        Pitch.AFlat.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.E);
        Pitch.A.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.F);
        Pitch.ASharp.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.FSharp);
        Pitch.BFlat.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.GFlat);
        Pitch.B.Transpose(Interval.MinorThirteenth).Should().Be(Pitch.G);
    }

    [Fact]
    public void TransposeUsingMajorThirteen()
    {
        Pitch.C.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.A);
        Pitch.CSharp.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.ASharp);
        Pitch.DFlat.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.BFlat);
        Pitch.D.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.B);
        Pitch.DSharp.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.C);
        Pitch.EFlat.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.C);
        Pitch.E.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.CSharp);
        Pitch.F.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.D);
        Pitch.FSharp.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.DSharp);
        Pitch.GFlat.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.E);
        Pitch.G.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.ESharp);
        Pitch.GSharp.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.F);
        Pitch.AFlat.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.F);
        Pitch.A.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.FSharp);
        Pitch.ASharp.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.G);
        Pitch.BFlat.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.G);
        Pitch.B.Transpose(Interval.MajorThirteenth).Should().Be(Pitch.GSharp);
    }
}