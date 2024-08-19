namespace Jaco.Note;

internal class IntervalsToPitches
{
	private readonly Dictionary<Interval, Pitch> intervalsToPitches = new Dictionary<Interval, Pitch>();

	internal IntervalsToPitches()
	{
	}

	private IntervalsToPitches(IEnumerable<KeyValuePair<Interval, Pitch>> intervalsToPitchs)
	{
		foreach (var keyValue in intervalsToPitchs)
		{
			this.intervalsToPitches.Add(keyValue.Key, keyValue.Value);
		}
	}

	public IntervalsToPitches Replace(Interval interval, Pitch pitch)
	{
		return new IntervalsToPitches(intervalsToPitches.Select((keyValue) => keyValue.Key == interval ? new KeyValuePair<Interval, Pitch>(keyValue.Key, pitch) : keyValue));
	}

	public IntervalsToPitches Add(Interval interval, Pitch pitch)
	{
		intervalsToPitches.Add(interval, pitch);
		return this;
	}

	public Pitch Transpose(Interval interval)
	{
		return intervalsToPitches[interval];
	}

	public Interval IntervalTo(Pitch pitch)
	{
		return intervalsToPitches.First(x => x.Value == pitch).Key;
	}

	internal IntervalsToPitches Sharp()
	{
		return new IntervalsToPitches(this.intervalsToPitches.Select((keyValue) => new KeyValuePair<Interval, Pitch>(keyValue.Key, keyValue.Value.Sharp())));
	}

	internal IntervalsToPitches Flat()
	{
		return new IntervalsToPitches(this.intervalsToPitches.Select((keyValue) => new KeyValuePair<Interval, Pitch>(keyValue.Key, keyValue.Value.Flat())));
	}
}

public class Pitch
{
	private const int PITCHES = 12;

	private readonly string name;
	private readonly int value;
	private readonly int alterations;
	private readonly Func<Pitch> sharp;
	private readonly Func<Pitch> flat;
	private readonly Func<Pitch> natural;
	private readonly Func<IntervalsToPitches> intervalsToPitchs;

