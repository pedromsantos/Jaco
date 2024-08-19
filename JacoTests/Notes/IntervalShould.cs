using Jaco.Notes;

namespace JacoTests;

using Xunit;
using Jaco;
using FluentAssertions;
using NSubstitute.Routing.AutoValues;

public class IntervalShould
{
	[Fact]
	public void IntervalsStringRepresentationIsTheIntervalAbreviature()
	{
		Interval.Unison.ToString().Should().Be("U");
		Interval.DiminishedUnison.ToString().Should().Be("d1");
		Interval.AugmentedUnison.ToString().Should().Be("A1");
		Interval.MinorSecond.ToString().Should().Be("m2");
		Interval.MajorSecond.ToString().Should().Be("M2");
		Interval.AugmentedSecond.ToString().Should().Be("A2");
		Interval.MinorThird.ToString().Should().Be("m3");
		Interval.MajorThird.ToString().Should().Be("M3");
		Interval.PerfectFourth.ToString().Should().Be("P4");
		Interval.AugmentedFourth.ToString().Should().Be("A4");
		Interval.Tritone.ToString().Should().Be("d5");
		Interval.DiminishedFifth.ToString().Should().Be("d5");
		Interval.PerfectFifth.ToString().Should().Be("P5");
		Interval.MinorSixth.ToString().Should().Be("m6");
		Interval.MajorSixth.ToString().Should().Be("M6");
		Interval.DiminishedSeventh.ToString().Should().Be("d7");
		Interval.MinorSeventh.ToString().Should().Be("m7");
		Interval.MajorSeventh.ToString().Should().Be("M7");
		Interval.PerfectOctave.ToString().Should().Be("PO");
		Interval.MinorNinth.ToString().Should().Be("m9");
		Interval.MajorNinth.ToString().Should().Be("M9");
		Interval.PerfectEleventh.ToString().Should().Be("P11");
		Interval.AugmentedEleventh.ToString().Should().Be("A11");
		Interval.MinorThirteenth.ToString().Should().Be("m13");
		Interval.MajorThirteenth.ToString().Should().Be("M13");
	}

	[Fact]
	public void IntervalsWithSameSemitoneDistaneAreEqual()
	{
		Interval.Unison.HaveSameDistance(Interval.DiminishedUnison).Should().BeTrue();
		Interval.MinorSecond.HaveSameDistance(Interval.AugmentedUnison).Should().BeTrue();
		Interval.MinorThird.HaveSameDistance(Interval.AugmentedSecond).Should().BeTrue();
		Interval.AugmentedFourth.HaveSameDistance(Interval.DiminishedFifth).Should().BeTrue();
		Interval.DiminishedFifth.HaveSameDistance(Interval.Tritone).Should().BeTrue();
		Interval.MinorSixth.HaveSameDistance(Interval.AugmentedFifth).Should().BeTrue();
	}

	[Fact]
	public void IntervalInversionOfInversionShouldBeSameInterval()
	{
		Interval.Unison.Invert().Invert().Should().Be(Interval.Unison);
		Interval.MinorSecond.Invert().Invert().Should().Be(Interval.MinorSecond);
		Interval.MajorSecond.Invert().Invert().Should().Be(Interval.MajorSecond);
		Interval.MinorThird.Invert().Invert().Should().Be(Interval.MinorThird);
		Interval.MajorThird.Invert().Invert().Should().Be(Interval.MajorThird);
		Interval.PerfectFourth.Invert().Invert().Should().Be(Interval.PerfectFourth);
		Interval.PerfectFifth.Invert().Invert().Should().Be(Interval.PerfectFifth);
		Interval.MinorSixth.Invert().Invert().Should().Be(Interval.MinorSixth);
		Interval.MajorSixth.Invert().Invert().Should().Be(Interval.MajorSixth);
		Interval.MinorSeventh.Invert().Invert().Should().Be(Interval.MinorSeventh);
		Interval.MajorSeventh.Invert().Invert().Should().Be(Interval.MajorSeventh);
		Interval.PerfectOctave.Invert().Invert().Should().Be(Interval.PerfectOctave);
	}

	[Fact]
	public void IntervalInversionOfInversionShouldBeSameIntervalOneOctaveBellowWhenIntervalAboveOctave()
	{
		Interval.MinorNinth.Invert().Invert().Should().Be(Interval.MinorSecond);
		Interval.MajorNinth.Invert().Invert().Should().Be(Interval.MajorSecond);
		Interval.PerfectEleventh.Invert().Invert().Should().Be(Interval.PerfectFourth);
		Interval.MinorThirteenth.Invert().Invert().Should().Be(Interval.MinorSixth);
		Interval.MajorThirteenth.Invert().Invert().Should().Be(Interval.MajorSixth);
	}

	[Fact]
	public void RaisingAndLoweringOctaveShouldBeSameInterval()
	{
		Interval.Unison.RaiseOctave().OctaveDown().Should().Be(Interval.Unison);
		Interval.MinorSecond.RaiseOctave().OctaveDown().Should().Be(Interval.MinorSecond);
		Interval.MajorSecond.RaiseOctave().OctaveDown().Should().Be(Interval.MajorSecond);
		Interval.MinorThird.RaiseOctave().OctaveDown().Should().Be(Interval.MinorThird);
		Interval.MajorThird.RaiseOctave().OctaveDown().Should().Be(Interval.MajorThird);
		Interval.PerfectFourth.RaiseOctave().OctaveDown().Should().Be(Interval.PerfectFourth);
		Interval.PerfectFifth.RaiseOctave().OctaveDown().Should().Be(Interval.PerfectFifth);
		Interval.MinorSixth.RaiseOctave().OctaveDown().Should().Be(Interval.MinorSixth);
		Interval.MajorSixth.RaiseOctave().OctaveDown().Should().Be(Interval.MajorSixth);
		Interval.MinorSeventh.RaiseOctave().OctaveDown().Should().Be(Interval.MinorSeventh);
		Interval.MajorSeventh.RaiseOctave().OctaveDown().Should().Be(Interval.MajorSeventh);
	}
	[Fact]

	public void RaisingAndLoweringOctaveShouldBeIntervalOctaveDown()
	{
		Interval.PerfectOctave.RaiseOctave().OctaveDown().Should().Be(Interval.Unison);
		Interval.MinorNinth.RaiseOctave().OctaveDown().Should().Be(Interval.MinorSecond);
		Interval.MajorNinth.RaiseOctave().OctaveDown().Should().Be(Interval.MajorSecond);
		Interval.PerfectEleventh.RaiseOctave().OctaveDown().Should().Be(Interval.PerfectFourth);
		Interval.MinorThirteenth.RaiseOctave().OctaveDown().Should().Be(Interval.MinorSixth);
		Interval.MajorThirteenth.RaiseOctave().OctaveDown().Should().Be(Interval.MajorSixth);
	}
}
