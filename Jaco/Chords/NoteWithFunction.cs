using Jaco.Notes;

namespace Jaco.Chords
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
}