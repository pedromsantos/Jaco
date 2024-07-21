using System.Collections;

namespace Jaco
{
	public enum ScaleDegree
	{
		I = 0,
		II,
		III,
		IV,
		V,
		VI,
		VII,
	}

	public class ScalePattern
	{
		private static readonly List<ScalePattern> all = new List<ScalePattern>();

		private ScalePattern(string name, List<Interval> pattern)
		{
			Name = name;
			Pattern = pattern;
			all.Add(this);
		}

		public string Name { get; }
		public List<Interval> Pattern { get; }

		public static readonly ScalePattern Ionian = new ScalePattern("Ionian", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern Dorian = new ScalePattern("Dorian", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Phrygian = new ScalePattern("Phrygian", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Lydian = new ScalePattern("Lydian", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern Mixolydian = new ScalePattern("Mixolydian", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Aeolian = new ScalePattern("Aolian", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Locrian = new ScalePattern("Locrian", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern MajorPentatonic = new ScalePattern("Major Pentatonic", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFifth,
			Interval.MajorSixth,
		});

		public static readonly ScalePattern MinorPentatonic = new ScalePattern("Minor Pentatonic", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Blues = new ScalePattern("Blues", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.PerfectFifth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern HarmonicMinor = new ScalePattern("Harmonic Minor", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern MelodicMinor = new ScalePattern("Melodic Minor", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern Dorianb2 = new ScalePattern("Dorian b2", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern NeapolitanMinor = new ScalePattern("Neapolitan Minor", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern LydianAugmented = new ScalePattern("Lydian Augmented", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern LydianDominant = new ScalePattern("Lydian Dominant", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Mixolydianb6 = new ScalePattern("Mixolydian b6", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern Bebop = new ScalePattern("Bebop", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern LocrianSharp2 = new ScalePattern("Locrian #2", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern AlteredDominant = new ScalePattern("Altered Dominant", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.AugmentedSecond,
			Interval.MajorThird,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern HalfWholeDiminished = new ScalePattern("Half Whole Diminished", new List<Interval>
		{
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern WholeTone = new ScalePattern("Whole Tone", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
		});

		public static readonly ScalePattern MajorSixthDiminished = new ScalePattern("Major Sixth Diminished", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern MinorSixthDiminished = new ScalePattern("Minor Sixth Diminished", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern DominantDiminished = new ScalePattern("Dominant Diminished", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
			Interval.MajorSeventh,
		});

		public static readonly ScalePattern Dominantb5Diminished = new ScalePattern("Dominant b5 Diminished", new List<Interval>
		{
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
			Interval.MajorSeventh,
		});

		public static List<ScalePattern> ScalePatterns => all;

		public override string ToString()
		{
			return Name;
		}
	}

	public interface IScale
	{
		ScalePattern ScalePattern { get; }
		Pitch Root { get; }
		MelodicLine ScaleUpMelodicLine();
		MelodicLine ScaleDownMelodicLine();
		IEnumerable<Pitch> ThirdsFrom(ScaleDegree degree);
		MelodicLine MelodicThirdsFrom(ScaleDegree degree);
		MelodicLine MelodicThirdsTo(ScaleDegree degree);
		IEnumerator<Pitch> GetEnumerator();
	}

	public class Scale : IEnumerable<Pitch>, IScale
	{
		private readonly ScalePattern scalePattern;
		private readonly Pitch root;
		private readonly Duration duration;
		private readonly Octave octave;
		private readonly List<Pitch> pitches;

		public Scale(ScalePattern scalePattern, Pitch root, Duration duration, Octave octave)
		{
			this.scalePattern = scalePattern;
			this.root = root;
			this.duration = duration;
			this.octave = octave;
			pitches = scalePattern.Pattern.Select(interval => root.Transpose(interval)).ToList();
		}

		public ScalePattern ScalePattern => scalePattern;
		public Pitch Root => root;

		public MelodicLine ScaleUpMelodicLine()
		{
			var localOctave = octave;
			var line = new List<Note>();

			foreach (var pitch in pitches)
			{
				if (pitch == Pitch.C && line.Count > 0)
				{
					localOctave = localOctave.Up();
				}

				line.Add(new Note(pitch, duration, localOctave));
			}

			return new MelodicLine(line);
		}

		public MelodicLine ScaleDownMelodicLine()
		{
			var localOctave = octave;
			var line = new List<Note>();

			foreach (var pitch in pitches.Reverse<Pitch>())
			{
				if (pitch == Pitch.C && line.Count > 0)
				{
					localOctave = localOctave.Down();
				}

				line.Add(new Note(pitch, duration, localOctave));
			}

			return new MelodicLine(line);
		}

		public IEnumerable<Pitch> ThirdsFrom(ScaleDegree degree)
		{
			return pitches
				.Skip((int)degree)
				.Concat(pitches)
				.Concat(pitches)
				.Where((_, i) => i % 2 == 0)
				.Take(7)
				.ToList();
		}

		public MelodicLine MelodicThirdsFrom(ScaleDegree degree)
		{
			return new MelodicLine(
				pitches
					.Skip((int)degree)
					.Select(p => new Note(p, duration, octave))
					.Concat(pitches.Select(p => new Note(p, duration, octave.Up())))
					.Concat(pitches.Select(p => new Note(p, duration, octave.Up().Up())))
					.Where((_, i) => i % 2 == 0)
					.Take(7)
					.ToList()
			);
		}

		public MelodicLine MelodicThirdsTo(ScaleDegree degree)
		{
			return new MelodicLine(
				pitches
					.Skip((int)degree)
					.Select(p => new Note(p, duration, octave))
					.Concat(pitches.Select(p => new Note(p, duration, octave.Up())))
					.Concat(pitches.Select(p => new Note(p, duration, octave.Up().Up())))
					.Where((_, i) => i % 2 != 0 || i == 0)
					.Take(7)
					.ToList()
			);
		}

		public IEnumerator<Pitch> GetEnumerator()
		{
			return pitches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
