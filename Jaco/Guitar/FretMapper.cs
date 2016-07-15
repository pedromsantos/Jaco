using System.Collections.Generic;
using Jaco.Chords;

namespace Jaco.Guitar
{
    public class FretMapper
    {
        private readonly IStringSkipper skipper;

        public FretMapper(IStringSkipper skipper)
        {
            this.skipper = skipper;
        }

        public IEnumerable<Fret> Map(Chord chord, GuitarString bassGuitarString)
        {
            IList<Fret> frets = new List<Fret>();
            var guitarString = bassGuitarString;

            foreach (var note in chord.Notes)
            {
                frets = AddFret(CreateFret(guitarString, guitarString.FretForNote(note)), frets);
                guitarString = guitarString.Previous();

                if (skipper.SkippString(note, chord))
                {
                    frets = AddFret(new Muted(guitarString), frets);
                    guitarString = guitarString.Previous();
                }
            }
           
            return frets;
        }

        protected virtual Fret CreateFret(GuitarString guitarString, int fret)
        {
            return new Fret(guitarString, fret);
        }

        protected virtual IList<Fret> AddFret(Fret newFret, IList<Fret> frets)
        {
            frets.Add(newFret);
            return frets;
        }
    }
}