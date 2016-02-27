using Jaco.Chords;

namespace Jaco.Scales
{
    public class Drop3Harmonizer : IHarmonizer
    {
        private readonly SeventhsHarmonizer harmonizer;

        public Drop3Harmonizer(SeventhsHarmonizer harmonizer)
        {
            this.harmonizer = harmonizer;
        }

        public Chord I()
        {
            return harmonizer.I().ToDrop3();
        }

        public Chord II()
        {
            return harmonizer.II().ToDrop3();
        }

        public Chord III()
        {
            return harmonizer.III().ToDrop3();
        }

        public Chord IV()
        {
            return harmonizer.IV().ToDrop3();
        }

        public Chord V()
        {
            return harmonizer.V().ToDrop3();
        }

        public Chord VI()
        {
            return harmonizer.VI().ToDrop3();
        }

        public Chord VII()
        {
            return harmonizer.VII().ToDrop3();
        }
    }
}