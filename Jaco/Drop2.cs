using System.Linq;
using Jaco.Infrastructure;

namespace Jaco
{
    public class Drop2 : Chord
    {
        public Drop2(params NoteWithFunction[] notes)
            : base(notes)
        {
        }

        public override Chord Invert()
        {
            return new Drop2((new[] 
                { ChordNotes.Last() }
                    .Concat(
                    ChordNotes.Take(ChordNotes.Count - 1)
                        .Rotate()
                        .Rotate())
                        ).ToArray());
        }
    }
}
