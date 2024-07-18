namespace Jaco;

using System;
using System.Collections.Generic;

public class Octave
{
	private static readonly List<Octave> all = new List<Octave>();
	private readonly int midiBaseValue;

	private Octave(
		string name,
		string shortName,
		int value,
		int midiBaseValue,
		Func<Octave> up,
		Func<Octave> down)
	{
		this.Name = name;
		this.ShortName = shortName;
		this.Value = value;
		this.midiBaseValue = midiBaseValue;
		this.Up = up;
		this.Down = down;
		all.Add(this);
	}

	public string Name { get; }
	public string ShortName { get; }
	public int Value { get; }

	public int MidiBaseValue => midiBaseValue;

	public Func<Octave> Up { get; }
	public Func<Octave> Down { get; }

	public static readonly Octave C0 = new Octave(
		"Sub contra",
		"C0",
		-16,
		0,
		() => C1!,
		() => C0!
	);

	public static readonly Octave C1 = new Octave(
		"Contra",
		"C1",
		-8,
		12,
		() => C2!,
		() => C0!
	);

	public static readonly Octave C2 = new Octave(
		"Great",
		"C2",
		-4,
		24,
		() => C3!,
		() => C1!
	);

	public static readonly Octave C3 = new Octave(
		"Small",
		"C3",
		-2,
		36,
		() => C4!,
		() => C2!
	);

	public static readonly Octave C4 = new Octave(
		"One line",
		"C4",
		1,
		48,
		() => C5!,
		() => C3!
	);

	public static readonly Octave C5 = new Octave(
		"Two line",
		"C5",
		2,
		60,
		() => C6!,
		() => C4!
	);

	public static readonly Octave C6 = new Octave(
		"Three line",
		"C6",
		4,
		72,
		() => C7!,
		() => C5!
	);

	public static readonly Octave C7 = new Octave(
		"Four line",
		"C7",
		8,
		84,
		() => C8!,
		() => C6!
	);

	public static readonly Octave C8 = new Octave(
		"Five line",
		"C8",
		16,
		96,
		() => C8!,
		() => C7!
	);

	public static List<Octave> Octaves => all;

	public bool LowerThan(Octave other)
	{
		return this.Value < other.Value;
	}

	public bool HigherThan(Octave other)
	{
		return this.Value > other.Value;
	}
}
