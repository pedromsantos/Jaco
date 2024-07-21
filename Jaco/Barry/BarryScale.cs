
namespace Jaco;

public abstract class BarryScale : IScale
{
	protected readonly IScale scale;

	protected BarryScale(ScalePattern scalePattern, Pitch root, Duration duration, Octave octave)
	{
		scale = new Scale(scalePattern, root, duration, octave);
	}

	public ScalePattern ScalePattern => scale.ScalePattern;

	public Pitch Root => scale.Root;

	public IEnumerator<Pitch> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public MelodicLine ScaleUpMelodicLine()
	{
		return scale.ScaleUpMelodicLine();
	}

	public MelodicLine ScaleDownMelodicLine()
	{
		return scale.ScaleDownMelodicLine();
	}

	public MelodicLine ScaleDownMaxHalfSteps()
	{
		var scaleLine = scale.ScaleDownMelodicLine();
		var line = new MelodicLine(new List<Note>());

		foreach (Note note in scaleLine)
		{
			line.Add(note);

			if (InsertMaxHalfSteps(note))
			{
				line.Add(note.Flat());
			}
		}

		return line;
	}

	public MelodicLine ScaleDownMinHalfSteps()
	{
		var scaleLine = scale.ScaleDownMelodicLine();
		var line = new MelodicLine(new List<Note>());

		foreach (Note note in scaleLine)
		{
			line.Add(note);

			if (InsertMinHalfSteps(note))
			{
				line.Add(note.Flat());
			}
		}

		return line;
	}

	public MelodicLine MelodicThirdsFrom(ScaleDegree degree)
	{
		return scale.MelodicThirdsFrom(degree);
	}

	public MelodicLine MelodicThirdsTo(ScaleDegree degree)
	{
		return scale.MelodicThirdsTo(degree);
	}

	public IEnumerable<Pitch> ThirdsFrom(ScaleDegree degree)
	{
		return scale.ThirdsFrom(degree);
	}

	protected abstract bool InsertMaxHalfSteps(Note note);

	protected abstract bool InsertMinHalfSteps(Note note);
}

public class BarryDominantScale : BarryScale
{
	public BarryDominantScale(Pitch root, Duration duration, Octave octave)
		: base(ScalePattern.Mixolydian, root, duration, octave)
	{
	}

	protected override bool InsertMaxHalfSteps(Note note)
	{
		return note.HasSamePitch(Root) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorSecond)) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorThird));
	}

	protected override bool InsertMinHalfSteps(Note note)
	{
		return note.HasSamePitch(Root);
	}
}

public class BarryMajorScale : BarryScale
{
	public BarryMajorScale(Pitch root, Duration duration, Octave octave)
		: base(ScalePattern.Ionian, root, duration, octave)
	{
	}

	protected override bool InsertMaxHalfSteps(Note note)
	{
		return note.HasSamePitch(Root.Transpose(Interval.MajorSecond)) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorThird)) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorSixth));
	}

	protected override bool InsertMinHalfSteps(Note note)
	{
		return note.
		HasSamePitch(Root.Transpose(Interval.MajorSixth));
	}
}

public class BarryMinorScale : BarryScale
{
	public BarryMinorScale(Pitch root, Duration duration, Octave octave)
		: base(ScalePattern.HarmonicMinor, root, duration, octave)
	{
	}

	protected override bool InsertMaxHalfSteps(Note note)
	{
		return note.HasSamePitch(Root.Transpose(Interval.MajorSixth));
	}

	protected override bool InsertMinHalfSteps(Note note)
	{
		return note.HasSamePitch(Root.Transpose(Interval.MajorSecond)) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorThird)) ||
						note.HasSamePitch(Root.Transpose(Interval.MajorSixth));
	}
}