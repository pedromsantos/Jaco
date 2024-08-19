using System.Collections;
using Jaco.Notes;

namespace Jaco.Scale
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
		private static readonly List<ScalePattern> All = [];

		private ScalePattern(string name, List<Interval> pattern)
		{
			Name = name;
			Pattern = pattern;
			All.Add(this);
		}

		public string Name { get; }
		public List<Interval> Pattern { get; }

		public static readonly ScalePattern Ionian = new("Ionian", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern Dorian = new("Dorian", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Phrygian = new("Phrygian", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Lydian = new("Lydian", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern Mixolydian = new("Mixolydian", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Aeolian = new("Aolian", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Locrian = new("Locrian", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern MajorPentatonic = new("Major Pentatonic", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFifth,
			Interval.MajorSixth
		]);

		public static readonly ScalePattern MinorPentatonic = new("Minor Pentatonic", [
			Interval.Unison,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Blues = new("Blues", [
			Interval.Unison,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.PerfectFifth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern HarmonicMinor = new("Harmonic Minor", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern MelodicMinor = new("Melodic Minor", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern Dorianb2 = new("Dorian b2", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern NeapolitanMinor = new("Neapolitan Minor", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern LydianAugmented = new("Lydian Augmented", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern LydianDominant = new("Lydian Dominant", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Mixolydianb6 = new("Mixolydian b6", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern Bebop = new("Bebop", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern LocrianSharp2 = new("Locrian #2", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.MinorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern AlteredDominant = new("Altered Dominant", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.AugmentedSecond,
			Interval.MajorThird,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern HalfWholeDiminished = new("Half Whole Diminished", [
			Interval.Unison,
			Interval.MinorSecond,
			Interval.MinorThird,
			Interval.MajorThird,
			Interval.AugmentedFourth,
			Interval.PerfectFifth,
			Interval.MajorSixth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern WholeTone = new("Whole Tone", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh
		]);

		public static readonly ScalePattern MajorSixthDiminished = new("Major Sixth Diminished", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern MinorSixthDiminished = new("Minor Sixth Diminished", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MinorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MajorSixth,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern DominantDiminished = new("Dominant Diminished", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.PerfectFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
			Interval.MajorSeventh
		]);

		public static readonly ScalePattern Dominantb5Diminished = new("Dominant b5 Diminished", [
			Interval.Unison,
			Interval.MajorSecond,
			Interval.MajorThird,
			Interval.PerfectFourth,
			Interval.DiminishedFifth,
			Interval.AugmentedFifth,
			Interval.MinorSeventh,
			Interval.MajorSeventh
		]);

		public static List<ScalePattern> ScalePatterns => All;

		public override string ToString()
		{
			return Name;
		}
	}

	public interface IScale : IEnumerable<Pitch>
	{
		ScalePattern ScalePattern { get; }
		Pitch Root { get; }
		MelodicLine ScaleUpMelodicLine();
		MelodicLine ScaleDownMelodicLine();
		IEnumerable<Pitch> ThirdsFrom(ScaleDegree degree);
		MelodicLine MelodicThirdsFrom(ScaleDegree degree);
		MelodicLine MelodicThirdsTo(ScaleDegree degree);
		MelodicLine ArpeggioUp(ScaleDegree degree);
		ScaleDegree? DegreeFor(Pitch pitch);
	}

	public class Scale(ScalePattern scalePattern, Pitch root, Duration duration, Octave octave)
		: IScale
	{
		private readonly List<Pitch> pitches = scalePattern.Pattern.Select(root.Transpose).ToList();

		public ScalePattern ScalePattern { get; } = scalePattern;

		public Pitch Root { get; } = root;

		public MelodicLine ScaleUpMelodicLine()
		{
			var localOctave = octave;
			var line = new List<Notes.Note>();

			foreach (var pitch in pitches)
			{
				if (Equals(pitch, Pitch.C) && line.Count > 0)
				{
					localOctave = localOctave.Up();
				}

				line.Add(new Notes.Note(pitch, duration, localOctave));
			}

			return new MelodicLine(line);
		}

		public MelodicLine ScaleDownMelodicLine()
		{
			var localOctave = octave;
			var line = new List<Notes.Note>();

			foreach (var pitch in pitches.Reverse<Pitch>())
			{
				if (Equals(pitch, Pitch.C) && line.Count > 0)
				{
					localOctave = localOctave.Down();
				}

				line.Add(new Notes.Note(pitch, duration, localOctave));
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
					.Select(p => new Notes.Note(p, duration, octave))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up())))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up().Up())))
					.Where((_, i) => i % 2 == 0)
					.Take(7)
					.ToList()
			);
		}

		public MelodicLine ArpeggioUp(ScaleDegree degree)
		{
			return new MelodicLine(
				pitches
					.Skip((int)degree)
					.Select(p => new Notes.Note(p, duration, octave))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up())))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up().Up())))
					.Where((_, i) => i % 2 == 0)
					.Take(4)
					.ToList()
			);
		}

		public MelodicLine MelodicThirdsTo(ScaleDegree degree)
		{
			return new MelodicLine(
				pitches
					.Skip((int)degree)
					.Select(p => new Notes.Note(p, duration, octave))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up())))
					.Concat(pitches.Select(p => new Notes.Note(p, duration, octave.Up().Up())))
					.Where((_, i) => i % 2 != 0 || i == 0)
					.Take(7)
					.ToList()
			);
		}

		public ScaleDegree? DegreeFor(Pitch pitch)
		{
			var degree = this.pitches.FindIndex(p => Equals(p, pitch));

			return (ScaleDegree)degree;
		}

		public IEnumerator<Pitch> GetEnumerator()
		{
			return pitches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
