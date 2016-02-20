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
}