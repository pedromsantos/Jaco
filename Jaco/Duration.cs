namespace Jaco;

using Microsoft.VisualBasic;

public abstract class TimeSignature
{
	private readonly BeatsPerMinute bpm;

	protected TimeSignature(int beats, Duration duration, int bpm)
	{
		this.beats = beats;
		this.duration = duration;
		this.bpm = new BeatsPerMinute(bpm, duration);
	}

	protected int beats;
	protected Duration duration;

	protected virtual double beatValue
	{
		get { return duration.Value; }
	}

	public double beatDuration
	{
		get { return beatValue; }
	}

	public double BeatDurationMilliseconds
	{
		get { return bpm.MilliSeconds(); }
	}

	public double BeatDurationTicks
	{
		get { return duration.Tick; }
	}

	public double MillisecondsPerMeasure
	{
		get { return BeatDurationMilliseconds * beats; }
	}

	public virtual double TicksPerMeasure
	{
		get { return BeatDurationTicks * beats; }
	}

	public int TicksPerSecond
	{
		get { return (bpm.BPM * Duration.TickPerQuarterNote) / 60; }
	}

	public abstract double ToFillMeasure(Duration duration);

	public double MillisecondsFor(Duration duration)
	{
		return bpm.MilliSecondsFor(duration);
	}
}

public class SimpleTimeSignature : TimeSignature
{
	public SimpleTimeSignature(int beats, Duration duration, int bpm = 60)
		: base(beats, duration, bpm)
	{
	}

	public override double ToFillMeasure(Duration duration)
	{
		return (BeatDurationTicks / duration.Tick) * beats;
	}

	public override string ToString()
	{
		var foo = duration.ToString().Length > 1
				? duration.ToString().Substring(2)
				: duration.ToString();

		return $"{beats}/{foo}";
	}
}

public class CompoundTimeSignature : TimeSignature
{
	public CompoundTimeSignature(int pulses, Duration duration, int bpm = 60)
		: base(pulses / 3, duration, bpm)
	{
		if (pulses % 3 != 0)
		{
			throw new ArgumentException("Compound signatures pulse must be divisible by 3");
		}
	}

	protected override double beatValue
	{
		get { return duration.Value * 3; }
	}

	public override double ToFillMeasure(Duration duration)
	{
		return (BeatDurationTicks / duration.Tick) * beats * 3;
	}

	public override double TicksPerMeasure
	{
		get { return BeatDurationTicks * beats * 3; }
	}

	public override string ToString()
	{
		var foo = duration.ToString().Length > 1
				? duration.ToString().Substring(2)
				: duration.ToString();

		return $"{beats * 3}/{foo}";
	}
}

internal class Durations
{
	private readonly double duration;

	internal Durations(double duration)
	{
		this.duration = duration;
	}

	internal double Multiply(double mutiplier) => duration * mutiplier;

	internal static readonly Durations Double = new Durations(2.0 / 1.0);
	internal static readonly Durations Whole = new Durations(1.0);
	internal static readonly Durations Half = new Durations(1.0 / 2.0);
	internal static readonly Durations Quarter = new Durations(1.0 / 4.0);
	internal static readonly Durations Eighth = new Durations(1.0 / 8.0);
	internal static readonly Durations Sixteenth = new Durations(1.0 / 16.0);
	internal static readonly Durations ThirtySecond = new Durations(1.0 / 32.0);
	internal static readonly Durations SixtyFourth = new Durations(1.0 / 64.0);

	public double Value => duration;
}

internal class Ticks
{
	internal const int TicksPerQuarterNote = 480;

	private readonly double ticks;

	internal Ticks(double ticks)
	{
		this.ticks = ticks;
	}

	public double Value => this.ticks;

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
	private static readonly Duration[] all = new Duration[0];
	private static readonly double dotMultiplier = 1.5;
	private static readonly double doubleDotMultiplier = 1.75;

	private readonly string name;
	private readonly Durations duration;
	private readonly Ticks ticks;
	private readonly string stringRepresentation;

	private Duration(string name, Durations value, Ticks ticks, string stringRepresentation)
	{
		this.name = name;
		this.duration = value;
		this.ticks = ticks;
		this.stringRepresentation = stringRepresentation;
	}

