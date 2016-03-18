# Jaco - C# music library

Jaco is named after Jazz Musician [Jaco Pastorius](https://en.wikipedia.org/wiki/Jaco_Pastorius).

## Examples

These examples are taken from VS2015 C# interactive window
First load the Jaco.dll in C# interactive
```
>#r "PATH_TO_SOLUTION_FOLDER\Jaco\Jaco\bin\Debug\Jaco.dll"
```

### Notes

| Example                                                 | Output                                          |
| ------------------------------------------------------- | ----------------------------------------------- |
| > Jaco.Notes.Note.A.Name                                | "A"                                             |
| > Jaco.Notes.Note.A.Flat().Name                         | "Ab"                                            |
| > Jaco.Notes.Note.A.Sharp().Name                        | "A#"                                            |
| > Jaco.Notes.Note.A == Jaco.Note.A                      | true                                            |
| > Jaco.Notes.Note.A == Jaco.Note.C                      | false                                           |
| > ReferenceEquals(Jaco.Notes.Note.A, Jaco.Notes.Note.C) | false                                           |

### Intervals

| Example                                                              | Output           |
| -------------------------------------------------------------------- | ---------------- |
| > Jaco.Notes.Note.A.IntervalWithOther(Jaco.Notes.Note.ASharp).Name   | "Minor second"   |
| > Jaco.Notes.Note.A.IntervalWithOther(Jaco.Notes.Note.B).Name        | "Major second"   |
| > Jaco.Notes.Note.A.Transpose(Jaco.Notes.Interval.MinorSecond).Name  | "Bb"             |
| > Jaco.Notes.Note.A.Transpose(Jaco.Notes.Interval.MajorSecond).Name  | "B"              |
| > Jaco.Notes.Interval.CreateIntervalFromDistance(1).Name             | "Minor second"   |

### Keys
| Example                                  | Output                             |
| ---------------------------------------- | ---------------------------------- |
| > Jaco.ScalesScale.CMajor.Name           | "C Major"                          |

### Chords
#### Building chords
```csharp
var cmaj = new Jaco.Chirds.Chord(Jaco.Note.C, Jaco.ChordFunction.Major)
```
| Example                                        | Output             |
| ---------------------------------------------- | -------------------|
| > cmaj.name                                    | "CMaj"             |
| > var noteNames = cmaj.NoteNames; > notenames; | {"C", "E", "G"}    |
| > cmaj.Lead.Name                               | "G"                |
| > cmaj.Bass.Name                               | "C"                |
