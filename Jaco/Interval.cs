namespace Jaco;

public enum IntervalQuality
{
	Perfect,
	Major,
	Minor,
	Augmented,
	Diminished
}

public class Interval
{
	private readonly string name;
	private readonly string abbreviation;
	private readonly int semitones;
	private readonly IntervalQuality quality;
	private readonly Func<Interval> invert;
	private readonly Func<Interval> octaveUp;
	private readonly Func<Interval> octaveDown;

	public Interval(string name, string abbreviation, int semitones, IntervalQuality quality, Func<Interval> invert, Func<Interval> octaveUp, Func<Interval> octaveDown)
	{
		this.name = name;
		this.abbreviation = abbreviation;
		this.semitones = semitones;
		this.quality = quality;
		this.invert = invert;
		this.octaveUp = octaveUp;
		this.octaveDown = octaveDown;
	}

	public bool HaveSameDistance(Interval interval)
	{
		return semitones == interval.semitones;
	}

	public Interval Invert()
	{
		return invert();
	}

	public Interval OctaveUp()
	{
		return octaveUp();
	}

	public Interval OctaveDown()
	{
		return octaveDown();
	}

	public static readonly Interval Unison = new(
		"Unison",
			"U",
			0,
			IntervalQuality.Perfect,
			() => PerfectOctave!,
			() => PerfectOctave!,
			() => Unison!
		);

	public static readonly Interval DiminishedUnison = new(
		"Diminished Unison",
		"d1",
		0,
		IntervalQuality.Diminished,
		() => AugmentedUnison!,
		() => DiminishedUnison!,
		() => DiminishedUnison!
	);

	public static readonly Interval AugmentedUnison = new(
		"Augmented Unison",
		"A1",
		1,
		IntervalQuality.Augmented,
		() => DiminishedUnison,
		() => AugmentedUnison!,
		() => AugmentedUnison!
	);

	public static readonly Interval MinorSecond = new(
		"Minor Second",
		"m2",
		1,
		IntervalQuality.Minor,
		() => MajorSeventh!,
		() => MinorNinth!,
		() => MinorSecond!
	);

	public static readonly Interval MajorSecond = new(
		"Major Second",
		"M2",
		2,
		IntervalQuality.Major,
		() => MinorSeventh!,
		() => MajorNinth!,
		() => MajorSecond!
	);

	public static readonly Interval AugmentedSecond = new(
		"Augmented Second",
		"A2",
		3,
		IntervalQuality.Augmented,
		() => DiminishedSeventh!,
		() => AugmentedNinth!,
		() => AugmentedSecond!
	);

	public static readonly Interval MinorThird = new(
		"Minor Third",
		"m3",
		3,
		IntervalQuality.Minor,
		() => MajorSixth!,
		() => MinorThird!,
		() => MinorThird!
	);

	public static readonly Interval MajorThird = new(
		"Major Third",
		"M3",
		4,
		IntervalQuality.Major,
		() => MinorSixth!,
		() => MajorThird!,
		() => MajorThird!
	);

	public static readonly Interval PerfectFourth = new(
		"Perfect Fourth",
		"P4",
		5,
		IntervalQuality.Perfect,
		() => PerfectFifth!,
		() => PerfectEleventh!,
		() => PerfectFourth!
	);

	public static readonly Interval AugmentedFourth = new(
		"Augmented Fourth",
		"A4",
		6,
		IntervalQuality.Augmented,
		() => DiminishedFifth!,
		() => AugmentedEleventh!,
		() => AugmentedFourth!
	);

	public static readonly Interval DiminishedFifth = new(
		"Diminished Fifth",
		"d5",
		6,
		IntervalQuality.Diminished,
		() => AugmentedFourth,
		() => DiminishedFifth!,
		() => DiminishedFifth!
	);

	public static readonly Interval Tritone = DiminishedFifth;

