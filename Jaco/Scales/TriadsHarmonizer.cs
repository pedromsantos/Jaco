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
            return CreateFromScaleNotes(scale.HarmonicI, scale.HarmonicIII, scale.HarmonicV);
        }

        public Chord II()
        {
            return CreateFromScaleNotes(scale.HarmonicII, scale.HarmonicIV, scale.HarmonicVI);
        }

        public Chord III()
        {
            return CreateFromScaleNotes(scale.HarmonicIII, scale.HarmonicV, scale.HarmonicVII);
        }

        public Chord IV()
        {
            return CreateFromScaleNotes(scale.HarmonicIV, scale.HarmonicVI, scale.HarmonicI);
        }

        public Chord V()
        {
            return CreateFromScaleNotes(scale.HarmonicV, scale.HarmonicVII, scale.HarmonicII);
        }

        public Chord VI()
        {
            return CreateFromScaleNotes(scale.HarmonicVI, scale.HarmonicI, scale.HarmonicIII);
        }

        public Chord VII()
        {
            return CreateFromScaleNotes(scale.HarmonicVII, scale.HarmonicII, scale.HarmonicIV);
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