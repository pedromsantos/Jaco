namespace JacoTests;

using FluentAssertions;
using Jaco;

public class JacoScaleShould
{
	[Fact]
	public void GenerateLineWithMinHalfStepsForMajorScale()
	{
		var scale = new BarryMajorScale(Pitch.C, Duration.Quarter, Octave.C2);
		var line = scale.ScaleDownMinHalfSteps();

		Assert.Equal(8, line.Count());

		line.ElementAt(0).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C2));
		line.ElementAt(1).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
		line.ElementAt(2).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(3).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
		line.ElementAt(4).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		line.ElementAt(5).Should().Be(new Note(Pitch.E, Duration.Quarter, Octave.C2));
		line.ElementAt(6).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		line.ElementAt(7).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
	}

	[Fact]
	public void GenerateLineWithMaxHalfStepsForMajorScale()
	{
		var scale = new BarryMajorScale(Pitch.C, Duration.Quarter, Octave.C2);
		var line = scale.ScaleDownMaxHalfSteps();

		Assert.Equal(10, line.Count());

		line.ElementAt(0).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C2));
		line.ElementAt(1).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
		line.ElementAt(2).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(3).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
		line.ElementAt(4).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		line.ElementAt(5).Should().Be(new Note(Pitch.E, Duration.Quarter, Octave.C2));
		line.ElementAt(6).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(7).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		line.ElementAt(8).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(9).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
	}

	[Fact]
	public void GenerateLineWithMinHalfStepsForMinorScale()
	{
		var scale = new BarryMinorScale(Pitch.C, Duration.Quarter, Octave.C2);
		var line = scale.ScaleDownMinHalfSteps();

		Assert.Equal(8, line.Count());

		line.ElementAt(0).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C2));
		line.ElementAt(1).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(2).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
		line.ElementAt(3).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		line.ElementAt(4).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(5).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		line.ElementAt(6).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(7).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
	}

	// [Fact]
	// public void GenerateLineWithMaxHalfStepsForMinorScale()
	// {
	// 	var scale = new BarryMinorScale(Pitch.C, Duration.Quarter, Octave.C2);
	// 	var line = scale.ScaleDownMaxHalfSteps();

	// 	Assert.Equal(10, line.Count());

	// 	line.ElementAt(0).Should().Be(new Note(Pitch.BFlat, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(1).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(2).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(3).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(4).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(5).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(6).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(7).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(8).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2));
	// 	line.ElementAt(9).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C2));
	// }

	[Fact]
	public void GenerateLineWithMinHalfStepsForDominantScale()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C2);
		var line = scale.ScaleDownMinHalfSteps();

		Assert.Equal(8, line.Count());

		line.ElementAt(0).Should().Be(new Note(Pitch.BFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(1).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
		line.ElementAt(2).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
		line.ElementAt(3).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		line.ElementAt(4).Should().Be(new Note(Pitch.E, Duration.Quarter, Octave.C2));
		line.ElementAt(5).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		line.ElementAt(6).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
		line.ElementAt(7).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C1));
	}

	[Fact]
	public void GenerateLineWithMaxHalfStepsForDominantScale()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C2);
		var line = scale.ScaleDownMaxHalfSteps();

		Assert.Equal(10, line.Count());

		line.ElementAt(0).Should().Be(new Note(Pitch.BFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(1).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
		line.ElementAt(2).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C2));
		line.ElementAt(3).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		line.ElementAt(4).Should().Be(new Note(Pitch.E, Duration.Quarter, Octave.C2));
		line.ElementAt(5).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(6).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		line.ElementAt(7).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2));
		line.ElementAt(8).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
		line.ElementAt(9).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C1));
	}
}