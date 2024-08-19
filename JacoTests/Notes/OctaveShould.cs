using Jaco.Notes;

namespace JacoTests;

using FluentAssertions;
using Xunit;
using Jaco;

public class OctaveShould
{
	[Fact]
	public void GoUpInFrequency()
	{
		Octave.C0.Up().Up().Up().Up().Up().Up().Up().Up().Up().Should().Be(Octave.C8);
	}

	[Fact]
	public void GoDownInFrequency()
	{
		Octave.C8.Down().Down().Down().Down().Down().Down().Down().Down().Down().Should().Be(Octave.C0);
	}

	[Fact]
	public void CompareOctaves()
	{
		Octave.C0.HigherThan(Octave.C1).Should().BeFalse();
		Octave.C1.HigherThan(Octave.C0).Should().BeTrue();
		Octave.C1.HigherThan(Octave.C2).Should().BeFalse();
		Octave.C2.HigherThan(Octave.C1).Should().BeTrue();
		Octave.C2.HigherThan(Octave.C3).Should().BeFalse();
		Octave.C3.HigherThan(Octave.C2).Should().BeTrue();
		Octave.C3.HigherThan(Octave.C4).Should().BeFalse();
		Octave.C4.HigherThan(Octave.C3).Should().BeTrue();
		Octave.C4.HigherThan(Octave.C5).Should().BeFalse();
		Octave.C5.HigherThan(Octave.C4).Should().BeTrue();
		Octave.C5.HigherThan(Octave.C6).Should().BeFalse();
		Octave.C6.HigherThan(Octave.C5).Should().BeTrue();
		Octave.C6.HigherThan(Octave.C7).Should().BeFalse();
		Octave.C7.HigherThan(Octave.C6).Should().BeTrue();
		Octave.C7.HigherThan(Octave.C8).Should().BeFalse();
		Octave.C8.HigherThan(Octave.C7).Should().BeTrue();

		Octave.C0.LowerThan(Octave.C1).Should().BeTrue();
		Octave.C1.LowerThan(Octave.C0).Should().BeFalse();
		Octave.C1.LowerThan(Octave.C2).Should().BeTrue();
		Octave.C2.LowerThan(Octave.C1).Should().BeFalse();
		Octave.C2.LowerThan(Octave.C3).Should().BeTrue();
		Octave.C3.LowerThan(Octave.C2).Should().BeFalse();
		Octave.C3.LowerThan(Octave.C4).Should().BeTrue();
		Octave.C4.LowerThan(Octave.C3).Should().BeFalse();
		Octave.C4.LowerThan(Octave.C5).Should().BeTrue();
		Octave.C5.LowerThan(Octave.C4).Should().BeFalse();
		Octave.C5.LowerThan(Octave.C6).Should().BeTrue();
		Octave.C6.LowerThan(Octave.C5).Should().BeFalse();
		Octave.C6.LowerThan(Octave.C7).Should().BeTrue();
		Octave.C7.LowerThan(Octave.C6).Should().BeFalse();
		Octave.C7.LowerThan(Octave.C8).Should().BeTrue();
		Octave.C8.LowerThan(Octave.C7).Should().BeFalse();
	}
}