	public static readonly Interval PerfectFifth = new(
		"Perfect Fifth",
		"P5",
		7,
		IntervalQuality.Perfect,
		() => PerfectFourth,
		() => PerfectFifth!,
		() => PerfectFifth!
	);

	public static readonly Interval AugmentedFifth = new(
		"Augmented Fifth",
		"A5",
		8,
		IntervalQuality.Augmented,
		() => AugmentedFourth,
		() => AugmentedFifth!,
		() => AugmentedFifth!
	);

	public static readonly Interval MinorSixth = new(
		"Minor Sixth",
		"m6",
		8,
		IntervalQuality.Minor,
		() => MajorThird,
		() => MinorThirteenth!,
		() => MinorSixth!
	);

	public static readonly Interval MajorSixth = new(
		"Major Sixth",
		"M6",
		9,
		IntervalQuality.Major,
		() => MinorThird,
		() => MajorThirteenth!,
		() => MajorSixth!
	);

	public static readonly Interval DiminishedSeventh = new(
		"Diminished Seventh",
		"d7",
		9,
		IntervalQuality.Diminished,
		() => AugmentedSecond,
		() => DiminishedSeventh!,
		() => DiminishedSeventh!
	);

	public static readonly Interval MinorSeventh = new(
		"Minor Seventh",
		"m7",
		10,
		IntervalQuality.Minor,
		() => MajorSecond,
		() => MinorSeventh!,
		() => MinorSeventh!
	);

	public static readonly Interval MajorSeventh = new(
		"Major Seventh",
		"M7",
		11,
		IntervalQuality.Major,
		() => MinorSecond,
		() => MajorSeventh!,
		() => MajorSeventh!
	);

	public static readonly Interval PerfectOctave = new(
		"Perfect Octave",
		"PO",
		12,
		IntervalQuality.Perfect,
		() => Unison,
		() => PerfectOctave!,
		() => Unison!
	);

	public static readonly Interval MinorNinth = new(
		"Minor Ninth",
		"m9",
		13,
		IntervalQuality.Minor,
		() => MajorSeventh,
		() => MinorNinth!,
		() => MinorSecond!
	);

	public static readonly Interval MajorNinth = new(
		"Major Ninth",
		"M9",
		14,
		IntervalQuality.Major,
		() => MinorSeventh,
		() => MajorNinth!,
		() => MajorSecond!
	);

	public static readonly Interval AugmentedNinth = new(
		"Augmented Ninth",
		"A9",
		15,
		IntervalQuality.Augmented,
		() => DiminishedUnison,
		() => AugmentedNinth!,
		() => AugmentedSecond!
	);

	public static readonly Interval PerfectEleventh = new(
		"Perfect Eleventh",
		"P11",
		17,
		IntervalQuality.Perfect,
		() => PerfectFifth,
		() => PerfectEleventh!,
		() => PerfectFourth!
	);

	public static readonly Interval AugmentedEleventh = new(
		"Augmented Eleventh",
		"A11",
		18,
		IntervalQuality.Augmented,
		() => DiminishedFifth,
		() => AugmentedEleventh!,
		() => AugmentedFourth!
	);

	public static readonly Interval MinorThirteenth = new(
		"Minor Thirteenth",
		"m13",
		20,
		IntervalQuality.Minor,
		() => MajorThird,
		() => MinorThirteenth!,
		() => MinorSixth!
	);

	public static readonly Interval MajorThirteenth = new(
		"Major Thirteenth",
		"M13",
		21,
		IntervalQuality.Major,
		() => MinorThird,
		() => MajorThirteenth!,
		() => MajorSixth!
	);

	public override bool Equals(object? obj)
	{
		if (obj is Interval interval)
		{
			return semitones == interval.semitones && quality == interval.quality && name == interval.name && abbreviation == interval.abbreviation;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return semitones + quality.GetHashCode() + name.GetHashCode() + abbreviation.GetHashCode();
	}

	public override string ToString()
	{
		return abbreviation;
	}
}
