using System;
using System.Collections.Generic;
using System.Linq;
using Jaco.Infrastructure;
using Jaco.Notes;

namespace Jaco.Chords
{
    public class Chord
    {
        protected readonly List<NoteWithFunction> ChordNotes;

        private Chord()
        {
            ChordNotes = new List<NoteWithFunction>();
        }

        protected Chord(params NoteWithFunction[] notes)
           :this()
        {
            ChordNotes.AddRange(notes);
        }

        public Chord(Note root, ChordFunction function)
            :this()
        {
            ChordNotes.Add(new NoteWithFunction(root, Function.Root));

            foreach (var interval in function.Intervals)
            {
                var note = new NoteWithFunction(
                                root.Transpose(interval), 
                                Function.FunctionForInterval(interval));

                ChordNotes.Add(note);
            }
        }

        public IEnumerable<Note> Notes => ChordNotes.Select(n => n.Note);

        public IEnumerable<string> NoteNames => 
                ChordNotes.Select(n => n.Note.Name);

        public Note Bass => ChordNotes.First().Note;

        public Note Lead => ChordNotes.Last().Note;

        public string Name
        {
            get
            {
                var functionName = 
                        ChordFunction
                        .FunctionForIntervals(Intervals())
                        .AbreviatedName;
                
                return NoteForFunction(Function.Root).Name + functionName;
            }
        }

        public Note NoteForFunction(Function function)
        {
            return ChordNotes.First(n => n.Function == function).Note;
        }

        public virtual Chord Invert()
        {
            var invertedChordNotes = ChordNotes.Rotate();
            return new Chord(invertedChordNotes.ToArray());
        }

        public Chord ToDrop2()
        {
            var swaped = ChordNotes.Swap(0, 1);
            var drop2Notes = swaped.Rotate();
            return new Drop2(drop2Notes.ToArray());
        }

        public Chord ToDrop3()
        {
            return new Drop3(ToDrop2().ToDrop2().ChordNotes.ToArray());
        }

        public Chord ToClosed()
        {
            var closedChordNotes = new List<NoteWithFunction>();
            closedChordNotes.AddRange(ChordNotes);

            foreach (var note in ChordNotes)
            {
                closedChordNotes[note.Function.Index] = note;
            }

            return new Chord(closedChordNotes.ToArray());
        }

        public Chord Transpose(Note newRoot)
        {
            var interval = 
                    NoteForFunction(Function.Root).
                    IntervalWithOther(newRoot);
            
            return new Chord(ChordNotes.Select(n => 
                                    new NoteWithFunction(
                                            n.Note.Transpose(interval), 
                                            n.Function))
                            .ToArray());
        }

        public Chord InversionForFunctionAsLead(Function functionAsLead)
        {
            return InversionForNoteFunction(functionAsLead, c => 
                            c.ChordNotes.Last().Function);
        }

        public Chord InversionForFunctionAsBass(Function functionAsBass)
        {
            return InversionForNoteFunction(functionAsBass, 
                            c => c.ChordNotes.First().Function);
        }

        private Chord InversionForNoteFunction(
                        Function function, 
                        Func<Chord, Function> functionAtDesiredPosition)
        {
            var invertedChord = this;

            while (functionAtDesiredPosition(invertedChord) != function)
            {
                invertedChord = invertedChord.Invert();
            }

            return invertedChord;
        }

        public Chord FindInversionWithLeadClosestToNote(Note note)
        {
            var function = ChordNotes.MinBy(n =>
                Math.Min(
                    n.Note.MeasureAbsoluteSemitones(note),
                    note.MeasureAbsoluteSemitones(n.Note)))
                .Function;

            return InversionForFunctionAsLead(function);
        }

        private IEnumerable<Interval> Intervals()
        {
            var root = NoteForFunction(Function.Root);

            return Notes.Select(note => root.IntervalWithOther(note)).Skip(1).ToList();
        }
    }
}
