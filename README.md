# Jaco - C# music library

Jaco is named after Jazz Musician [Jaco Pastorius](https://en.wikipedia.org/wiki/Jaco_Pastorius).

## Examples

These examples are taken from VS2015 C# interactive window
Load the Jaco.dll using something like this:
```
>#r "c:\\Users\pedro.santos\src\Jaco\Jaco\bin\Debug\Jaco.dll"
```
| Example                                     | Output                                          |
| ------------------------------------------- | ----------------------------------------------- |
| > Jaco.Note.A.Name                          | "A"              |                              |
| > Jaco.Note.A.Flat()                        | Note { Accident=Flat, Name="Ab", Pitch=AFlat }  |
| > Jaco.Note.A.Sharp()                       | Note { Accident=Sharp, Name="A#", Pitch=ASharp }|
| > Jaco.Note.A == Jaco.Note.A                | true                                            |
| > Jaco.Note.A == Jaco.Note.C                | false                                           |
| > ReferenceEquals(Jaco.Note.A, Jaco.Note.C) | false                                           |
