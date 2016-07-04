using System.Collections.Generic;
using System.Linq;

namespace Jaco.Guitar
{
    public class ClosedFretMapper: FretMapper
    {
        protected override IList<Fret> AddFret(Fret newFret, IList<Fret> frets)
        {
            if (frets.Count > 0)
            {
                var lastFret = frets.Last();

                if (newFret.ExceedsMaxStrech(lastFret))
                {
                    frets =  RaiseOctavePreviousFrets(frets);
                }
                else if (lastFret.ExceedsMaxStrech(newFret))
                {
                    newFret = newFret.RaiseOctave();
                }
            }

            frets.Add(newFret);

            return frets;
        }

        protected override Fret CreateFret(GuitarString guitarString, int fret)
        {
            return new ClosedFret(guitarString, fret);
        }

        private IList<Fret> RaiseOctavePreviousFrets(IList<Fret> frets)
        {
            return frets.Select(f => f.RaiseOctave()).ToList();
        }
    }
}