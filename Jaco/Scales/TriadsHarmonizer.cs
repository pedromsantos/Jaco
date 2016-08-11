using Jaco.Chords;
using Jaco.Notes;

namespace Jaco.Scales
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
            return CreateFromScaleNotes(scale.I, scale.III, scale.V);
        }

        public Chord II()
        {
            return CreateFromScaleNotes(scale.II, scale.IV, scale.VI);
        }

        public Chord III()
        {
            return CreateFromScaleNotes(scale.III, scale.V, scale.VII);
        }

        public Chord IV()
        {
            return CreateFromScaleNotes(scale.IV, scale.VI, scale.I);
        }

        public Chord V()
        {
            return CreateFromScaleNotes(scale.V, scale.VII, scale.II);
        }

        public Chord VI()
        {
            return CreateFromScaleNotes(scale.VI, scale.I, scale.III);
        }

        public Chord VII()
        {
            return CreateFromScaleNotes(scale.VII, scale.II, scale.IV);
        }

        private Chord CreateFromScaleNotes(Note root, Note third, Note fifth)
        {
            return new Chord(
                 new NoteWithFunction(root, Function.Root),
                 new NoteWithFunction(third, Function.Third),
                 new NoteWithFunction(fifth, Function.Fifth));
        }
    }
}