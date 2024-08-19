using FluentAssertions;
using Jaco.Notes;
using Jaco.Scale;

namespace JacoTests.Scale;

public class ScaleShould
{
	[Fact]
	public void GenerateMelodicLineForScalePitches()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);

		var melodicLine = scale.ScaleUpMelodicLine();

		melodicLine.Length.Should().Be(7);
		melodicLine.First().Should().Be(new Note(Pitch.C, Duration.Eighth, Octave.C3));
		melodicLine.Last().Should().Be(new Note(Pitch.B, Duration.Eighth, Octave.C3));
	}

	[Fact]
	public void GenerateReverseMelodicLineForScalePitches()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);
		var reverseMelodicLine = scale.ScaleDownMelodicLine();

		reverseMelodicLine.Length.Should().Be(7);
		reverseMelodicLine.First().Should().Be(new Note(Pitch.B, Duration.Eighth, Octave.C3));
		reverseMelodicLine.Last().Should().Be(new Note(Pitch.C, Duration.Eighth, Octave.C2));
	}

	[Fact]
	public void GenerateThirdsFromI()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Ionian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.I).ToList();

		thirdsFrom[0].Should().Be(Pitch.C);
		thirdsFrom[1].Should().Be(Pitch.E);
		thirdsFrom[2].Should().Be(Pitch.G);
		thirdsFrom[3].Should().Be(Pitch.B);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.I).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C3));
	}

	[Fact]
	public void GenerateThirdsFromII()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Dorian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.II).ToList();

		thirdsFrom[0].Should().Be(Pitch.D);
		thirdsFrom[1].Should().Be(Pitch.F);
		thirdsFrom[2].Should().Be(Pitch.A);
		thirdsFrom[3].Should().Be(Pitch.C);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.II).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}

	[Fact]
	public void GenerateThirdsFromIII()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Phrygian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.III).ToList();

		thirdsFrom[0].Should().Be(Pitch.EFlat);
		thirdsFrom[1].Should().Be(Pitch.G);
		thirdsFrom[2].Should().Be(Pitch.BFlat);
		thirdsFrom[3].Should().Be(Pitch.DFlat);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.III).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}

	[Fact]
	public void GenerateThirdsFromIV()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Lydian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.IV).ToList();

		thirdsFrom[0].Should().Be(Pitch.FSharp);
		thirdsFrom[1].Should().Be(Pitch.A);
		thirdsFrom[2].Should().Be(Pitch.C);
		thirdsFrom[3].Should().Be(Pitch.E);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.IV).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}

	[Fact]
	public void GenerateThirdsFromV()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Mixolydian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.V).ToList();

		thirdsFrom[0].Should().Be(Pitch.G);
		thirdsFrom[1].Should().Be(Pitch.BFlat);
		thirdsFrom[2].Should().Be(Pitch.D);
		thirdsFrom[3].Should().Be(Pitch.F);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.V).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}

	[Fact]
	public void GenerateThirdsFromVI()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Aeolian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.VI).ToList();

		thirdsFrom[0].Should().Be(Pitch.AFlat);
		thirdsFrom[1].Should().Be(Pitch.C);
		thirdsFrom[2].Should().Be(Pitch.EFlat);
		thirdsFrom[3].Should().Be(Pitch.G);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.VI).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}

	[Fact]
	public void GenerateThirdsFromVII()
	{
		var scale = new Jaco.Scale.Scale(ScalePattern.Locrian, Pitch.C, Duration.Eighth, Octave.C3);
		var thirdsFrom = scale.ThirdsFrom(ScaleDegree.VII).ToList();

		thirdsFrom[0].Should().Be(Pitch.BFlat);
		thirdsFrom[1].Should().Be(Pitch.DFlat);
		thirdsFrom[2].Should().Be(Pitch.F);
		thirdsFrom[3].Should().Be(Pitch.AFlat);

		var melodicLineFromThirds = scale.MelodicThirdsFrom(ScaleDegree.VII).ToList();

		melodicLineFromThirds.Count.Should().Be(thirdsFrom.Count);
		melodicLineFromThirds[0].Should().Be(new Note(thirdsFrom[0], Duration.Eighth, Octave.C3));
		melodicLineFromThirds[1].Should().Be(new Note(thirdsFrom[1], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[2].Should().Be(new Note(thirdsFrom[2], Duration.Eighth, Octave.C4));
		melodicLineFromThirds[3].Should().Be(new Note(thirdsFrom[3], Duration.Eighth, Octave.C4));
	}
}