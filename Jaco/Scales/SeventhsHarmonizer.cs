using Jaco.Chords;

namespace Jaco.Scales
{
    public class SeventhsHarmonizer : IHarmonizer
    {
        private readonly Scale scale;

        public SeventhsHarmonizer(Scale scale)
        {
            this.scale = scale;
        }

        public Chord I()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.I, ChordFunction.Major7)
                : new Chord(scale.I, ChordFunction.MinorMaj7);
        }

        public Chord II()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.II, ChordFunction.Minor7)
                : new Chord(scale.II, ChordFunction.Minor7b5);
        }

        public Chord III()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.III, ChordFunction.Minor7)
                : new Chord(scale.III, ChordFunction.Augmented7);
        }

        public Chord IV()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.IV, ChordFunction.Major7)
                : new Chord(scale.IV, ChordFunction.Minor7);
        }

        public Chord V()
        {
            return new Chord(scale.V, ChordFunction.Dominant7);
        }

        public Chord VI()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.VI, ChordFunction.Minor7)
                : new Chord(scale.VI, ChordFunction.Major7);
        }

        public Chord VII()
        {
            return scale.Quality == ScaleQuality.Major
                ? new Chord(scale.VII, ChordFunction.Minor7b5)
                : new Chord(scale.VII.Sharp(), ChordFunction.Diminished7);
        }
    }
}