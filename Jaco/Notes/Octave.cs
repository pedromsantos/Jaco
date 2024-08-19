namespace Jaco.Notes;

public class Octave
{
	private static readonly List<Octave> All = [];
	private readonly int midiBaseValue;

	private Octave(
		string name,
		string shortName,
		int value,
		int midiBaseValue,
		Func<Octave> up,
		Func<Octave> down)
	{
		Name = name;
		ShortName = shortName;
		Value = value;
		this.midiBaseValue = midiBaseValue;
		Up = up;
		Down = down;
		All.Add(this);
	}

	public string Name { get; }
	public string ShortName { get; }
	public int Value { get; }

	public int MidiBaseValue => midiBaseValue;

	public Func<Octave> Up { get; }
	public Func<Octave> Down { get; }

	public static readonly Octave C0 = new(
		"Sub contra",
		"C0",
		-16,
		0,
		() => C1,
		() => C0
	);

	public static readonly Octave C1 = new(
		"Contra",
		"C1",
		-8,
		12,
		() => C2,
		() => C0
	);

	public static readonly Octave C2 = new(
		"Great",
		"C2",
		-4,
		24,
		() => C3,
		() => C1
	);

	public static readonly Octave C3 = new(
		"Small",
		"C3",
		-2,
		36,
		() => C4,
		() => C2
	);

	public static readonly Octave C4 = new(
		"One line",
		"C4",
		1,
		48,
		() => C5,
		() => C3
	);

	public static readonly Octave C5 = new(
		"Two line",
		"C5",
		2,
		60,
		() => C6,
		() => C4
	);

	public static readonly Octave C6 = new(
		"Three line",
		"C6",
		4,
		72,
		() => C7,
		() => C5
	);

	public static readonly Octave C7 = new(
		"Four line",
		"C7",
		8,
		84,
		() => C8,
		() => C6
	);

	public static readonly Octave C8 = new(
		"Five line",
		"C8",
		16,
		96,
		() => C8,
		() => C7
	);

	public static IEnumerable<Octave> Octaves => All;

	public bool LowerThan(Octave other)
	{
		return Value < other.Value;
	}

	public bool HigherThan(Octave other)
	{
		return Value > other.Value;
	}
}
