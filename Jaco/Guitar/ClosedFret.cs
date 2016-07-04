namespace Jaco.Guitar
{
    public class ClosedFret : Fret
    {
        public ClosedFret(GuitarString guitarString, int fret) 
            : base(guitarString, RaiseIfNut(fret))
        {
        }

        private static int RaiseIfNut(int fret)
        {
            return fret == 0 ? fret + Octave : fret;
        }
    }
}