using System.Linq;

namespace Jaco
{
    public class TriadsHarmonizer : IHarmonizer
    {
        private readonly Scale scale;

        public TriadsHarmonizer(Scale scale)
        {
            this.scale = scale;
        }

        public Chord I()
        {
            return new Chord(scale.I, ChordFunction.Major);
        }

        public Chord II()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.II, ChordFunction.Minor)
                : new Chord(scale.II, ChordFunction.Diminished);
        }

        public Chord III()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.III, ChordFunction.Minor)
                : new Chord(scale.III, ChordFunction.Augmented);
        }

        public Chord IV()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.IV, ChordFunction.Major)
                : new Chord(scale.IV, ChordFunction.Minor);
        }

        public Chord V()
        {
            return new Chord(scale.V, ChordFunction.Major);
        }

        public Chord VI()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.VI, ChordFunction.Minor)
                : new Chord(scale.VI, ChordFunction.Major);
        }

        public Chord VII()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.VII, ChordFunction.Diminished)
                : new Chord(scale.VII.Sharp(), ChordFunction.Diminished);
        }
    }
}