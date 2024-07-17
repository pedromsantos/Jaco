using FluentAssertions;
using Jaco;

namespace JacoTests;

public class BeatsPerMinuteShould
{
	[Fact]
	public void Test120BPMQuarterNoteSeconds()
	{
		var bpm = new BeatsPerMinute(120);
		bpm.Seconds().Should().Be(0.5);
	}

	[Fact]
	public void Test120BPMQuarterNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(120);
		var ms = bpm.MilliSeconds();

		ms.Should().Be(500);
	}

	[Fact]
	public void Test120BPMMeasureOf4BeatsMilliseconds()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(2000, bpm.MilliSeconds(4));
	}

	[Fact]
	public void Test120BPMWholeNoteSeconds()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(2, bpm.SecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test120BPMWholeNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(2000, bpm.MilliSecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test120BPMHalfNoteSeconds()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(1, bpm.SecondsFor(Duration.Half));
	}

	[Fact]
	public void Test120BPMHalfNoteMillisecondsHalfNotes()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(1000, bpm.MilliSecondsFor(Duration.Half));
	}

	[Fact]
	public void Test120BPMQuarterNoteMillisecondsQuarterNotes()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(500, bpm.MilliSecondsFor(Duration.Quarter));
	}

	[Fact]
	public void Test120BPMEighthNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(120);
		Assert.Equal(250, bpm.MilliSecondsFor(Duration.Eighth));
	}

	[Fact]
	public void Test60BPMQuarterNoteSeconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(1, bpm.Seconds());
	}

	[Fact]
	public void Test60BPMQuarterNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(1000, bpm.MilliSeconds());
	}

	[Fact]
	public void Test60BPMWholeNoteSeconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(4, bpm.SecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test60BPMWholeNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(4000, bpm.MilliSecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test60BPMHalfNoteSeconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(2, bpm.SecondsFor(Duration.Half));
	}

	[Fact]
	public void Test60BPMHalfNoteMillisecondsHalfNotes()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(2000, bpm.MilliSecondsFor(Duration.Half));
	}

	[Fact]
	public void Test60BPMQuarterNoteMillisecondsQuarterNotes()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(1000, bpm.MilliSecondsFor(Duration.Quarter));
	}

	[Fact]
	public void Test60BPMEighthNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(500, bpm.MilliSecondsFor(Duration.Eighth));
	}

	[Fact]
	public void Test60BPMSixteenthNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(60);
		Assert.Equal(250, bpm.MilliSecondsFor(Duration.Sixteenth));
	}

	[Fact]
	public void Test60BPM8thNoteSeconds()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(1, bpm.Seconds());
	}

	[Fact]
	public void Test60BPM8thNoteMilliseconds()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		bpm.MilliSeconds().Should().Be(1000);
	}

	[Fact]
	public void Test60BPMWholeNoteSecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(8, bpm.SecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test60BPMWholeNoteMillisecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(8000, bpm.MilliSecondsFor(Duration.Whole));
	}

	[Fact]
	public void Test60BPMHalfNoteSecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(4, bpm.SecondsFor(Duration.Half));
	}

	[Fact]
	public void Test60BPMHalfNoteMillisecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(4000, bpm.MilliSecondsFor(Duration.Half));
	}

	[Fact]
	public void Test60BPMQuarterNoteMillisecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(2000, bpm.MilliSecondsFor(Duration.Quarter));
	}

	[Fact]
	public void Test60BPMEighthNoteMillisecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(1000, bpm.MilliSecondsFor(Duration.Eighth));
	}

	[Fact]
	public void Test60BPMSixteenthNoteMillisecondsWith8thNote()
	{
		var bpm = new BeatsPerMinute(60, Duration.Eighth);
		Assert.Equal(500, bpm.MilliSecondsFor(Duration.Sixteenth));
	}
}