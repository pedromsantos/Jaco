namespace Jaco
{
    public class TriadsHarmonizer
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
            return new Chord(scale.II, ChordFunction.Minor);
        }

        public Chord III()
        {
            return new Chord(scale.III, ChordFunction.Minor);
        }

        public Chord IV()
        {
            return new Chord(scale.IV, ChordFunction.Major);
        }

        public Chord V()
        {
            return new Chord(scale.V, ChordFunction.Major);
        }

        public Chord VI()
        {
            return new Chord(scale.VI, ChordFunction.Minor);
        }

        public Chord VII()
        {
            return new Chord(scale.VII, ChordFunction.Diminished);
        }
    }
}