	public static int TickPerQuarterNote { get { return Ticks.TicksPerQuarterNote; } }

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
		new Durations(Durations.Half.Value * doubleDotMultiplier),
		new Ticks(Ticks.Half.Value * doubleDotMultiplier),
		Durations.Half.ToString() + "3/4"
	);

	public static readonly Duration DottedHalf = new Duration(
		"Dotted Half",
		new Durations(Durations.Half.Value * dotMultiplier),
		new Ticks(Ticks.Half.Value * dotMultiplier),
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
		new Durations(Durations.Quarter.Value * doubleDotMultiplier),
		new Ticks(Ticks.TicksPerQuarterNote * doubleDotMultiplier),
		Durations.Quarter.ToString() + "3/4"
	);

	public static readonly Duration DottedQuarter = new Duration(
		"Dotted Quarter",
		new Durations(Durations.Quarter.Value * dotMultiplier),
		new Ticks(Ticks.TicksPerQuarterNote * dotMultiplier),
		Durations.Quarter.ToString() + "1/2"
	);

	public static readonly Duration TripletHalf = new Duration(
		"Triplet Half",
		new Durations(Durations.Whole.Value * 3),
		new Ticks(Ticks.Whole.Value / 3),
		""
	);

	public static readonly Duration DoubleDottedEighth = new Duration(
		"Double Dotted Quarter",
		new Durations(Durations.Eighth.Value * doubleDotMultiplier),
		new Ticks(Ticks.Eighth.Value * doubleDotMultiplier),
		Durations.Eighth.ToString() + "3/4"
	);

	public static readonly Duration DottedEighth = new Duration(
		"Dotted Quarter",
		new Durations(Durations.Eighth.Value * dotMultiplier),
		new Ticks(Ticks.Eighth.Value * dotMultiplier),
		Durations.Eighth.ToString() + "1/2"
	);

	public static readonly Duration TripletQuarter = new Duration(
		"Triplet Quarter",
		new Durations(Durations.Half.Value / 3),
		new Ticks(Ticks.Half.Value / 3),
		""
	);

	public static readonly Duration DoubleDottedSixteenth = new Duration(
		"Double Dotted Sixteenth",
		new Durations(Durations.Sixteenth.Value * doubleDotMultiplier),
		new Ticks(Ticks.Sixteenth.Value * doubleDotMultiplier),
		Durations.Sixteenth.ToString() + "3/4"
	);

	public static readonly Duration DottedSixteenth = new Duration(
		"Dotted Sixteenth",
		new Durations(Durations.Sixteenth.Value * dotMultiplier),
		new Ticks(Ticks.Sixteenth.Value * dotMultiplier),
		Durations.Sixteenth.ToString() + "1/2"
	);

	public static readonly Duration TripletEighth = new Duration(
		"Triplet Eighth",
		new Durations(Durations.Quarter.Value / 3),
		new Ticks(Ticks.TicksPerQuarterNote / 3),
		""
	);

	public static readonly Duration DoubleDottedThirtySecond = new Duration(
		"Double Dotted ThirtySecond",
		new Durations(Durations.ThirtySecond.Value * doubleDotMultiplier),
		new Ticks(Ticks.ThirtySecond.Value * doubleDotMultiplier),
		Durations.ThirtySecond.ToString() + "3/4"
	);

	public static readonly Duration DottedThirtySecond = new Duration(
		"Dotted ThirtySecond",
		new Durations(Durations.ThirtySecond.Value * dotMultiplier),
		new Ticks(Ticks.ThirtySecond.Value * dotMultiplier),
		Durations.ThirtySecond.ToString() + "1/2"
	);

	public static readonly Duration TripletSixteenth = new Duration(
		"Triplet Sixteenth",
		new Durations(Durations.Eighth.Value / 3),
		new Ticks(Ticks.Eighth.Value / 3),
		""
	);

	public static readonly Duration DottedSixtyFourth = new Duration(
		"Dotted SixtyFourth",
		new Durations(Durations.SixtyFourth.Value * dotMultiplier),
		new Ticks(Ticks.SixtyFourth.Value * dotMultiplier),
		Durations.SixtyFourth.ToString() + "1/2"
	);

	public static readonly Duration TripletThirtySecond = new Duration(
		"Triplet ThirtySecond",
		new Durations(Durations.Sixteenth.Value / 3),
		new Ticks(Ticks.Sixteenth.Value / 3),
		""
	);
}

public class BeatsPerMinute
{
	private readonly double miliSecondsMultiplier = 60 * 1000;
	private readonly int secondsMultiplier = 60;
	private readonly int bpm;
	private readonly Duration duration;

	public BeatsPerMinute(int bpm)
	{
		this.bpm = bpm;
		this.duration = Duration.Quarter;
	}

	public BeatsPerMinute(int bpm, Duration duration)
	{
		this.bpm = bpm;
		this.duration = duration;
	}

	public int BPM
	{
		get { return bpm; }
	}

	public int Minutes(int beats = 1)
	{
		return beats / bpm;
	}

	public double Seconds(int beats = 1)
	{
		return ((double)beats / (double)bpm) * (double)secondsMultiplier;
	}

	public double MilliSeconds(int beats = 1)
	{
		return ((double)beats / (double)bpm) * (double)miliSecondsMultiplier;
	}

	public double SecondsFor(Duration duration)
	{
		double durationToBeats = duration.Value / this.duration.Value;
		return (durationToBeats / bpm) * secondsMultiplier;
	}

	public double MilliSecondsFor(Duration duration)
	{
		double durationToBeats = duration.Value / this.duration.Value;
		return (durationToBeats / bpm) * miliSecondsMultiplier;
	}
}