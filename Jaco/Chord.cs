using System.Collections.Generic;
using System.Linq;

namespace Jaco
{
    public struct NoteWithFunction
    {
        public Note Note { get; }

        public Function Function { get; }

        public NoteWithFunction(Note note, Function function)
        {
            Function = function;
            Note = note;
        }
    }

    public class Chord
    {
        private readonly List<NoteWithFunction> notes;

        public Chord(params Note[] notes)
        {
            this.notes = new List<NoteWithFunction>();
            for (var i = 0; i < notes.Length; i++)
            {
                this.notes.Add(new NoteWithFunction(notes[i], Function.Functions.ElementAt(i)));
            }
        }

        public Chord(params NoteWithFunction[] notes)
        {
            this.notes = new List<NoteWithFunction>();
            this.notes.AddRange(notes);
        }

        public IEnumerable<Note> Notes => notes.Select(n => n.Note);

        public Note Bass => notes.First().Note;

        public Note Lead => notes.Last().Note;

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
            return notes.First(n => n.Function == function).Note;
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