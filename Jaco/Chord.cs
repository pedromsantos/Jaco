using System.Collections.Generic;
using System.Linq;
using Jaco.Infrastructure;

namespace Jaco
{
    public class Chord
    {
        protected readonly List<NoteWithFunction> notes;

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

        public virtual Chord Invert()
        {
            var invertedChordNotes = notes.Rotate();
            return new Chord(invertedChordNotes.ToArray());
        }

        public Drop2 ToDrop2()
        {
            var swaped = notes.Swap(0, 1);
            var drop2Notes = swaped.Rotate();
            return new Drop2(drop2Notes.ToArray());
        }

        public Chord ToDrop3()
        {
            return ToDrop2().ToDrop2();
        }

        public Chord ToClosed()
        {
            var closedChordNotes = new List<NoteWithFunction>();
            closedChordNotes.AddRange(notes);

            foreach (var note in notes)
            {
                closedChordNotes[note.Function.Index] = note;
            }

            return new Chord(closedChordNotes.ToArray());
        }

        private IEnumerable<Interval> Intervals()
        {
            var root = NoteForFunction(Function.Root);

            return Notes.Select(note => root.IntervalWithOther(note)).Skip(1).ToList();
        }
    } 
}