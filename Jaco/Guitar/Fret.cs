namespace Jaco.Guitar
{
    public class Fret
    {
        protected readonly GuitarString guitarString;
        protected readonly int fret;

        protected const int Octave = 12;
        private const int MaxStrech = 5;

        public Fret(GuitarString guitarString, int fret)
        {
            this.guitarString = guitarString;
            this.fret = fret;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Fret)) return false;
            return Equals((Fret) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((guitarString?.GetHashCode() ?? 0)*397) ^ fret;
            }
        }

        public virtual bool ExceedsMaxStrech(Fret other)
        {
            var fretDistance = Distance(other);
            return fretDistance > MaxStrech;
        }

        public virtual Fret RaiseOctave()
        {
            return new Fret(guitarString, fret + Octave);
        }

        protected virtual bool Equals(Fret other)
        {
            return SameString(other) && fret == other.fret;
        }

        protected bool SameString(Fret other)
        {
            return Equals(guitarString, other.guitarString);
        }

        private int Distance(Fret other)
        {
            return fret - other.fret;
        }
    }
}