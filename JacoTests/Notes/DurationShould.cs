using FluentAssertions;
using Jaco.Notes;

namespace JacoTests.Note;

public class DurationShould
{
	[Fact]
	public void Measure()
	{
		Duration.Whole.Tick.Should().Be(1920);
		Duration.DoubleDottedHalf.Tick.Should().Be(1680);
		Duration.DottedHalf.Tick.Should().Be(1440);
		Duration.TripletWhole.Tick.Should().Be(1280);
		Duration.Half.Tick.Should().Be(960);
		Duration.DoubleDottedQuarter.Tick.Should().Be(840);
		Duration.DottedQuarter.Tick.Should().Be(720);
		Duration.TripletHalf.Tick.Should().Be(640);
		Duration.Quarter.Tick.Should().Be(480);
		Duration.DoubleDottedEighth.Tick.Should().Be(420);
		Duration.DottedEighth.Tick.Should().Be(360);
		Duration.TripletQuarter.Tick.Should().Be(320);
		Duration.Eighth.Tick.Should().Be(240);
		Duration.DoubleDottedSixteenth.Tick.Should().Be(210);
		Duration.DottedSixteenth.Tick.Should().Be(180);
		Duration.TripletEighth.Tick.Should().Be(160);
		Duration.Sixteenth.Tick.Should().Be(120);
		Duration.DoubleDottedThirtySecond.Tick.Should().Be(105);
		Duration.DottedThirtySecond.Tick.Should().Be(90);
		Duration.TripletSixteenth.Tick.Should().Be(80);
		Duration.ThirtySecond.Tick.Should().Be(60);
		Duration.DottedSixtyFourth.Tick.Should().Be(45);
		Duration.SixtyFourth.Tick.Should().Be(30);
	}
}
