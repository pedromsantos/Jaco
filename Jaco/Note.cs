namespace Jaco;

public class Note
{
	private readonly Pitch pitch;
	private readonly Duration duration;
	private readonly Octave octave;

	private readonly int midiValue;

	public Note(Pitch pitch, Duration duration, Octave octave)
	{
		this.pitch = pitch;
		this.duration = duration;
		this.octave = octave;
		this.midiValue = pitch.Value + octave.MidiBaseValue;
	}

	public Note Transpose(Interval interval)
	{
		if (interval.IsOctaveOrAbove())
		{
			return new Note(pitch.Transpose(interval.OctaveDown()), duration, octave.Up());
		}

		return new Note(pitch.Transpose(interval), duration, octave);
	}

	public Note OctaveUp()
	{
		return new Note(pitch, duration, octave.Up());
	}

	public Note OctaveDown()
	{
		return new Note(pitch, duration, octave.Down());
	}

	public Interval IntervalTo(Note to)
	{
		if (octave == to.octave)
		{
			return pitch.IntervalTo(to.pitch);
		}

		return pitch.IntervalTo(to.pitch).RaiseOctave();
	}

	public bool AscendingTo(Note other)
	{
		return this.midiValue < other.midiValue;
	}

	public bool DescendingTo(Note other)
	{
		return this.midiValue > other.midiValue;
	}

	// public bool IsSamePitch(Note other)
	// {
	// 	return midiValue == other.midiValue;
	// }

	// public bool HasSamePitch(Pitch pitch)
	// {
	// 	return this.pitch == pitch;
	// }

	// public bool HasSameOctave(Octave octave)
	// {
	// 	return this.octave == octave;
	// }

	public override bool Equals(object? obj)
	{
		if (obj == null || typeof(Note) != obj.GetType())
		{
			return false;
		}

		var other = (Note)obj;
		return pitch == other.pitch && duration == other.duration && octave == other.octave;
	}

	public override int GetHashCode()
	{
		return pitch.GetHashCode() ^ duration.GetHashCode() ^ octave.GetHashCode();
	}

	public override string ToString()
	{
		return $"{pitch}{octave}";
	}

	// public bool IsChordToneOf(Chord chord)
	// {
	// 	foreach (var chordTone in chord)
	// 	{
	// 		if (pitch == chordTone)
	// 		{
	// 			return true;
	// 		}
	// 	}

	// 	return false;
	// }
}
