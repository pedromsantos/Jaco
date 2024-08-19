using System.Collections;

namespace Jaco.Notes;

public class MelodicLine(IEnumerable<Note> notes) : IEnumerable<Note>
{
	private readonly List<Note> line = notes.ToList();

	public MelodicLine Slice(int start, int end)
	{
		return new MelodicLine(line.GetRange(start, end - start));
	}

	public void Concat(MelodicLine melodicLine)
	{
		line.AddRange(melodicLine);
	}

	public void Add(Note note)
	{
		line.Add(note);
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

	public IEnumerator<Note> GetEnumerator()
	{
		return line.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}