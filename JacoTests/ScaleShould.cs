using FluentAssertions;
using Jaco;

namespace JacoTests;

public class ScaleShould
{
	[Fact]
	public void GenerateMelodicLineForScalePitches()
	{
		var scale = new Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);

		var melodicLine = scale.MelodicLine();

		melodicLine.Length.Should().Be(7);
		melodicLine.First().Should().Be(new Note(Pitch.C, Duration.Eighth, Octave.C3));
		melodicLine.Last().Should().Be(new Note(Pitch.B, Duration.Eighth, Octave.C3));
	}

	[Fact]
	public void GenerateReverseMelodicLineForScalePitches()
	{
		var scale = new Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);
		var reverseMelodicLine = scale.ReverseMelodicLine();

		reverseMelodicLine.Length.Should().Be(7);
		reverseMelodicLine.First().Should().Be(new Note(Pitch.B, Duration.Eighth, Octave.C3));
		reverseMelodicLine.Last().Should().Be(new Note(Pitch.C, Duration.Eighth, Octave.C3));
	}

	[Fact]
	public void GenerateThirdsFromI()
	{
		var scale = new Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.I);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.C);
		thirdsFromI[1].Should().Be(Pitch.E);
		thirdsFromI[2].Should().Be(Pitch.G);
		thirdsFromI[3].Should().Be(Pitch.B);
	}

	[Fact]
	public void GenerateThirdsFromII()
	{
		var scale = new Scale(ScalePattern.Dorian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.II);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.D);
		thirdsFromI[1].Should().Be(Pitch.F);
		thirdsFromI[2].Should().Be(Pitch.A);
		thirdsFromI[3].Should().Be(Pitch.C);
	}

	[Fact]
	public void GenerateThirdsFromIII()
	{
		var scale = new Scale(ScalePattern.Phrygian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.III);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.EFlat);
		thirdsFromI[1].Should().Be(Pitch.G);
		thirdsFromI[2].Should().Be(Pitch.BFlat);
		thirdsFromI[3].Should().Be(Pitch.DFlat);
	}

	[Fact]
	public void GenerateThirdsFromIV()
	{
		var scale = new Scale(ScalePattern.Lydian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.IV);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.FSharp);
		thirdsFromI[1].Should().Be(Pitch.A);
		thirdsFromI[2].Should().Be(Pitch.C);
		thirdsFromI[3].Should().Be(Pitch.E);
	}

	[Fact]
	public void GenerateThirdsFromV()
	{
		var scale = new Scale(ScalePattern.Mixolydian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.V);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.G);
		thirdsFromI[1].Should().Be(Pitch.BFlat);
		thirdsFromI[2].Should().Be(Pitch.D);
		thirdsFromI[3].Should().Be(Pitch.F);
	}

	[Fact]
	public void GenerateThirdsFromVI()
	{
		var scale = new Scale(ScalePattern.Aeolian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.VI);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.AFlat);
		thirdsFromI[1].Should().Be(Pitch.C);
		thirdsFromI[2].Should().Be(Pitch.EFlat);
		thirdsFromI[3].Should().Be(Pitch.G);
	}

	[Fact]
	public void GenerateThirdsFromVII()
	{
		var scale = new Scale(ScalePattern.Locrian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFromI = scale.ThirdsFrom(ScaleDegree.VII);

		thirdsFromI.Count.Should().Be(7);
		thirdsFromI[0].Should().Be(Pitch.BFlat);
		thirdsFromI[1].Should().Be(Pitch.DFlat);
		thirdsFromI[2].Should().Be(Pitch.F);
		thirdsFromI[3].Should().Be(Pitch.AFlat);
	}
}