using System.Collections.Generic;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Guitar;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Guitar
{
    public class FretMapperShould
    {
        public static TheoryData<Chord, GuitarString, IEnumerable<Fret>> MapChordOnBassString 
            => new TheoryData<Chord, GuitarString, IEnumerable<Fret>>
            {
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Third, 
                    new [] {
                            new Fret(GuitarString.Third, 5),
                            new Fret(GuitarString.Second, 5),
                            new Fret(GuitarString.First, 3)
                    }
                },
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Fourth,
                    new [] {
                            new Fret(GuitarString.Fourth, 10),
                            new Fret(GuitarString.Third, 9),
                            new Fret(GuitarString.Second, 8)
                    }
                },
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Fifth,
                    new [] {
                            new Fret(GuitarString.Fifth, 3),
                            new Fret(GuitarString.Fourth, 2),
                            new Fret(GuitarString.Third, 0)
                    }
                },
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Sixth,
                    new [] {
                            new Fret(GuitarString.Sixth, 8),
                            new Fret(GuitarString.Fifth, 7),
                            new Fret(GuitarString.Fourth, 5)
                    }
                },
            };

        [Theory, MemberData(nameof(MapChordOnBassString))]
        public void MapChord(Chord chordToMap, GuitarString bassString, IEnumerable<Fret> expectedFrets)
        {
            var mapper = new FretMapper(new NoStringSkipper());
            var frets = mapper.Map(chordToMap, bassString);

            frets.Should().ContainInOrder(expectedFrets);
        }
    }
}