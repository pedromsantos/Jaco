using System.Reflection.Metadata.Ecma335;

namespace Jaco;

internal class IntervalsToPitches
{
	private readonly Dictionary<Interval, Pitch> intervalsToPitchs = new Dictionary<Interval, Pitch>();

	internal IntervalsToPitches()
	{
	}

	internal IntervalsToPitches(IEnumerable<KeyValuePair<Interval, Pitch>> intervalsToPitchs)
	{
		foreach (var keyValue in intervalsToPitchs)
		{
			this.intervalsToPitchs.Add(keyValue.Key, keyValue.Value);
		}
	}

	public IntervalsToPitches Add(Interval interval, Pitch pitch)
	{
		intervalsToPitchs.Add(interval, pitch);
		return this;
	}

	public Pitch Transpose(Interval interval)
	{
		return intervalsToPitchs[interval];
	}

	public Interval IntervalTo(Pitch pitch)
	{
		return intervalsToPitchs.First(x => x.Value == pitch).Key;
	}

	internal IntervalsToPitches Sharp()
	{
		return new IntervalsToPitches(this.intervalsToPitchs.Select((keyValue) => new KeyValuePair<Interval, Pitch>(keyValue.Key, keyValue.Value.Sharp())));
	}

	internal IntervalsToPitches Flat()
	{
		return new IntervalsToPitches(this.intervalsToPitchs.Select((keyValue) => new KeyValuePair<Interval, Pitch>(keyValue.Key, keyValue.Value.Flat())));
	}
}

public class Pitch
{
	private const int PITCHES = 12;

	private readonly string name;
	private readonly int value;
	private readonly int accidentals;
	private readonly Func<Pitch> sharp;
	private readonly Func<Pitch> flat;
	private readonly Func<Pitch> natural;
	private readonly Func<IntervalsToPitches> intervalsToPitchs;

	private Pitch(string name, int value, int accidentals, Func<Pitch> sharp, Func<Pitch> flat, Func<Pitch> natural, Func<IntervalsToPitches> intervalsToPitchs)
	{
		this.name = name;
		this.value = value;
		this.accidentals = accidentals;
		this.sharp = sharp;
		this.flat = flat;
		this.natural = natural;
		this.intervalsToPitchs = intervalsToPitchs;
	}

	public Pitch Sharp()
	{
		return sharp();
	}

	public Pitch Flat()
	{
		return flat();
	}

	public Pitch Natural()
	{
		return natural();
	}

	public int AbsoluteDistanceTo(Pitch to)
	{
		if (value <= to.value) return to.value - value;

		return PITCHES + (to.value - value);
	}

	public Pitch Transpose(Interval interval)
	{
		return intervalsToPitchs().Transpose(interval);
	}

