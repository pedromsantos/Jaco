using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public class Chord
    {
        private readonly List<Note> notes;

        public Chord(params Note[] notes)
        {
            this.notes = new List<Note>();
            this.notes.AddRange(notes);
        }

        public IEnumerable<Note> Notes => notes;

        public Note Bass => notes.First();

        public Note Lead => notes.Last();

        public string Name
        {
            get
            {
                var functionName = ChordFunction.FunctionForIntervals(Intervals()).AbreviatedName;
                return NoteForFunction(Function.Root).Name + functionName;
            }
        }

        public Note NoteForFunction(Function function)
        {
            return notes[function.Index];
        }

        public Chord Invert()
        {
            var invertedChordNotes = notes.Skip(1).Concat(notes.Take(1));
            return new Chord(invertedChordNotes.ToArray());
        }

        private IEnumerable<Interval> Intervals()
        {
            var root = NoteForFunction(Function.Root);

            return Notes.Select(note => root.IntervalWithOther(note)).Skip(1).ToList();
        } 
    }
}