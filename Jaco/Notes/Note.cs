
namespace Jaco.Notes;

public class Note(Pitch pitch, Duration duration, Octave octave)
{
	private readonly Pitch pitch = pitch;
	private readonly Duration duration = duration;
	private readonly Octave octave = octave;

	private readonly int midiValue = pitch.Value + octave.MidiBaseValue;

	public Pitch Pitch => pitch;

	public Note OctaveUp()
	{
		return new Note(pitch, duration, octave.Up());
	}

	public Note OctaveDown()
	{
		return new Note(pitch, duration, octave.Down());
	}

	public Note Transpose(Interval interval)
	{
		if (interval.IsOctaveOrAbove())
		{
			return new Note(pitch.Transpose(interval.OctaveDown()), duration, octave.Up());
		}

		return new Note(pitch.Transpose(interval), duration, octave);
	}

	public Note Flat()
	{
		return new Note(pitch.Flat(), duration, octave);
	}

	public Note Sharp()
	{
		return new Note(pitch.Sharp(), duration, octave);
	}

	public Interval IntervalTo(Note to)
	{
		if (octave == to.octave)
		{
			return pitch.IntervalTo(to.pitch);
		}

		return pitch.IntervalTo(to.pitch).RaiseOctave();
	}

	public bool HasSamePitch(Pitch otherPitch)
	{
		return Equals(pitch, otherPitch);
	}

	// public bool IsSamePitch(Note other)
	// {
	// 	return midiValue == other.midiValue;
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