	public static readonly Pitch CFlat = new("Cb",
																					0,
																					1,
																					() => C!,
																					() => B!,
																					() => C!,
																					() => C!.intervalsToPitchs().Flat());
	public static readonly Pitch C = new("C",
																			0,
																			0,
																			() => CSharp!,
																			() => B!,
																			() => C!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, C!)
																				.Add(Interval.MinorSecond, CSharp!)
																				.Add(Interval.MajorSecond, D!)
																				.Add(Interval.MinorThird, EFlat!)
																				.Add(Interval.MajorThird, E!)
																				.Add(Interval.PerfectFourth, F!)
																				.Add(Interval.AugmentedFourth, FSharp!)
																				.Add(Interval.DiminishedFifth, GFlat!)
																				.Add(Interval.PerfectFifth, G!)
																				.Add(Interval.AugmentedFifth, GSharp!)
																				.Add(Interval.MinorSixth, AFlat!)
																				.Add(Interval.MajorSixth, A!)
																				.Add(Interval.DiminishedSeventh, A!)
																				.Add(Interval.MinorSeventh, BFlat!)
																				.Add(Interval.MajorSeventh, B!)
																				.Add(Interval.PerfectOctave, C!)
																				.Add(Interval.MinorNinth, CSharp!)
																				.Add(Interval.MajorNinth, D!)
																				.Add(Interval.PerfectEleventh, F!)
																				.Add(Interval.AugmentedEleventh, FSharp!)
																				.Add(Interval.MinorThirteenth, AFlat!)
																				.Add(Interval.MajorThirteenth, A!));
	public static readonly Pitch CSharp = new("C#",
																					 1,
																					 1,
																					 () => D!,
																					 () => C,
																					 () => C,
																					 () => C!.intervalsToPitchs().Sharp());

	public static readonly Pitch DFlat = new("Db",
																					1,
																					1,
																					() => D!,
																					() => C,
																					() => D!,
																					() => D!.intervalsToPitchs().Flat());
	public static readonly Pitch D = new("D",
																			2,
																			0,
																			() => DSharp!,
																			() => DFlat,
																			() => D!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, D!)
																				.Add(Interval.MinorSecond, DSharp!)
																				.Add(Interval.MajorSecond, E!)
																				.Add(Interval.MinorThird, F!)
																				.Add(Interval.MajorThird, FSharp!)
																				.Add(Interval.PerfectFourth, G!)
																				.Add(Interval.AugmentedFourth, GSharp!)
																				.Add(Interval.DiminishedFifth, AFlat!)
																				.Add(Interval.PerfectFifth, A!)
																				.Add(Interval.AugmentedFifth, ASharp!)
																				.Add(Interval.MinorSixth, BFlat!)
																				.Add(Interval.MajorSixth, B!)
																				.Add(Interval.DiminishedSeventh, B!)
																				.Add(Interval.MinorSeventh, C!)
																				.Add(Interval.MajorSeventh, CSharp!)
																				.Add(Interval.PerfectOctave, D!)
																				.Add(Interval.MinorNinth, EFlat!)
																				.Add(Interval.MajorNinth, E!)
																				.Add(Interval.PerfectEleventh, G!)
																				.Add(Interval.AugmentedEleventh, GSharp!)
																				.Add(Interval.MinorThirteenth, BFlat!)
																				.Add(Interval.MajorThirteenth, B!));
	public static readonly Pitch DSharp = new("D#",
																					 3,
																					 1,
																					 () => E!,
																					 () => D,
																					 () => D,
																					 () => D!.intervalsToPitchs().Sharp());

	public static readonly Pitch EFlat = new("Eb",
																					3,
																					1,
																					() => E!,
																					() => D,
																					() => E!,
																					() => E!.intervalsToPitchs().Flat());
	public static readonly Pitch E = new("E",
																			4,
																			0,
																			() => F!,
																			() => EFlat,
																			() => E!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, E!)
																				.Add(Interval.MinorSecond, F!)
																				.Add(Interval.MajorSecond, FSharp!)
																				.Add(Interval.MinorThird, G!)
																				.Add(Interval.MajorThird, GSharp!)
																				.Add(Interval.PerfectFourth, A!)
																				.Add(Interval.AugmentedFourth, ASharp!)
																				.Add(Interval.DiminishedFifth, BFlat!)
																				.Add(Interval.PerfectFifth, B!)
																				.Add(Interval.AugmentedFifth, BSharp!)
																				.Add(Interval.MinorSixth, C!)
																				.Add(Interval.MajorSixth, CSharp!)
																				.Add(Interval.DiminishedSeventh, DFlat!)
																				.Add(Interval.MinorSeventh, D!)
																				.Add(Interval.MajorSeventh, DSharp!)
																				.Add(Interval.PerfectOctave, E!)
																				.Add(Interval.MinorNinth, F!)
																				.Add(Interval.MajorNinth, FSharp!)
																				.Add(Interval.PerfectEleventh, A!)
																				.Add(Interval.AugmentedEleventh, ASharp!)
																				.Add(Interval.MinorThirteenth, C!)
																				.Add(Interval.MajorThirteenth, CSharp!));
	public static readonly Pitch ESharp = new("E#",
																					 5,
																					 1,
																					 () => F!,
																					 () => E,
																					 () => E,
																					 () => F!.intervalsToPitchs().Sharp());
	public static readonly Pitch FFlat = new("Fb",
																					5,
																					1,
																					() => F!,
																					() => E,
																					() => F!,
																					() => F!.intervalsToPitchs().Flat());
	public static readonly Pitch F = new("F",
																			5,
																			0,
																			() => FSharp!,
																			() => E,
																			() => F!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, F!)
																				.Add(Interval.MinorSecond, FSharp!)
																				.Add(Interval.MajorSecond, G!)
																				.Add(Interval.MinorThird, GSharp!)
																				.Add(Interval.MajorThird, A!)
																				.Add(Interval.PerfectFourth, B!)
																				.Add(Interval.AugmentedFourth, BSharp!)
																				.Add(Interval.DiminishedFifth, C!)
																				.Add(Interval.PerfectFifth, CSharp!)
																				.Add(Interval.AugmentedFifth, D!)
																				.Add(Interval.MinorSixth, DFlat!)
																				.Add(Interval.MajorSixth, D!)
																				.Add(Interval.DiminishedSeventh, EFlat!)
																				.Add(Interval.MinorSeventh, E!)
																				.Add(Interval.MajorSeventh, ESharp!)
																				.Add(Interval.PerfectOctave, F!)
																				.Add(Interval.MinorNinth, FSharp!)
																				.Add(Interval.MajorNinth, G!)
																				.Add(Interval.PerfectEleventh, B!)
																				.Add(Interval.AugmentedEleventh, BSharp!)
																				.Add(Interval.MinorThirteenth, DFlat!)
																				.Add(Interval.MajorThirteenth, D!));
	public static readonly Pitch FSharp = new("F#",
																					 6,
																					 1,
																					 () => G!,
																					 () => F,
																					 () => F,
																					 () => F!.intervalsToPitchs().Sharp());
	public static readonly Pitch GFlat = new("Gb",
																					6,
																					1,
																					() => G!,
																					() => F,
																					() => G!,
																					() => G!.intervalsToPitchs().Flat());
	public static readonly Pitch G = new("G",
																			7,
																			0,
																			() => GSharp!,
																			() => GFlat,
																			() => G!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, G!)
																				.Add(Interval.MinorSecond, GSharp!)
																				.Add(Interval.MajorSecond, A!)
																				.Add(Interval.MinorThird, ASharp!)
																				.Add(Interval.MajorThird, B!)
																				.Add(Interval.PerfectFourth, C!)
																				.Add(Interval.AugmentedFourth, CSharp!)
																				.Add(Interval.DiminishedFifth, DFlat!)
																				.Add(Interval.PerfectFifth, D!)
																				.Add(Interval.AugmentedFifth, DSharp!)
																				.Add(Interval.MinorSixth, EFlat!)
																				.Add(Interval.MajorSixth, E!)
																				.Add(Interval.DiminishedSeventh, FFlat!)
																				.Add(Interval.MinorSeventh, F!)
																				.Add(Interval.MajorSeventh, FSharp!)
																				.Add(Interval.PerfectOctave, G!)
																				.Add(Interval.MinorNinth, GSharp!)
																				.Add(Interval.MajorNinth, A!)
																				.Add(Interval.PerfectEleventh, C!)
																				.Add(Interval.AugmentedEleventh, CSharp!)
																				.Add(Interval.MinorThirteenth, E!)
																				.Add(Interval.MajorThirteenth, ESharp!));
	public static readonly Pitch GSharp = new("G#",
																					 8,
																					 1,
																					 () => A!,
																					 () => G,
																					 () => G,
																					 () => G!.intervalsToPitchs().Sharp());
	public static readonly Pitch AFlat = new("Ab",
																					8,
																					1,
																					() => A!,
																					() => G,
																					() => A!,
																					() => A!.intervalsToPitchs().Flat());

	public static readonly Pitch A = new("A",
																			9,
																			0,
																			() => ASharp!,
																			() => AFlat,
																			() => A!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, A!)
																				.Add(Interval.MinorSecond, ASharp!)
																				.Add(Interval.MajorSecond, B!)
																				.Add(Interval.MinorThird, C!)
																				.Add(Interval.MajorThird, CSharp!)
																				.Add(Interval.PerfectFourth, D!)
																				.Add(Interval.AugmentedFourth, DSharp!)
																				.Add(Interval.DiminishedFifth, EFlat!)
																				.Add(Interval.PerfectFifth, E!)
																				.Add(Interval.AugmentedFifth, ESharp!)
																				.Add(Interval.MinorSixth, F!)
																				.Add(Interval.MajorSixth, FSharp!)
																				.Add(Interval.DiminishedSeventh, GFlat!)
																				.Add(Interval.MinorSeventh, G!)
																				.Add(Interval.MajorSeventh, GSharp!)
																				.Add(Interval.PerfectOctave, A!)
																				.Add(Interval.MinorNinth, ASharp!)
																				.Add(Interval.MajorNinth, B!)
																				.Add(Interval.PerfectEleventh, D!)
																				.Add(Interval.AugmentedEleventh, DSharp!)
																				.Add(Interval.MinorThirteenth, F!)
																				.Add(Interval.MajorThirteenth, FSharp!));
	public static readonly Pitch ASharp = new("A#",
																					 10,
																					 1,
																					 () => B!,
																					 () => A,
																					 () => A,
																					 () => A!.intervalsToPitchs().Sharp());
	public static readonly Pitch BFlat = new("Bb",
																					10,
																					1,
																					() => B!,
																					() => A,
																					() => B!,
																					() => new IntervalsToPitches()
																				.Add(Interval.Unison, BFlat!)
																				.Add(Interval.MinorSecond, B!)
																				.Add(Interval.MajorSecond, C!)
																				.Add(Interval.MinorThird, DFlat!)
																				.Add(Interval.MajorThird, D!)
																				.Add(Interval.PerfectFourth, EFlat!)
																				.Add(Interval.AugmentedFourth, E!)
																				.Add(Interval.DiminishedFifth, FFlat!)
																				.Add(Interval.PerfectFifth, F!)
																				.Add(Interval.AugmentedFifth, FSharp!)
																				.Add(Interval.MinorSixth, GFlat!)
																				.Add(Interval.MajorSixth, G!)
																				.Add(Interval.DiminishedSeventh, G!)
																				.Add(Interval.MinorSeventh, AFlat!)
																				.Add(Interval.MajorSeventh, A!)
																				.Add(Interval.PerfectOctave, B!)
																				.Add(Interval.MinorNinth, C!)
																				.Add(Interval.MajorNinth, CSharp!)
																				.Add(Interval.PerfectEleventh, EFlat!)
																				.Add(Interval.AugmentedEleventh, E!)
																				.Add(Interval.MinorThirteenth, GFlat!)
																				.Add(Interval.MajorThirteenth, G!));

	public static readonly Pitch B = new("B",
																			11,
																			0,
																			() => C,
																			() => BFlat,
																			() => B!,
																			() => new IntervalsToPitches()
																				.Add(Interval.Unison, B!)
																				.Add(Interval.MinorSecond, C!)
																				.Add(Interval.MajorSecond, CSharp!)
																				.Add(Interval.MinorThird, D!)
																				.Add(Interval.MajorThird, DSharp!)
																				.Add(Interval.PerfectFourth, E!)
																				.Add(Interval.AugmentedFourth, ESharp!)
																				.Add(Interval.DiminishedFifth, F!)
																				.Add(Interval.PerfectFifth, FSharp!)
																				.Add(Interval.AugmentedFifth, G!)
																				.Add(Interval.MinorSixth, G!)
																				.Add(Interval.MajorSixth, GSharp!)
																				.Add(Interval.DiminishedSeventh, AFlat!)
																				.Add(Interval.MinorSeventh, A!)
																				.Add(Interval.MajorSeventh, ASharp!)
																				.Add(Interval.PerfectOctave, B!)
																				.Add(Interval.MinorNinth, C!)
																				.Add(Interval.MajorNinth, CSharp!)
																				.Add(Interval.PerfectEleventh, E!)
																				.Add(Interval.AugmentedEleventh, ESharp!)
																				.Add(Interval.MinorThirteenth, G!)
																				.Add(Interval.MajorThirteenth, GSharp!));
	public static readonly Pitch BSharp = new("B#",
																					 0,
																					 1,
																					 () => C,
																					 () => B,
																					 () => B,
																					 () => C!.intervalsToPitchs());

	public override bool Equals(object? obj)
	{
		if (obj is Pitch pitch)
		{
			return value == pitch.value && accidentals == pitch.accidentals;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(value, accidentals);
	}

	public override string ToString()
	{
		return name;
	}
}