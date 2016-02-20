using System.Linq;
using Jaco.Infrastructure;

namespace Jaco
{
    public class Drop2 : Chord
    {
        public Drop2(params Note[] notes)
            : base(notes)
        {
        }

        public Drop2(params NoteWithFunction[] notes)
            : base(notes)
        {
        }

        public override Chord Invert()
        {
            return new Drop2((new[] 
                { notes.Last() }
                    .Concat(
                    notes.Take(notes.Count - 1)
                        .Rotate()
                        .Rotate())
                        ).ToArray());
        }
    }
}
