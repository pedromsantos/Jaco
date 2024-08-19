namespace Jaco.Notes;

internal class Durations
{
	internal Durations(double duration)
	{
		this.Value = duration;
	}

	internal double Multiply(double multiplier) => Value * multiplier;

	internal static readonly Durations Double = new Durations(2.0 / 1.0);
	internal static readonly Durations Whole = new Durations(1.0);
	internal static readonly Durations Half = new Durations(1.0 / 2.0);
	internal static readonly Durations Quarter = new Durations(1.0 / 4.0);
	internal static readonly Durations Eighth = new Durations(1.0 / 8.0);
	internal static readonly Durations Sixteenth = new Durations(1.0 / 16.0);
	internal static readonly Durations ThirtySecond = new Durations(1.0 / 32.0);
	internal static readonly Durations SixtyFourth = new Durations(1.0 / 64.0);

	public double Value { get; }
}

internal class Ticks
{
	internal const int TicksPerQuarterNote = 480;

	internal Ticks(double ticks)
	{
		Value = ticks;
	}

	public double Value { get; }

	internal static readonly Ticks Double = new(TicksPerQuarterNote * 8);
	internal static readonly Ticks Whole = new(TicksPerQuarterNote * 4);
	internal static readonly Ticks Half = new(TicksPerQuarterNote * 2);
	internal static readonly Ticks Quarter = new(TicksPerQuarterNote);
	internal static readonly Ticks Eighth = new(TicksPerQuarterNote / 2);
	internal static readonly Ticks Sixteenth = new(TicksPerQuarterNote / 4);
	internal static readonly Ticks ThirtySecond = new(TicksPerQuarterNote / 8);
	internal static readonly Ticks SixtyFourth = new(TicksPerQuarterNote / 16);
}

public class Duration
{
	private const double DotMultiplier = 1.5;
	private const double DoubleDotMultiplier = 1.75;

	private readonly string name;
	private readonly Durations duration;
	private readonly Ticks ticks;
	private readonly string stringRepresentation;

	private Duration(string name, Durations value, Ticks ticks, string stringRepresentation)
	{
		this.name = name;
		duration = value;
		this.ticks = ticks;
		this.stringRepresentation = stringRepresentation;
	}

	public static int TickPerQuarterNote => Ticks.TicksPerQuarterNote;

	public string Name => name;

	public double Value => duration.Value;

	public double Tick => ticks.Value;

	public override string ToString()
	{
		return stringRepresentation;
	}

	public static readonly Duration Double = new Duration(
		"Double",
		Durations.Double,
		Ticks.Double,
		"2"
	);

	public static readonly Duration Whole = new Duration("Whole", Durations.Whole, Ticks.Whole, "1");

	public static readonly Duration Half = new Duration("Half", Durations.Half, Ticks.Half, "1/2");

	public static readonly Duration Quarter = new Duration(
		"Quarter",
		Durations.Quarter,
		Ticks.Quarter,
		"1/4"
	);

	public static readonly Duration Eighth = new Duration(
		"Eighth",
		Durations.Eighth,
		Ticks.Eighth,
		"1/8"
	);

	public static readonly Duration Sixteenth = new Duration(
		"Sixteenth",
		Durations.Sixteenth,
		Ticks.Sixteenth,
		"1/16"
	);

	public static readonly Duration ThirtySecond = new Duration(
		"ThirtySecond",
		Durations.ThirtySecond,
		Ticks.ThirtySecond,
		"1/32"
	);

	public static readonly Duration SixtyFourth = new Duration(
		"SixtyFourth",
		Durations.SixtyFourth,
		Ticks.SixtyFourth,
		"1/64"
	);

	public static readonly Duration DoubleDottedHalf = new Duration(
		"Double Dotted Half",
		new Durations(Durations.Half.Value * DoubleDotMultiplier),
		new Ticks(Ticks.Half.Value * DoubleDotMultiplier),
		Durations.Half + "3/4"
	);

	public static readonly Duration DottedHalf = new Duration(
		"Dotted Half",
		new Durations(Durations.Half.Value * DotMultiplier),
		new Ticks(Ticks.Half.Value * DotMultiplier),
		""
	);

