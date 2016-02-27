using System;
using System.Collections.Generic;
using System.Linq;
using Jaco.Notes;

namespace Jaco.Guitar
{
    public class GuitarString
    {
        public static readonly GuitarString First = new Lazy<GuitarString>(() => new GuitarString(Note.E)).Value;
        public static readonly GuitarString Second = new Lazy<GuitarString>(() => new GuitarString(Note.B)).Value;
        public static readonly GuitarString Third = new Lazy<GuitarString>(() => new GuitarString(Note.G)).Value;
        public static readonly GuitarString Fourth = new Lazy<GuitarString>(() => new GuitarString(Note.D)).Value;
        public static readonly GuitarString Fifth = new Lazy<GuitarString>(() => new GuitarString(Note.A)).Value;
        public static readonly GuitarString Sixth = new Lazy<GuitarString>(() => new GuitarString(Note.E)).Value;

        private GuitarString(Note note)
        {
            NoteOnOpenString = note;
        }

        public static IEnumerable<GuitarString> Values
        {
            get
            {
                yield return First;
                yield return Second;
                yield return Third;
                yield return Fourth;
                yield return Fifth;
                yield return Sixth;
            }
        }

        public Note NoteOnOpenString { get; }

        private int Ordinal
        {
            get
            {
                var index = 0;
                foreach (var element in Values)
                {
                    if (element == this)
                    {
                        return index;
                    }

                    index++;
                }

                return index;
            }
        }

        public static GuitarString StringFromIndex(int index)
        {
            return Values.ElementAt(index);
        }

        public int FretForNote(Note note)
        {
            return NoteOnOpenString.MeasureAbsoluteSemitones(note);
        }

        public GuitarString Previous()
        {
            return Ordinal == 0 ? First : Values.ElementAt(Ordinal - 1);
        }
    }
}