using FluentAssertions;
using Jaco.Barry;
using Jaco.Notes;
using Jaco.Scale;

namespace JacoTests.Barry;

public class BarryLineShould
{
	[Fact]
	public void CreateArpeggioUpFromScaleDegreeI()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.I);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.C, Duration.Quarter, Octave.C3),
			new(Pitch.E, Duration.Quarter, Octave.C3),
			new(Pitch.G, Duration.Quarter, Octave.C3),
			new(Pitch.BFlat, Duration.Quarter, Octave.C3),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeII()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.II);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.D, Duration.Quarter, Octave.C3),
			new(Pitch.F, Duration.Quarter, Octave.C3),
			new(Pitch.A, Duration.Quarter, Octave.C3),
			new(Pitch.C, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeIII()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.III);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.E, Duration.Quarter, Octave.C3),
			new(Pitch.G, Duration.Quarter, Octave.C3),
			new(Pitch.BFlat, Duration.Quarter, Octave.C3),
			new(Pitch.D, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeIV()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.IV);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.F, Duration.Quarter, Octave.C3),
			new(Pitch.A, Duration.Quarter, Octave.C3),
			new(Pitch.C, Duration.Quarter, Octave.C4),
			new(Pitch.E, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeV()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.V);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.G, Duration.Quarter, Octave.C3),
			new(Pitch.BFlat, Duration.Quarter, Octave.C3),
			new(Pitch.D, Duration.Quarter, Octave.C4),
			new(Pitch.F, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeVI()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.VI);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.A, Duration.Quarter, Octave.C3),
			new(Pitch.C, Duration.Quarter, Octave.C4),
			new(Pitch.E, Duration.Quarter, Octave.C4),
			new(Pitch.G, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	[Fact]
	public void CreateArpeggioUpFromScaleDegreeVII()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.ArpeggioUpFrom(ScaleDegree.VII);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.BFlat, Duration.Quarter, Octave.C3),
			new(Pitch.D, Duration.Quarter, Octave.C4),
			new(Pitch.F, Duration.Quarter, Octave.C4),
			new(Pitch.A, Duration.Quarter, Octave.C4),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}

	/*[Fact]
	public void CreatePivotArpeggioUpFromScaleDegreeI()
	{
		var scale = new BarryDominantScale(Pitch.C, Duration.Quarter, Octave.C3);
		var line = new BarryHarrisLine(scale, Octave.C3, Duration.Quarter);

		line.PivotArpeggioUpFrom(ScaleDegree.I);

		var expected = new MelodicLine(new List<Note>
		{
			new(Pitch.C, Duration.Quarter, Octave.C3),
			new(Pitch.D, Duration.Quarter, Octave.C2),
			new(Pitch.F, Duration.Quarter, Octave.C2),
			new(Pitch.A, Duration.Quarter, Octave.C2),
		});

		line.AsEnumerable().Should().BeEquivalentTo(expected);
	}*/
}
