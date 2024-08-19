using System.Collections;
using Jaco.Notes;
using Jaco.Scale;

namespace Jaco.Barry;

public class BarryHarrisLine : IEnumerable<Note>
{
	private readonly MelodicLine line;
	private readonly BarryScale scale;
	private Octave octave;
	private readonly Duration pitchDurations;

	public BarryHarrisLine(BarryScale scale, Octave octave, Duration duration)
	{
		this.line = new MelodicLine(new List<Note>());
		this.scale = scale;
		this.octave = octave;
		this.pitchDurations = duration;
	}

	public BarryHarrisLine ArpeggioUpFrom(ScaleDegree from)
	{
		this.line.Concat(this.scale.ArpeggioUp(from));

		return this;
	}

	public BarryHarrisLine ArpeggioUpFromLastPitch()
	{
		var from = this.LastDegree();

		if (from.HasValue)
		{
			this.line.Concat(this.scale.ArpeggioUp(from.Value));
		}

		return this;
	}

	public BarryHarrisLine PivotArpeggioUpFrom(ScaleDegree degree)
	{
		var arpeggio = this.scale.ArpeggioUp(degree);
		this.CreatePivotArpeggioLine(arpeggio, 0, 1);

		return this;
	}

	public BarryHarrisLine PivotArpeggioUpFromLastPitch()
	{
		var from = this.LastDegree();

		if (from.HasValue)
		{
			var arpeggio = this.scale.ArpeggioUp(from.Value);
			this.CreatePivotArpeggioLine(arpeggio, 1, 2);
		}

		return this;
	}

	public BarryHarrisLine ResolveUpTo(Pitch pitch)
	{
		this.line.Concat(new MelodicLine(new List<Note> { new Note(pitch, this.pitchDurations, octave) }));

		return this;
	}

	public BarryHarrisLine ResolveDownTo(Pitch pitch)
	{
		this.line.Concat(new MelodicLine(new List<Note> { new Note(pitch, this.pitchDurations, octave) }));

		return this;
	}

	public BarryHarrisLine ScaleDown(ScaleDegree to, ScaleDegree from)
	{
		var scaleDown = scale.ScaleDownMinHalfSteps().Skip((int)from).Take(to - from).ToList();

		this.line.Concat(scaleDown);

		return this;
	}

	public BarryHarrisLine ScaleDownExtraHalfSteps(ScaleDegree to, ScaleDegree from)
	{
		var scaleDown = scale.ScaleDownMaxHalfSteps().Skip((int)from).Take(to - from).ToList();

		this.line.Concat(scaleDown);

		return this;
	}

	public BarryHarrisLine ScaleDownFromLastPitchTo(ScaleDegree to)
	{
		var from = this.LastDegree();

		if (from != null)
		{
			this.ScaleDown(to, from.Value - 1);
		}

		return this;
	}

	public BarryHarrisLine ScaleDownExtraHalfStepsFromLastPitch(ScaleDegree to)
	{
		var from = this.LastDegree();

		if (from != null)
		{
			this.ScaleDownExtraHalfSteps(to, from.Value - 1);
		}

		return this;
	}

	public MelodicLine Build()
	{
		return this.line;
	}

	private void CreatePivotArpeggioLine(MelodicLine line, int lowCut, int highCut)
	{
		var rawLine = line.ToList();

		var arpeggioRoot = new MelodicLine(
			rawLine.GetRange(lowCut, highCut).Select(note => note.OctaveDown())
		);
		this.line.Concat(arpeggioRoot);

		var pivot = new MelodicLine(
			rawLine.GetRange(highCut, rawLine.Count - highCut).Select(note => note.OctaveDown())
		);
		this.line.Concat(pivot);
	}

	private ScaleDegree? LastDegree()
	{
		var lastNote = this.line.LastNote;

		if (lastNote != null)
		{
			return this.scale.DegreeFor(lastNote.Pitch);
		}

		return null;
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