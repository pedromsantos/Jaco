# Jaco - C# music library

Jaco is named after Jazz Musician [Jaco Pastorius](https://en.wikipedia.org/wiki/Jaco_Pastorius).

## Examples

These examples are taken from VS2015 C# interactive window
First load the Jaco.dll in C# interactive
```
>#r "PATH_TO_SOLUTION_FOLDER\Jaco\Jaco\bin\Debug\Jaco.dll"
```

### Notes

| Example                                              | Output                                          |
| ---------------------------------------------------- | ----------------------------------------------- |
|Jaco.Notes.Note.A.Name                                | "A"                                             |
|Jaco.Notes.Note.A.Flat().Name                         | "Ab"                                            |
|Jaco.Notes.Note.A.Sharp().Name                        | "A#"                                            |
|Jaco.Notes.Note.A == Jaco.Note.A                      | true                                            |
|Jaco.Notes.Note.A == Jaco.Note.C                      | false                                           |
|ReferenceEquals(Jaco.Notes.Note.A, Jaco.Notes.Note.C) | false                                           |

### Intervals

| Example                                                           | Output           |
| ----------------------------------------------------------------- | ---------------- |
|Jaco.Notes.Note.A.IntervalWithOther(Jaco.Notes.Note.ASharp).Name   | "Minor second"   |
|Jaco.Notes.Note.A.IntervalWithOther(Jaco.Notes.Note.B).Name        | "Major second"   |
|Jaco.Notes.Note.A.Transpose(Jaco.Notes.Interval.MinorSecond).Name  | "Bb"             |
|Jaco.Notes.Note.A.Transpose(Jaco.Notes.Interval.MajorSecond).Name  | "B"              |
|Jaco.Notes.Interval.CreateIntervalFromDistance(1).Name             | "Minor second"   |

### Scales
| Example                                          | Output                             |
| ------------------------------------------------ | ---------------------------------- |
| Jaco.Scales.CMajor.Name                          | "C Major"                          |
| Jaco.Scale.CMajor.I.Name                         | "C"                                |
| Scale.CMajor.DoesNoteBelongToScale(Note.ASharp)  | false                              |
| new TriadsHarmonizer(Scale.CMajor).I().Name      | "Cmaj"                             |
| new TriadsHarmonizer(Scale.AMinor).I().Name      | "Amin"                             |
| new SeventhsHarmonizer(Scale.CMajor).I().Name    | "Cmaj7"                            |

### Chords
#### Building chords
```csharp
var cmaj = new Jaco.Chords.Chord(Jaco.Note.C, Jaco.ChordFunction.Major)
```
| Example                                      | Output             |
| -------------------------------------------- | -------------------|
| cmaj.name                                    | "CMaj"             |
| var noteNames = cmaj.NoteNames; > notenames; | {"C", "E", "G"}    |
| cmaj.Lead.Name                               | "G"                |
| cmaj.Bass.Name                               | "C"                |
