namespace Jaco.Guitar
{
    public class Muted : Fret
    {
        public Muted(GuitarString guitarString) 
            : base(guitarString, -1)
        {
        }

        public override bool ExceedsMaxStrech(Fret other)
        {
            return false;
        }

        public override Fret RaiseOctave()
        {
            return this;
        }
    }
}