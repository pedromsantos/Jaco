using FluentAssertions;
using Jaco.Notes;
using Jaco.Time;

namespace JacoTests.Time;

public class BeatsPerMinuteShould
{
	[Theory]
	[InlineData(60, 4)]
	[InlineData(90, 2.6666666666666665)]
	[InlineData(120, 2)]
	[InlineData(140, 1.7142857142857142)]
	[InlineData(240, 1)]
	public void CalculateNoteLengthInSecondsAndMilliSecondsWhenBpmIsInQuarterNotes(int bpm, double expected)
	{
		var beatsPerMinute = new BeatsPerMinute(bpm, Duration.Quarter);

		beatsPerMinute.SecondsFor(Duration.Whole).Should().BeApproximately(expected, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Whole).Should().BeApproximately(expected * 1000, 1);
		beatsPerMinute.SecondsFor(Duration.Half).Should().BeApproximately(expected / 2, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Half).Should().BeApproximately((expected / 2) * 1000, 1);
		beatsPerMinute.SecondsFor(Duration.Quarter).Should().BeApproximately(expected / 4, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Quarter).Should().BeApproximately((expected / 4) * 1000, 1);
		beatsPerMinute.SecondsFor(Duration.Eighth).Should().BeApproximately(expected / 8, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Eighth).Should().BeApproximately((expected / 8) * 1000, 1);
		beatsPerMinute.SecondsFor(Duration.Sixteenth).Should().BeApproximately(expected / 16, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Sixteenth).Should().BeApproximately((expected / 16) * 1000, 1);
	}

	[Theory]
	[InlineData(60, 1)]
	[InlineData(90, 0.6666666666666666)]
	[InlineData(120, 0.5)]
	[InlineData(140, 0.42857142857142855)]
	[InlineData(240, 0.25)]
	public void CalculateNoteLengthInSecondsAndMilliSecondsWhenBpmIsInEigthNotes(int bpm, double expected)
	{
		var beatsPerMinute = new BeatsPerMinute(bpm, Duration.Eighth);

		beatsPerMinute.Seconds().Should().BeApproximately(expected, 1);
		beatsPerMinute.MilliSeconds().Should().BeApproximately(expected * 1000, 1);

		beatsPerMinute.MilliSecondsFor(Duration.Sixteenth).Should().BeApproximately((expected / 2) * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Eighth).Should().BeApproximately(expected * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Quarter).Should().BeApproximately(expected * 2 * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Half).Should().BeApproximately(expected * 4 * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Whole).Should().BeApproximately(expected * 8 * 1000, 1);
	}

	[Theory]
	[InlineData(60, 1)]
	[InlineData(90, 0.6666666666666666)]
	[InlineData(120, 0.5)]
	[InlineData(140, 0.42857142857142855)]
	[InlineData(240, 0.25)]
	public void CalculateNoteLengthInSecondsAndMilliSecondsWhenBpmIsInSixteenthNotes(int bpm, double expected)
	{
		var beatsPerMinute = new BeatsPerMinute(bpm, Duration.Sixteenth);

		beatsPerMinute.Seconds().Should().BeApproximately(expected, 1);
		beatsPerMinute.MilliSeconds().Should().BeApproximately(expected * 1000, 1);

		beatsPerMinute.MilliSecondsFor(Duration.Sixteenth).Should().BeApproximately(expected * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Eighth).Should().BeApproximately(expected * 2 * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Quarter).Should().BeApproximately(expected * 4 * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Half).Should().BeApproximately(expected * 8 * 1000, 1);
		beatsPerMinute.MilliSecondsFor(Duration.Whole).Should().BeApproximately(expected * 16 * 1000, 1);
	}
}