	private Pitch(string name, int value, int alterations, Func<Pitch> flat, Func<Pitch> natural,
		Func<Pitch> sharp,
		Func<IntervalsToPitches> intervalsToPitchs)
	{
		this.name = name;
		this.value = value;
		this.alterations = alterations;
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

	public Pitch SamePitchFlat()
	{
		var newName = this.natural().name + new string('b', Math.Abs(alterations));
		return new Pitch(newName, value, alterations - 1, flat, natural, sharp, () => new IntervalsToPitches());
	}

	public Pitch SamePitchSharp()
	{
		var newName = this.natural().name + new string('#', Math.Abs(alterations));
		return new Pitch(newName, value, alterations - 1, flat, natural, sharp, () => new IntervalsToPitches());
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

	public Interval IntervalTo(Pitch pitch)
	{
		return intervalsToPitchs().IntervalTo(pitch);
	}

	public bool IsEnharmonicWith(Pitch pitch)
	{
		return value == pitch.value;
	}

	public int Value => value;

	public override bool Equals(object? obj)
	{
		if (obj is Pitch pitch)
		{
			return value == pitch.value && alterations == pitch.alterations;
		}

		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(value, alterations);
	}

	public override string ToString()
	{
		return name;
	}

	public static readonly Pitch CFlat = new("Cb",
																					0,
																					-1,
																					() => B!,
																					() => C!, () => C!, () => B!.intervalsToPitchs());
	public static readonly Pitch C = new("C",
																			0,
																			0,
																			() => B!,
																			() => C!, () => CSharp!, () => new IntervalsToPitches()
																				.Add(Interval.Unison, C!)
																				.Add(Interval.MinorSecond, DFlat!)
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
																				.Add(Interval.DiminishedSeventh, BFlat!.SamePitchFlat())
																				.Add(Interval.MinorSeventh, BFlat!)
																				.Add(Interval.MajorSeventh, B!)
																				.Add(Interval.PerfectOctave, C!)
																				.Add(Interval.MinorNinth, DFlat!));
	public static readonly Pitch CSharp = new("C#",
																					 1,
																					 1,
																					 () => C,
																					 () => C, () => D!, () => C!.intervalsToPitchs().Sharp()
																					 	.Replace(Interval.MajorThird, ESharp!)
																						.Replace(Interval.AugmentedFourth, FSharp!.SamePitchSharp())
																						.Replace(Interval.AugmentedFifth, GSharp!.SamePitchSharp())
																						.Replace(Interval.DiminishedSeventh, BFlat!)
																						.Replace(Interval.MinorSeventh, B!)
																						.Replace(Interval.MajorSeventh, BSharp!));

	public static readonly Pitch DFlat = new("Db",
																					1,
																					-1,
																					() => C,
																					() => D!, () => D!, () =>
																						D!.intervalsToPitchs().Flat()
																						.Replace(Interval.MinorSecond, EFlat!.SamePitchFlat())
																						.Replace(Interval.MinorThird, FFlat!)
																						.Replace(Interval.DiminishedFifth, AFlat!.SamePitchFlat())
																						.Replace(Interval.MinorSixth, BFlat!.SamePitchFlat())
																						.Replace(Interval.DiminishedSeventh, CFlat!.SamePitchFlat())
																						.Replace(Interval.MinorSeventh, CFlat!));
	public static readonly Pitch D = new("D",
																			2,
																			0,
																			() => DFlat,
																			() => D!, () => DSharp!, () => new IntervalsToPitches()
																				.Add(Interval.Unison, D!)
																				.Add(Interval.MinorSecond, EFlat!)
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
																				.Add(Interval.DiminishedSeventh, CFlat!)
																				.Add(Interval.MinorSeventh, C!)
																				.Add(Interval.MajorSeventh, CSharp!)
																				.Add(Interval.PerfectOctave, D!));
	public static readonly Pitch DSharp = new("D#",
																					 3,
																					 1,
																					 () => D,
																					 () => D, () => E!, () => D!.intervalsToPitchs().Sharp()
																					 	.Replace(Interval.MajorSecond, ESharp!)
																						.Replace(Interval.MajorThird, FSharp!.SamePitchSharp())
																						.Replace(Interval.AugmentedFourth, GSharp!.SamePitchSharp())
																						.Replace(Interval.MajorSixth, BSharp!)
																						.Replace(Interval.MajorSeventh, CSharp!.SamePitchSharp()));

	public static readonly Pitch EFlat = new("Eb",
																					3,
																					-1,
																					() => D,
																					() => E!, () => E!, () => E!.intervalsToPitchs().Flat()
																					.Replace(Interval.MinorSecond, FFlat!)
																					.Replace(Interval.DiminishedFifth, BFlat!.SamePitchFlat())
																					.Replace(Interval.MinorSixth, CFlat!)
																					.Replace(Interval.DiminishedSeventh, DFlat!.SamePitchFlat()));
	public static readonly Pitch E = new("E",
																			4,
																			0,
																			() => EFlat,
																			() => E!, () => F!, () => new IntervalsToPitches()
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
																				.Add(Interval.PerfectOctave, E!));
	public static readonly Pitch ESharp = new("E#",
																					 5,
																					 1,
																					 () => E,
																					 () => E, () => F!, () => F!.intervalsToPitchs());
	public static readonly Pitch FFlat = new("Fb",
																					5,
																					-1,
																					() => E,
																					() => F!, () => F!, () => E!.intervalsToPitchs());
	public static readonly Pitch F = new("F",
																			5,
																			0,
																			() => E,
																			() => F!, () => FSharp!, () => new IntervalsToPitches()
																				.Add(Interval.Unison, F!)
																				.Add(Interval.MinorSecond, GFlat!)
																				.Add(Interval.MajorSecond, G!)
																				.Add(Interval.MinorThird, AFlat!)
																				.Add(Interval.MajorThird, A!)
																				.Add(Interval.PerfectFourth, B!)
																				.Add(Interval.AugmentedFourth, BSharp!)
																				.Add(Interval.DiminishedFifth, C!)
																				.Add(Interval.PerfectFifth, CSharp!)
																				.Add(Interval.AugmentedFifth, CSharp!.SamePitchSharp())
																				.Add(Interval.MinorSixth, DFlat!)
																				.Add(Interval.MajorSixth, D!)
																				.Add(Interval.DiminishedSeventh, EFlat!)
																				.Add(Interval.MinorSeventh, E!)
																				.Add(Interval.MajorSeventh, ESharp!)
																				.Add(Interval.PerfectOctave, F!));
	public static readonly Pitch FSharp = new("F#",
																					 6,
																					 1,
																					 () => F,
																					 () => F, () => G!, () => F!.intervalsToPitchs().Sharp()
																					 	.Replace(Interval.PerfectFourth, BSharp!)
																						.Replace(Interval.PerfectFifth, CSharp!.SamePitchSharp())
																						.Replace(Interval.AugmentedFifth, CSharp!.SamePitchSharp().SamePitchSharp())
																						.Replace(Interval.MinorSeventh, ESharp!)
																						.Replace(Interval.MajorSeventh, ESharp!.SamePitchSharp()));
	public static readonly Pitch GFlat = new("Gb",
																					6,
																					-1,
																					() => F,
																					() => G!, () => G!, () => G!.intervalsToPitchs().Flat()
																						.Replace(Interval.MinorSecond, AFlat!.SamePitchFlat())
																						.Replace(Interval.MinorThird, BFlat!.SamePitchFlat())
																						.Replace(Interval.PerfectFourth, CFlat)
																						.Replace(Interval.DiminishedFifth, DFlat!.SamePitchFlat())
																						.Replace(Interval.MinorSixth, EFlat!.SamePitchFlat())
																						.Replace(Interval.DiminishedSeventh, FFlat!.SamePitchFlat())
																						.Replace(Interval.MinorSeventh, FFlat!));
	public static readonly Pitch G = new("G",
																			7,
																			0,
																			() => GFlat,
																			() => G!, () => GSharp!, () => new IntervalsToPitches()
																				.Add(Interval.Unison, G!)
																				.Add(Interval.MinorSecond, AFlat!)
																				.Add(Interval.MajorSecond, A!)
																				.Add(Interval.MinorThird, BFlat!)
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
																				.Add(Interval.PerfectOctave, G!));
	public static readonly Pitch GSharp = new("G#",
																					 8,
																					 1,
																					 () => G,
																					 () => G, () => A!, () => G!.intervalsToPitchs().Sharp()
																					 	.Replace(Interval.MajorThird, BSharp!)
																						.Replace(Interval.AugmentedFourth, CSharp!.SamePitchSharp())
																						.Replace(Interval.AugmentedFifth, DSharp!.SamePitchSharp())
																						.Replace(Interval.MajorSixth, ESharp!)
																						.Replace(Interval.MajorSeventh, FSharp!.SamePitchSharp()));

	public static readonly Pitch AFlat = new("Ab",
																					8,
																					-1,
																					() => G,
																					() => A!, () => A!, () => A!.intervalsToPitchs().Flat()
																						.Replace(Interval.MinorSecond, BFlat!.SamePitchFlat())
																						.Replace(Interval.MinorThird, CFlat!)
																						.Replace(Interval.DiminishedFifth, EFlat!.SamePitchFlat())
																						.Replace(Interval.MinorSixth, FFlat!)
																						.Replace(Interval.DiminishedSeventh, GFlat!.SamePitchFlat()));

	public static readonly Pitch A = new("A",
																			9,
																			0,
																			() => AFlat,
																			() => A!, () => ASharp!, () => new IntervalsToPitches()
																				.Add(Interval.Unison, A!)
																				.Add(Interval.MinorSecond, BFlat!)
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
																				.Add(Interval.PerfectOctave, A!));
	public static readonly Pitch ASharp = new("A#",
																					 10,
																					 1,
																					 () => A,
																					 () => A, () => B!, () => A!.intervalsToPitchs().Sharp()
																					 	.Replace(Interval.MajorSecond, BSharp!)
																						.Replace(Interval.MajorThird, CSharp!.SamePitchSharp())
																						.Replace(Interval.AugmentedFourth, DSharp!.SamePitchSharp())
																						.Replace(Interval.PerfectFifth, ESharp!)
																						.Replace(Interval.AugmentedFifth, ESharp!.SamePitchSharp())
																						.Replace(Interval.MajorSixth, FSharp!.SamePitchSharp())
																						.Replace(Interval.MajorSeventh, GSharp!.SamePitchSharp()));
	public static readonly Pitch BFlat = new("Bb",
																					10,
																					-1,
																					() => A,
																					() => B!, () => B!, () => new IntervalsToPitches()
																						.Add(Interval.Unison, BFlat!)
																						.Add(Interval.MinorSecond, CFlat!.SamePitchFlat())
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
																						.Add(Interval.DiminishedSeventh, AFlat!.SamePitchFlat())
																						.Add(Interval.MinorSeventh, AFlat!)
																						.Add(Interval.MajorSeventh, A!)
																						.Add(Interval.PerfectOctave, B!));

	public static readonly Pitch B = new("B",
																			11,
																			0,
																			() => BFlat,
																			() => B!, () => C, () => new IntervalsToPitches()
																				.Add(Interval.Unison, B!)
																				.Add(Interval.MinorSecond, C!)
																				.Add(Interval.MajorSecond, CSharp!)
																				.Add(Interval.MinorThird, D!)
																				.Add(Interval.MajorThird, DSharp!)
																				.Add(Interval.PerfectFourth, E!)
																				.Add(Interval.AugmentedFourth, ESharp!)
																				.Add(Interval.DiminishedFifth, F!)
																				.Add(Interval.PerfectFifth, FSharp!)
																				.Add(Interval.AugmentedFifth, F!.Sharp().SamePitchSharp())
																				.Add(Interval.MinorSixth, G!)
																				.Add(Interval.MajorSixth, GSharp!)
																				.Add(Interval.DiminishedSeventh, AFlat!)
																				.Add(Interval.MinorSeventh, A!)
																				.Add(Interval.MajorSeventh, ASharp!)
																				.Add(Interval.PerfectOctave, B!));
	public static readonly Pitch BSharp = new("B#",
																					 0,
																					 1,
																					 () => B,
																					 () => B, () => C, () => C!.intervalsToPitchs());
}