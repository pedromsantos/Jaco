using Jaco;

namespace JacoTests;

public class CompoundTimeSignatureShould
{
	[Fact]
	public void PulsesMustBeDivisibleBy3()
	{
		Assert.Throws<ArgumentException>(() => new CompoundTimeSignature(7, Duration.Eighth, 60));
	}

	[Fact]
	public void CalculateBeatDurationInMillisecondsAndTicks()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1000, timeSignature.BeatDurationMilliseconds);
		Assert.Equal(480, timeSignature.TicksPerSecond);
		Assert.Equal(Duration.Eighth.Tick, timeSignature.BeatDurationTicks);
	}

	[Fact]
	public void CalculateNoteDurationsInMilliseconds()
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
	public void CalculateMeasureDurationsInMilliseconds()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		var expectedDuration = 2000;

		Assert.Equal(expectedDuration, timeSignature.MillisecondsPerCycle);
	}

	[Fact]
	public void MeasureDurationsInTicks()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1440, timeSignature.TicksPerCycle);
	}

	[Fact]
	public void NumberOfNotesToFillCycleIn68()
	{
		var timeSignature = new CompoundTimeSignature(6, Duration.Eighth, 60);

		Assert.Equal(1, timeSignature.ToFillCycle(Duration.DottedHalf));
		Assert.Equal(2, timeSignature.ToFillCycle(Duration.DottedQuarter));
		Assert.Equal(3, timeSignature.ToFillCycle(Duration.Quarter));
		Assert.Equal(6, timeSignature.ToFillCycle(Duration.Eighth));
		Assert.Equal(12, timeSignature.ToFillCycle(Duration.Sixteenth));
		Assert.Equal(24, timeSignature.ToFillCycle(Duration.ThirtySecond));
		Assert.Equal(48, timeSignature.ToFillCycle(Duration.SixtyFourth));
	}
}
