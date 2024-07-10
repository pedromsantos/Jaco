namespace Jaco;

public class Pitch
{
	private readonly string name;
	private readonly int value;
	private readonly int accidentals;
	private readonly Func<Pitch> sharp;
	private readonly Func<Pitch> flat;
	private readonly Func<Pitch> natural;

	private Pitch(string name, int value, int accidentals, Func<Pitch> sharp, Func<Pitch> flat, Func<Pitch> natural)
	{
		this.name = name;
		this.value = value;
		this.accidentals = accidentals;
		this.sharp = sharp;
		this.flat = flat;
		this.natural = natural;
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

	public static readonly Pitch CFlat = new("Cb", 0, 1, () => C, () => B, () => C);
	public static readonly Pitch C = new("C", 0, 0, () => CSharp, () => BFlat, () => C);
	public static readonly Pitch CSharp = new("C#", 1, 1, () => D, () => C, () => C);
	public static readonly Pitch DFlat = new("Db", 1, 1, () => D, () => C, () => D);
	public static readonly Pitch D = new("D", 2, 0, () => DSharp, () => DFlat, () => D);
	public static readonly Pitch DSharp = new("D#", 3, 1, () => E, () => D, () => D);
	public static readonly Pitch EFlat = new("Eb", 3, 1, () => E, () => D, () => E);
	public static readonly Pitch E = new("E", 4, 0, () => F, () => EFlat, () => E);
	public static readonly Pitch ESharp = new("E#", 5, 1, () => F, () => E, () => E);
	public static readonly Pitch FFlat = new("Fb", 5, 1, () => F, () => E, () => F);
	public static readonly Pitch F = new("F", 5, 0, () => FSharp, () => E, () => F);
	public static readonly Pitch FSharp = new("F#", 6, 1, () => G, () => F, () => F);
	public static readonly Pitch GFlat = new("Gb", 6, 1, () => G, () => F, () => G);
	public static readonly Pitch G = new("G", 7, 0, () => GSharp, () => GFlat, () => G);
	public static readonly Pitch GSharp = new("G#", 8, 1, () => A, () => G, () => G);
	public static readonly Pitch AFlat = new("Ab", 8, 1, () => A, () => G, () => A);
	public static readonly Pitch A = new("A", 9, 0, () => ASharp, () => AFlat, () => A);
	public static readonly Pitch ASharp = new("A#", 10, 1, () => B, () => A, () => A);
	public static readonly Pitch BFlat = new("Bb", 10, 1, () => B, () => A, () => B);
	public static readonly Pitch B = new("B", 11, 0, () => C, () => BFlat, () => B);
	public static readonly Pitch BSharp = new("B#", 0, 1, () => C, () => B, () => B);

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