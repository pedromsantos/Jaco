using System.Collections.Generic;
using FluentAssertions;
using Jaco.Chords;
using Jaco.Guitar;
using Jaco.Notes;
using Xunit;

namespace JacoTests.Guitar
{
    public class ClosedFretMapperShould
    {
        public static TheoryData<Chord, GuitarString, IEnumerable<Fret>> MapChordOnBassString 
            => new TheoryData<Chord, GuitarString, IEnumerable<Fret>>
            {
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Sixth,
                    new [] {
                        new Fret(GuitarString.Sixth, 8),
                        new Fret(GuitarString.Fifth, 7),
                        new Fret(GuitarString.Fourth, 5)
                    }
                },
                {
                    new Chord(Note.C, ChordFunction.Major),
                    GuitarString.Fifth,
                    new [] {
                        new Fret(GuitarString.Fifth, 15),
                        new Fret(GuitarString.Fourth, 14),
                        new Fret(GuitarString.Third, 12)
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
                    GuitarString.Third,
                    new [] {
                        new Fret(GuitarString.Third, 5),
                        new Fret(GuitarString.Second, 5),
                        new Fret(GuitarString.First, 3)
                    }
                },

                {
                    new Chord(Note.F, ChordFunction.Major),
                    GuitarString.Sixth,
                    new [] {
                        new Fret(GuitarString.Sixth, 13),
                        new Fret(GuitarString.Fifth, 12),
                        new Fret(GuitarString.Fourth, 10)
                    }
                },
                {
                    new Chord(Note.FSharp, ChordFunction.Major),
                    GuitarString.Sixth,
                    new [] {
                        new Fret(GuitarString.Sixth, 14),
                        new Fret(GuitarString.Fifth, 13),
                        new Fret(GuitarString.Fourth, 11)
                    }
                },
                {
                    new Chord(Note.D, ChordFunction.Major7),
                    GuitarString.Fourth,
                    new [] {
                        new Fret(GuitarString.Fourth, 12),
                        new Fret(GuitarString.Third, 11),
                        new Fret(GuitarString.Second, 10),
                        new Fret(GuitarString.First, 9),
                    }
                },
                {
                    new Chord(Note.EFlat, ChordFunction.Major7),
                    GuitarString.Fourth,
                    new [] {
                        new Fret(GuitarString.Fourth, 13),
                        new Fret(GuitarString.Third, 12),
                        new Fret(GuitarString.Second, 11),
                        new Fret(GuitarString.First, 10),
                    }
                },
                {
                    new Chord(Note.E, ChordFunction.Major7),
                    GuitarString.Fourth,
                    new [] {
                        new Fret(GuitarString.Fourth, 14),
                        new Fret(GuitarString.Third, 13),
                        new Fret(GuitarString.Second, 12),
                        new Fret(GuitarString.First, 11),
                    }
                },
                {
                    new Chord(Note.F, ChordFunction.Major7),
                    GuitarString.Fourth,
                    new [] {
                        new Fret(GuitarString.Fourth, 15),
                        new Fret(GuitarString.Third, 14),
                        new Fret(GuitarString.Second, 13),
                        new Fret(GuitarString.First, 12),
                    }
                },
                {
                    new Chord(Note.C, ChordFunction.Major7).ToDrop2(),
                    GuitarString.Fifth,
                    new [] {
                        new Fret(GuitarString.Fifth, 3),
                        new Fret(GuitarString.Fourth, 5),
                        new Fret(GuitarString.Third, 4),
                        new Fret(GuitarString.Second, 5),
                    }
                },
                {
                    new Chord(Note.A, ChordFunction.Major7).ToDrop2(),
                    GuitarString.Fifth,
                    new [] {
                        new Fret(GuitarString.Fifth, 12),
                        new Fret(GuitarString.Fourth, 14),
                        new Fret(GuitarString.Third, 13),
                        new Fret(GuitarString.Second, 14),
                    }
                },
            };

        [Theory, MemberData(nameof(MapChordOnBassString))]
        public void MapChord(Chord chordToMap, GuitarString bassString, IEnumerable<Fret> expectedFrets)
        {
            var mapper = new ClosedFretMapper();
            var frets = mapper.Map(chordToMap, bassString);

            frets.Should().ContainInOrder(expectedFrets);
        }
    }
}