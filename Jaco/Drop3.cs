using System.Linq;
using Jaco.Infrastructure;

namespace Jaco
{
    public class Drop3 : Chord
    {
        public Drop3(params NoteWithFunction[] notes)
            : base(notes)
        {
        }

        public override Chord Invert()
        {
            return new Drop3(ChordNotes.Rotate().Rotate().Swap(1, 2).ToArray());
        }
    }
}