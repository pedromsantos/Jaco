using Jaco;

namespace JacoTests;

public class CompoundTimeSignatureTests
{
	[Fact]
	public void PulsesMustBeDivisibleBy3()
	{
		Assert.Throws<ArgumentException>(() => new CompoundTimeSignature(7, Duration.Eighth, 60));
	}

	[Fact]
	public void TestBeatDurationInMilliseconds()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1000, timeSignature.BeatDurationMilliseconds);
		Assert.Equal(1000, timeSignature.BeatDurationMilliseconds);
		Assert.Equal(1000, timeSignature.BeatDurationMilliseconds);
	}

	[Fact]
	public void TestBeatDurationInTicks()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(480, timeSignature.TicksPerSecond);

		Assert.Equal(Duration.Eighth.Tick, timeSignature.BeatDurationTicks);
		Assert.Equal(Duration.Eighth.Tick, timeSignature.BeatDurationTicks);
		Assert.Equal(Duration.Eighth.Tick, timeSignature.BeatDurationTicks);
	}

	[Fact]
	public void NoteDurationsInMilliseconds()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		var wholeNoteExpectedDuration = 8000;

		Assert.Equal(wholeNoteExpectedDuration, timeSignature.MillisecondsFor(Duration.Whole));
		Assert.Equal(wholeNoteExpectedDuration / (double)2, timeSignature.MillisecondsFor(Duration.Half));
		Assert.Equal(wholeNoteExpectedDuration / (double)4, timeSignature.MillisecondsFor(Duration.Quarter));
		Assert.Equal(wholeNoteExpectedDuration / (double)8, timeSignature.MillisecondsFor(Duration.Eighth));
		Assert.Equal(wholeNoteExpectedDuration / (double)16, timeSignature.MillisecondsFor(Duration.Sixteenth));
		Assert.Equal(wholeNoteExpectedDuration / (double)32, timeSignature.MillisecondsFor(Duration.ThirtySecond));
		Assert.Equal(wholeNoteExpectedDuration / (double)64, timeSignature.MillisecondsFor(Duration.SixtyFourth));
	}

	[Fact]
	public void MeasureDurationsInMilliseconds()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		var expectedDuration = 2000;

		Assert.Equal(expectedDuration, timeSignature.MillisecondsPerMeasure);
	}

	[Fact]
	public void MeasureDurationsInTicks()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1440, timeSignature.TicksPerMeasure);
	}

	[Fact]
	public void NumberOfNotesToFillMeasureIn68()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1, timeSignature.ToFillMeasure(Duration.DottedHalf));
		Assert.Equal(2, timeSignature.ToFillMeasure(Duration.DottedQuarter));
		Assert.Equal(3, timeSignature.ToFillMeasure(Duration.Quarter));
		Assert.Equal(6, timeSignature.ToFillMeasure(Duration.Eighth));
		Assert.Equal(12, timeSignature.ToFillMeasure(Duration.Sixteenth));
		Assert.Equal(24, timeSignature.ToFillMeasure(Duration.ThirtySecond));
		Assert.Equal(48, timeSignature.ToFillMeasure(Duration.SixtyFourth));
	}
}
