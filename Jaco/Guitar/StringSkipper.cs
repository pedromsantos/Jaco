using Jaco.Chords;
using Jaco.Notes;

namespace Jaco.Guitar
{
    public interface IStringSkipper
    {
        bool SkippString(Note note, Chord chord);
    }

    public class AfterBassStringSkipper : IStringSkipper
    {
        public bool SkippString(Note note, Chord chord)
        {
            return note == chord.Bass;
        }
    }

    public class NoStringSkipper : IStringSkipper
    {
        public bool SkippString(Note note, Chord chord)
        {
            return false;
        }
    }
}
