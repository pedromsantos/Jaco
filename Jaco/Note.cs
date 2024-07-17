// using Jaco;
// public class Note
// {
// 	private readonly Pitch pitch;
// 	private readonly Duration duration;
// 	private readonly Octave octave;

// 	public Note(Pitch pitch, Duration duration, Octave octave)
// 	{
// 		this.pitch = pitch;
// 		this.duration = duration;
// 		this.octave = octave;
// 	}

// 	public Note Transpose(Interval interval)
// 	{
// 		return new Note(pitch.Transpose(interval), duration, octave);
// 	}

// 	public Note OctaveUp()
// 	{
// 		return new Note(pitch, duration, octave.Up());
// 	}

// 	public Note OctaveDown()
// 	{
// 		return new Note(pitch, duration, octave.Down());
// 	}

// 	public Interval IntervalTo(Note to)
// 	{
// 		if (octave == to.octave)
// 		{
// 			return pitch.IntervalTo(to.pitch);
// 		}

// 		return pitch.IntervalTo(to.pitch).RaiseOctave();
// 	}

// 	public IntervalDirection IntervalDirection(Note other)
// 	{
// 		if (MidiNumbers < other.MidiNumbers)
// 		{
// 			return IntervalDirection.Ascending;
// 		}

// 		if (MidiNumbers > other.MidiNumbers)
// 		{
// 			return IntervalDirection.Descending;
// 		}

// 		return IntervalDirection.Level;
// 	}

// 	// public bool IsChordToneOf(Chord chord)
// 	// {
// 	// 	foreach (var chordTone in chord)
// 	// 	{
// 	// 		if (pitch == chordTone)
// 	// 		{
// 	// 			return true;
// 	// 		}
// 	// 	}

// 	// 	return false;
// 	// }

// 	public bool IsSamePitch(Note other)
// 	{
// 		return MidiNumbers.Pop() == other.MidiNumbers.Pop();
// 	}

// 	public bool HasSamePitch(Pitch pitch)
// 	{
// 		return this.pitch.Equal(pitch);
// 	}

// 	public bool HasSameOctave(Octave octave)
// 	{
// 		return this.octave == octave;
// 	}

// 	public IEnumerable<Pitch> Pitches
// 	{
// 		get { return new[] { pitch }; }
// 	}

// 	public Pitch Pitch
// 	{
// 		get { return pitch; }
// 	}

// 	public Duration Duration
// 	{
// 		get { return duration; }
// 	}

// 	public string DurationName
// 	{
// 		get { return duration.Name; }
// 	}

// 	public IEnumerable<Octave> Octaves
// 	{
// 		get { return new[] { octave }; }
// 	}

// 	public string OctaveNames
// 	{
// 		get { return octave.Name; }
// 	}

// 	public int Tick
// 	{
// 		get { return duration.Tick; }
// 	}

// 	public IEnumerable<int> MidiNumbers
// 	{
// 		get { return new[] { octave.MidiBaseValue + pitch.NumericValue }; }
// 	}

// 	public IEnumerable<Note> Notes
// 	{
// 		get { return new[] { this }; }
// 	}

// 	public NotePrimitives To
// 	{
// 		get
// 		{
// 			return new NotePrimitives
// 			{
// 				Pitch = pitch.To,
// 				Duration = duration.To,
// 				Octave = octave.To
// 			};
// 		}
// 	}

// 	public PlayablePrimitives ToPlayablePrimitives
// 	{
// 		get
// 		{
// 			return new PlayablePrimitives
// 			{
// 				Note = To
// 			};
// 		}
// 	}
// }

// public class Rest
// {
// 	private readonly Duration duration;

// 	public Rest(Duration duration)
// 	{
// 		this.duration = duration;
// 	}

// 	public IEnumerable<Pitch> Pitches
// 	{
// 		get { return Enumerable.Empty<Pitch>(); }
// 	}

// 	public IEnumerable<Octave> Octaves
// 	{
// 		get { return Enumerable.Empty<Octave>(); }
// 	}

// 	public IEnumerable<string> OctaveNames
// 	{
// 		get { return Enumerable.Empty<string>(); }
// 	}

// 	public IEnumerable<int> MidiNumbers
// 	{
// 		get { return Enumerable.Empty<int>(); }
// 	}

// 	public IEnumerable<Note> Notes
// 	{
// 		get { return Enumerable.Empty<Note>(); }
// 	}

// 	public Duration Duration
// 	{
// 		get { return duration; }
// 	}

// 	public string DurationName
// 	{
// 		get { return duration.Name; }
// 	}

// 	public int Tick
// 	{
// 		get { return duration.Tick; }
// 	}
// }

// public class MelodicLine : IEnumerable<Note>
// {
// 	private List<Note> phrase = new List<Note>();

// 	public MelodicLine(IEnumerable<Note> notes)
// 	{
// 		phrase.AddRange(notes);
// 	}

// 	public MelodicLine Slice(int start, int end)
// 	{
// 		return new MelodicLine(phrase.GetRange(start, end - start));
// 	}

// 	public MelodicLine Concat(MelodicLine melodicLine)
// 	{
// 		phrase.AddRange(melodicLine);
// 		return this;
// 	}

// 	public MelodicLine AppendOctaveAbove()
// 	{
// 		var newPhrase = phrase.Concat(phrase.Select(n => n.OctaveUp()));
// 		return new MelodicLine(newPhrase);
// 	}

// 	public MelodicLine PrependOctaveDown()
// 	{
// 		var newPhrase = phrase.Select(n => n.OctaveDown()).Concat(phrase);
// 		return new MelodicLine(newPhrase);
// 	}

// 	public Octave LastOctave()
// 	{
// 		var last = phrase.LastOrDefault();
// 		return last?.Octaves.FirstOrDefault();
// 	}

// 	public Octave HighestOctave()
// 	{
// 		var highestOctaveInLine = Octave.C0;

// 		foreach (var note in phrase)
// 		{
// 			if (note.Octaves.FirstOrDefault()?.HigherThan(highestOctaveInLine) == true)
// 			{
// 				highestOctaveInLine = note.Octaves.FirstOrDefault();
// 			}
// 		}

// 		return highestOctaveInLine;
// 	}

// 	public Octave LowestOctave()
// 	{
// 		var lowestOctaveInLine = Octave.C8;

// 		foreach (var note in phrase)
// 		{
// 			if (note.Octaves.FirstOrDefault()?.LowerThan(lowestOctaveInLine) == true)
// 			{
// 				lowestOctaveInLine = note.Octaves.FirstOrDefault();
// 			}
// 		}

// 		return lowestOctaveInLine;
// 	}

// 	public IEnumerable<Pitch> Pitches()
// 	{
// 		return phrase.Select(n => n.Pitch);
// 	}

// 	public Note LastNote
// 	{
// 		get { return phrase.LastOrDefault(); }
// 	}

// 	public IEnumerator<Note> GetEnumerator()
// 	{
// 		return phrase.GetEnumerator();
// 	}

// 	public int Length
// 	{
// 		get { return phrase.Count; }
// 	}
// }