# Jaco - C# music library

Jaco is named after Jazz Musician [Jaco Pastorius](https://en.wikipedia.org/wiki/Jaco_Pastorius).

## Examples

These examples are taken from VS2015 C# interactive window
First load the Jaco.dll in C# interactive
```
>#r "PATH_TO_SOLUTION_FOLDER\Jaco\Jaco\bin\Debug\Jaco.dll"
```

### Notes

| Example                                     | Output                                          |
| ------------------------------------------- | ----------------------------------------------- |
| > Jaco.Note.A.Name                          | "A"                                             |
| > Jaco.Note.A.Flat().Name                   | "Ab"                                            |
| > Jaco.Note.A.Sharp().Name                  | "A#"                                            |
| > Jaco.Note.A == Jaco.Note.A                | true                                            |
| > Jaco.Note.A == Jaco.Note.C                | false                                           |
| > ReferenceEquals(Jaco.Note.A, Jaco.Note.C) | false                                           |

### Intervals

| Example                                                  | Output           |
| -------------------------------------------------------- | ---------------- |
| > Jaco.Note.A.IntervalWithOther(Jaco.Note.ASharp).Name   | "Minor second"   |
| > Jaco.Note.A.IntervalWithOther(Jaco.Note.B).Name        | "Major second"   |
| > Jaco.Note.A.Transpose(Jaco.Interval.MinorSecond).Name  | "Bb"             |
| > Jaco.Note.A.Transpose(Jaco.Interval.MajorSecond).Name  | "B"              |
| > Jaco.Interval.CreateIntervalFromDistance(1).Name       | "Minor second"   |

### Chords
#### Building chords
```csharp
var cmaj = new Jaco.Chord(Jaco.Note.C, Jaco.ChordFunction.Major)
```
| Example                                        | Output             |
| ---------------------------------------------- | -------------------|
| > cmaj.name                                    | "CMaj"             |
| > var noteNames = cmaj.NoteNames; > notenames; | {"C", "E", "G"}    |
| > cmaj.Lead.Name                               | "G"                |
| > cmaj.Bass.Name                               | "C"                |
