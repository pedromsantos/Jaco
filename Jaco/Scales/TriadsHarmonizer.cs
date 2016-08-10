using Jaco.Chords;
using Jaco.Notes;

namespace Jaco.Scales
{
    public class TriadsHarmonizer : IHarmonizer
    {
        private readonly Scale _scale;

        public TriadsHarmonizer(Scale scale)
        {
            _scale = scale;
        }

        public Chord I()
        {
            return CreateFromScaleNotes(_scale.I, _scale.III, _scale.V);
        }

        public Chord II()
        {
            return CreateFromScaleNotes(_scale.II, _scale.IV, _scale.VI);
        }

        public Chord III()
        {
            return CreateFromScaleNotes(_scale.III, _scale.V, _scale.VII);
        }

        public Chord IV()
        {
            return CreateFromScaleNotes(_scale.IV, _scale.VI, _scale.I);
        }

        public Chord V()
        {
            return CreateFromScaleNotes(_scale.V, _scale.VII, _scale.II);
        }

        public Chord VI()
        {
            return CreateFromScaleNotes(_scale.VI, _scale.I, _scale.III);
        }

        public Chord VII()
        {
            return CreateFromScaleNotes(_scale.VII, _scale.II, _scale.IV);
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