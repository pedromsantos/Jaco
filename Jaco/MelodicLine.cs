using System.Collections;
using System.Collections.Generic;

namespace Jaco;


public class MelodicLine : IEnumerable<Note>
{
	private readonly List<Note> line;

	public MelodicLine(IEnumerable<Note> notes)
	{
		line = notes.ToList();
	}

	public MelodicLine Slice(int start, int end)
	{
		return new MelodicLine(line.GetRange(start, end - start));
	}

	public void Concat(MelodicLine melodicLine)
	{
		line.AddRange(melodicLine);
	}

	public MelodicLine DuplicateLineOctaveAbove()
	{
		return new MelodicLine(line.Concat(line.Select(n => n.Transpose(Interval.PerfectOctave))).ToList());
	}

	public MelodicLine DuplicateOctaveBelow()
	{
		return new MelodicLine(line.Select(n => n.Transpose(Interval.PerfectOctave)).Concat(line).ToList());
	}

	public Note LastNote => line[^1];

	public int Length => line.Count;

	IEnumerator<Note> IEnumerable<Note>.GetEnumerator()
	{
		return line.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return line.GetEnumerator();
	}
}