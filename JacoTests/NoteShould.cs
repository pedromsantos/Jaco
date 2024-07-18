using FluentAssertions;
using Jaco;
using Xunit;

namespace JacoTests;

public class NoteShould
{
	[Fact]
	public void TransposeByInterval()
	{
		var note = new Note(Pitch.C, Duration.Quarter, Octave.C1);

		note.Transpose(Interval.Unison).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MinorSecond).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MajorSecond).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MinorThird).Should().Be(new Note(Pitch.EFlat, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MajorThird).Should().Be(new Note(Pitch.E, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.PerfectFourth).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.AugmentedFourth).Should().Be(new Note(Pitch.FSharp, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.PerfectFifth).Should().Be(new Note(Pitch.G, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MinorSixth).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MajorSixth).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MinorSeventh).Should().Be(new Note(Pitch.BFlat, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.MajorSeventh).Should().Be(new Note(Pitch.B, Duration.Quarter, Octave.C1));
		note.Transpose(Interval.PerfectOctave).Should().Be(new Note(Pitch.C, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.MinorNinth).Should().Be(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.MajorNinth).Should().Be(new Note(Pitch.D, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.PerfectEleventh).Should().Be(new Note(Pitch.F, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.AugmentedEleventh).Should().Be(new Note(Pitch.FSharp, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.MinorThirteenth).Should().Be(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2));
		note.Transpose(Interval.MajorThirteenth).Should().Be(new Note(Pitch.A, Duration.Quarter, Octave.C2));
	}

	[Fact]
	public void MeasureIntervalsBetweenCAndAllOtherNotes()
	{
		var note = new Note(Pitch.C, Duration.Quarter, Octave.C1);

		note.IntervalTo(new Note(Pitch.DFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSecond);
		note.IntervalTo(new Note(Pitch.D, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSecond);
		note.IntervalTo(new Note(Pitch.EFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorThird);
		note.IntervalTo(new Note(Pitch.E, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorThird);
		note.IntervalTo(new Note(Pitch.F, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFourth);
		note.IntervalTo(new Note(Pitch.FSharp, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFourth);
		note.IntervalTo(new Note(Pitch.GFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.DiminishedFifth);
		note.IntervalTo(new Note(Pitch.G, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFifth);
		note.IntervalTo(new Note(Pitch.GSharp, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFifth);
		note.IntervalTo(new Note(Pitch.AFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSixth);
		note.IntervalTo(new Note(Pitch.A, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSixth);
		note.IntervalTo(new Note(Pitch.BFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSeventh);
		note.IntervalTo(new Note(Pitch.B, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSeventh);
		note.IntervalTo(new Note(Pitch.C, Duration.Quarter, Octave.C2)).Should().Be(Interval.PerfectOctave);
		note.IntervalTo(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2)).Should().Be(Interval.MinorNinth);
		note.IntervalTo(new Note(Pitch.D, Duration.Quarter, Octave.C2)).Should().Be(Interval.MajorNinth);
		note.IntervalTo(new Note(Pitch.F, Duration.Quarter, Octave.C2)).Should().Be(Interval.PerfectEleventh);
		note.IntervalTo(new Note(Pitch.FSharp, Duration.Quarter, Octave.C2)).Should().Be(Interval.AugmentedEleventh);
		note.IntervalTo(new Note(Pitch.AFlat, Duration.Quarter, Octave.C2)).Should().Be(Interval.MinorThirteenth);
		note.IntervalTo(new Note(Pitch.A, Duration.Quarter, Octave.C2)).Should().Be(Interval.MajorThirteenth);
	}

	[Fact]
	public void MeasureIntervalsBetweenCShapAndAllOtherNotes()
	{
		var note = new Note(Pitch.CSharp, Duration.Quarter, Octave.C1);

		note.IntervalTo(new Note(Pitch.D, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSecond);
		note.IntervalTo(new Note(Pitch.DSharp, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSecond);
		note.IntervalTo(new Note(Pitch.E, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorThird);
		note.IntervalTo(new Note(Pitch.F, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorThird);
		note.IntervalTo(new Note(Pitch.FSharp, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFourth);
		note.IntervalTo(new Note(Pitch.G, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFourth);
		note.IntervalTo(new Note(Pitch.GSharp, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFifth);
		note.IntervalTo(new Note(Pitch.A, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFifth);
		// note.IntervalTo(new Note(Pitch.BFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSixth);
		// note.IntervalTo(new Note(Pitch.B, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSixth);
		note.IntervalTo(new Note(Pitch.B, Duration.Quarter, Octave.C2)).Should().Be(Interval.MinorSeventh);
		note.IntervalTo(new Note(Pitch.C, Duration.Quarter, Octave.C2)).Should().Be(Interval.MajorSeventh);
		note.IntervalTo(new Note(Pitch.CSharp, Duration.Quarter, Octave.C2)).Should().Be(Interval.PerfectOctave);
		note.IntervalTo(new Note(Pitch.D, Duration.Quarter, Octave.C2)).Should().Be(Interval.MinorNinth);
		note.IntervalTo(new Note(Pitch.DSharp, Duration.Quarter, Octave.C2)).Should().Be(Interval.MajorNinth);
		note.IntervalTo(new Note(Pitch.FSharp, Duration.Quarter, Octave.C2)).Should().Be(Interval.PerfectEleventh);
		note.IntervalTo(new Note(Pitch.G, Duration.Quarter, Octave.C2)).Should().Be(Interval.AugmentedEleventh);
		// note.IntervalTo(new Note(Pitch.A, Duration.Quarter, Octave.C2)).Should().Be(Interval.MinorThirteenth);
		// note.IntervalTo(new Note(Pitch.B, Duration.Quarter, Octave.C2)).Should().Be(Interval.MajorThirteenth);
	}

	[Fact]
	public void MeasureIntervalsBetweenDFlatAndAllOtherNotes()
	{
		var note = new Note(Pitch.DFlat, Duration.Quarter, Octave.C1);

		// note.IntervalTo(new Note(Pitch.EFlat.SamePitchFlat(), Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSecond);
		note.IntervalTo(new Note(Pitch.EFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSecond);
		note.IntervalTo(new Note(Pitch.FFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorThird);
		note.IntervalTo(new Note(Pitch.F, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorThird);
		note.IntervalTo(new Note(Pitch.GFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFourth);
		note.IntervalTo(new Note(Pitch.G, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFourth);
		note.IntervalTo(new Note(Pitch.AFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.PerfectFifth);
		note.IntervalTo(new Note(Pitch.A, Duration.Quarter, Octave.C1)).Should().Be(Interval.AugmentedFifth);
		// note.IntervalTo(new Note(Pitch.BFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSixth);
		// note.IntervalTo(new Note(Pitch.B, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSixth);
		// note.IntervalTo(new Note(Pitch.CFlat, Duration.Quarter, Octave.C1)).Should().Be(Interval.MinorSeventh);
		note.IntervalTo(new Note(Pitch.C, Duration.Quarter, Octave.C1)).Should().Be(Interval.MajorSeventh);
		note.IntervalTo(new Note(Pitch.DFlat, Duration.Quarter, Octave.C2)).Should().Be(Interval.PerfectOctave);
	}
}
