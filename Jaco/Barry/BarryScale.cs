using System.Collections;
using Jaco.Notes;
using Jaco.Scales;

namespace Jaco.Barry;

public abstract class BarryScale(ScalePattern scalePattern, Pitch root, Duration duration, Octave octave)
	: IScale
{
	private readonly IScale scale = new Scale(scalePattern, root, duration, octave);

	public ScalePattern ScalePattern => scale.ScalePattern;

	public Pitch Root => scale.Root;

	public IEnumerator<Pitch> GetEnumerator()
	{
		return scale.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
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

		foreach (var note in scaleLine)
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

		foreach (var note in scaleLine)
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

	public MelodicLine ArpeggioUp(ScaleDegree degree)
	{
		return scale.ArpeggioUp(degree);
	}

	public ScaleDegree? DegreeFor(Pitch pitch)
	{
		return scale.DegreeFor(pitch);
	}

	internal ScaleDegree? DegreeFor(object pitch)
	{
		throw new NotImplementedException();
	}
}

public class BarryDominantScale(Pitch root, Duration duration, Octave octave)
	: BarryScale(ScalePattern.Mixolydian, root, duration, octave)
{
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

public class BarryMajorScale(Pitch root, Duration duration, Octave octave)
	: BarryScale(ScalePattern.Ionian, root, duration, octave)
{
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

public class BarryMinorScale(Pitch root, Duration duration, Octave octave)
	: BarryScale(ScalePattern.HarmonicMinor, root, duration, octave)
{
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