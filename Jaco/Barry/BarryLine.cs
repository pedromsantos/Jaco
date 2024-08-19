using System.Collections;
using Jaco.Notes;
using Jaco.Scales;

namespace Jaco.Barry;

public class BarryHarrisLine(BarryScale scale, Octave octave, Duration duration) : IEnumerable<Note>
{
	private readonly MelodicLine line = new(new List<Note>());

	public BarryHarrisLine ArpeggioUpFrom(ScaleDegree from)
	{
		line.Concat(scale.ArpeggioUp(from));

		return this;
	}

	public BarryHarrisLine ArpeggioUpFromLastPitch()
	{
		var from = LastDegree();
		if (!from.HasValue) return this;
		
		line.Concat(scale.ArpeggioUp(from.Value));

		return this;
	}

	public BarryHarrisLine PivotArpeggioUpFrom(ScaleDegree degree)
	{
		var arpeggio = scale.ArpeggioUp(degree);
		CreatePivotArpeggioLine(arpeggio, 0, 1);

		return this;
	}

	public BarryHarrisLine PivotArpeggioUpFromLastPitch()
	{
		var from = LastDegree();
		if (!from.HasValue) return this;
		
		var arpeggio = scale.ArpeggioUp(from.Value);
		CreatePivotArpeggioLine(arpeggio, 1, 2);

		return this;
	}

	public BarryHarrisLine ResolveUpTo(Pitch pitch)
	{
		line.Concat(new MelodicLine(new List<Note> { new(pitch, duration, octave) }));

		return this;
	}

	public BarryHarrisLine ResolveDownTo(Pitch pitch)
	{
		line.Concat(new MelodicLine(new List<Note> { new(pitch, duration, octave) }));

		return this;
	}

	public BarryHarrisLine ScaleDown(ScaleDegree to, ScaleDegree from)
	{
		var scaleDown = scale.ScaleDownMinHalfSteps().Skip((int)from).Take(to - from).ToList();

		line.Concat(new MelodicLine(scaleDown));

		return this;
	}

	public BarryHarrisLine ScaleDownExtraHalfSteps(ScaleDegree to, ScaleDegree from)
	{
		var scaleDown = scale.ScaleDownMaxHalfSteps().Skip((int)from).Take(to - from).ToList();

		line.Concat(new MelodicLine(scaleDown));

		return this;
	}

	public BarryHarrisLine ScaleDownFromLastPitchTo(ScaleDegree to)
	{
		var from = LastDegree();

		if (from != null)
		{
			ScaleDown(to, from.Value - 1);
		}

		return this;
	}

	public BarryHarrisLine ScaleDownExtraHalfStepsFromLastPitch(ScaleDegree to)
	{
		var from = LastDegree();

		if (from != null)
		{
			ScaleDownExtraHalfSteps(to, from.Value - 1);
		}

		return this;
	}

	public MelodicLine Build()
	{
		return line;
	}

	private void CreatePivotArpeggioLine(MelodicLine tmpLine, int lowCut, int highCut)
	{
		var rawLine = tmpLine.ToList();

		var arpeggioRoot = new MelodicLine(
			rawLine.GetRange(lowCut, highCut).Select(note => note.OctaveDown())
		);
		
		line.Concat(arpeggioRoot);

		var pivot = new MelodicLine(
			rawLine.GetRange(highCut, rawLine.Count - highCut).Select(note => note.OctaveDown())
		);
		
		line.Concat(pivot);
	}

	private ScaleDegree? LastDegree()
	{
		var lastNote = line.LastNote;

		return scale.DegreeFor(lastNote.Pitch);
	}

	public IEnumerator<Note> GetEnumerator()
	{
		return line.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}