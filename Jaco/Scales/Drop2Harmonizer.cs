using Jaco.Chords;

namespace Jaco.Scales
{
    public class Drop2Harmonizer : IHarmonizer
    {
        private readonly SeventhsHarmonizer harmonizer;

        public Drop2Harmonizer(SeventhsHarmonizer harmonizer)
        {
            this.harmonizer = harmonizer;
        }

        public Chord I()
        {
            return harmonizer.I().ToDrop2();
        }

        public Chord II()
        {
            return harmonizer.II().ToDrop2();
        }

        public Chord III()
        {
            return harmonizer.III().ToDrop2();
        }

        public Chord IV()
        {
            return harmonizer.IV().ToDrop2();
        }

        public Chord V()
        {
            return harmonizer.V().ToDrop2();
        }

        public Chord VI()
        {
            return harmonizer.VI().ToDrop2();
        }

        public Chord VII()
        {
            return harmonizer.VII().ToDrop2();
        }
    }
}