	public static readonly Duration TripletWhole = new Duration(
		"Triplet Whole",
		new Durations(Durations.Double.Value / 3),
		new Ticks(Ticks.Double.Value / 3),
		""
	);

	public static readonly Duration DoubleDottedQuarter = new Duration(
		"Double Dotted Quarter",
		new Durations(Durations.Quarter.Value * DoubleDotMultiplier),
		new Ticks(Ticks.TicksPerQuarterNote * DoubleDotMultiplier),
		Durations.Quarter + "3/4"
	);

	public static readonly Duration DottedQuarter = new Duration(
		"Dotted Quarter",
		new Durations(Durations.Quarter.Value * DotMultiplier),
		new Ticks(Ticks.TicksPerQuarterNote * DotMultiplier),
		Durations.Quarter + "1/2"
	);

	public static readonly Duration TripletHalf = new Duration(
		"Triplet Half",
		new Durations(Durations.Whole.Value * 3),
		new Ticks(Ticks.Whole.Value / 3),
		""
	);

	public static readonly Duration DoubleDottedEighth = new Duration(
		"Double Dotted Quarter",
		new Durations(Durations.Eighth.Value * DoubleDotMultiplier),
		new Ticks(Ticks.Eighth.Value * DoubleDotMultiplier),
		Durations.Eighth + "3/4"
	);

	public static readonly Duration DottedEighth = new Duration(
		"Dotted Quarter",
		new Durations(Durations.Eighth.Value * DotMultiplier),
		new Ticks(Ticks.Eighth.Value * DotMultiplier),
		Durations.Eighth + "1/2"
	);

	public static readonly Duration TripletQuarter = new Duration(
		"Triplet Quarter",
		new Durations(Durations.Half.Value / 3),
		new Ticks(Ticks.Half.Value / 3),
		""
	);

	public static readonly Duration DoubleDottedSixteenth = new Duration(
		"Double Dotted Sixteenth",
		new Durations(Durations.Sixteenth.Value * DoubleDotMultiplier),
		new Ticks(Ticks.Sixteenth.Value * DoubleDotMultiplier),
		Durations.Sixteenth + "3/4"
	);

	public static readonly Duration DottedSixteenth = new Duration(
		"Dotted Sixteenth",
		new Durations(Durations.Sixteenth.Value * DotMultiplier),
		new Ticks(Ticks.Sixteenth.Value * DotMultiplier),
		Durations.Sixteenth + "1/2"
	);

	public static readonly Duration TripletEighth = new Duration(
		"Triplet Eighth",
		new Durations(Durations.Quarter.Value / 3),
		new Ticks(Ticks.TicksPerQuarterNote / 3),
		""
	);

	public static readonly Duration DoubleDottedThirtySecond = new Duration(
		"Double Dotted ThirtySecond",
		new Durations(Durations.ThirtySecond.Value * DoubleDotMultiplier),
		new Ticks(Ticks.ThirtySecond.Value * DoubleDotMultiplier),
		Durations.ThirtySecond + "3/4"
	);

	public static readonly Duration DottedThirtySecond = new Duration(
		"Dotted ThirtySecond",
		new Durations(Durations.ThirtySecond.Value * DotMultiplier),
		new Ticks(Ticks.ThirtySecond.Value * DotMultiplier),
		Durations.ThirtySecond + "1/2"
	);

	public static readonly Duration TripletSixteenth = new Duration(
		"Triplet Sixteenth",
		new Durations(Durations.Eighth.Value / 3),
		new Ticks(Ticks.Eighth.Value / 3),
		""
	);

	public static readonly Duration DottedSixtyFourth = new Duration(
		"Dotted SixtyFourth",
		new Durations(Durations.SixtyFourth.Value * DotMultiplier),
		new Ticks(Ticks.SixtyFourth.Value * DotMultiplier),
		Durations.SixtyFourth + "1/2"
	);

	public static readonly Duration TripletThirtySecond = new Duration(
		"Triplet ThirtySecond",
		new Durations(Durations.Sixteenth.Value / 3),
		new Ticks(Ticks.Sixteenth.Value / 3),
		""
	);
}
