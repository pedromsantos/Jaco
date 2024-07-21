using FluentAssertions;
using Jaco;

namespace JacoTests;

public class SimpleTimeSignatureShould
{
	[Fact]
	public void TestBeatDurationInMilliseconds()
	{
		var timeSignature44 = new SimpleTimeSignature(4, Duration.Quarter, 60);
		var timeSignature34 = new SimpleTimeSignature(3, Duration.Quarter, 60);
		var timeSignature24 = new SimpleTimeSignature(2, Duration.Quarter, 60);

		Assert.Equal(1000, timeSignature44.BeatDurationMilliseconds);
		Assert.Equal(1000, timeSignature34.BeatDurationMilliseconds);
		Assert.Equal(1000, timeSignature24.BeatDurationMilliseconds);
	}

	[Fact]
	public void TestBeatDurationInTicks()
	{
		var timeSignature44 = new SimpleTimeSignature(4, Duration.Quarter, 60);
		var timeSignature34 = new SimpleTimeSignature(3, Duration.Quarter, 60);
		var timeSignature24 = new SimpleTimeSignature(2, Duration.Quarter, 60);

		Assert.Equal(480, timeSignature44.TicksPerSecond);
		Assert.Equal(480, timeSignature34.TicksPerSecond);
		Assert.Equal(480, timeSignature24.TicksPerSecond);

		Assert.Equal(Duration.Quarter.Tick, timeSignature44.BeatDurationTicks);
		Assert.Equal(Duration.Quarter.Tick, timeSignature34.BeatDurationTicks);
		Assert.Equal(Duration.Quarter.Tick, timeSignature24.BeatDurationTicks);
	}

	[Fact]
	public void NoteDurationsInMilliseconds()
	{
		var timeSignature = new SimpleTimeSignature(4, Duration.Quarter, 60);

		var wholeNoteExpectedDuration = 4000;

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
		var timeSignature = new SimpleTimeSignature(4, Duration.Quarter, 60);

		var expectedDuration = 4000;

		timeSignature.MillisecondsPerCycle.Should().Be(expectedDuration);
	}

	[Fact]
	public void MeasureDurationsInTicks()
	{
		var timeSignature = new SimpleTimeSignature(4, Duration.Quarter, 60);

		Assert.Equal(1920, timeSignature.TicksPerCycle);
	}

	[Fact]
	public void NumberOfNotesToFillCycleIn44()
	{
		var timeSignature = new SimpleTimeSignature(4, Duration.Quarter, 60);

		Assert.Equal(1, timeSignature.ToFillCycle(Duration.Whole));
		Assert.Equal(2, timeSignature.ToFillCycle(Duration.Half));
		Assert.Equal(4, timeSignature.ToFillCycle(Duration.Quarter));
		Assert.Equal(8, timeSignature.ToFillCycle(Duration.Eighth));
		Assert.Equal(16, timeSignature.ToFillCycle(Duration.Sixteenth));
		Assert.Equal(32, timeSignature.ToFillCycle(Duration.ThirtySecond));
		Assert.Equal(64, timeSignature.ToFillCycle(Duration.SixtyFourth));
	}
}
