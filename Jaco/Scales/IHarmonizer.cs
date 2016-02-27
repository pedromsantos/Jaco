using Jaco.Chords;

namespace Jaco.Scales
{
    public interface IHarmonizer
    {
        Chord I();
        Chord II();
        Chord III();
        Chord IV();
        Chord V();
        Chord VI();
        Chord VII();
    }
}