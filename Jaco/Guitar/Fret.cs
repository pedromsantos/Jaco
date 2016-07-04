using System;

namespace Jaco.Guitar
{
    public class Fret
    {
        private readonly GuitarString guitarString;
        private readonly int fret;

        private const int MaxStrech = 5;
        protected const int Octave = 12;

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

        protected bool Equals(Fret other)
        {
            return Equals(guitarString, other.guitarString) && fret == other.fret;
        }

        public bool ExceedsMaxStrech(Fret other)
        {
            var fretDistance = Distance(other);
            return fretDistance > MaxStrech;
        }

        public Fret RaiseOctave()
        {
            return new Fret(guitarString, fret + Octave);
        }

        private int Distance(Fret other)
        {
            return fret - other.fret;
        }
    }
}