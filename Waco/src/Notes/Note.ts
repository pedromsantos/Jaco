const enum Accident {
    Flat = -1,
    None = 0,
    Sharp = 1
}

const enum Pitch {
    C = 0,
    CSharp = 1,
    DFlat = 1,
    D = 2,
    DSharp = 3,
    EFlat = 3,
    E = 4,
    F = 5,
    FSharp = 6,
    GFlat = 6,
    G = 7,
    GSharp = 8,
    AFlat = 8,
    A = 9,
    ASharp = 10,
    BFlat = 10,
    B = 11
}

class Note {
    public static C: Note = new Note(Pitch.C, "C", Accident.None, 0);
    public static CSharp: Note = new Note(Pitch.CSharp, "C#", Accident.Sharp, 1);

    constructor(private note_pitch: Pitch, private note_name: String, private note_accident: Accident, private note_index: number) {
        this.note_pitch = note_pitch 
        this.note_name = name;
        this.note_accident = note_accident;
        this.note_index = note_index;
    }

    public name(): String {
        return this.note_name
    }

    public pitch(): number {
        return this.note_pitch
    }

    public static notes(): Array<Note> {
        return [
                Note.C,
                Note.CSharp];
    }

    public MeasureAbsoluteSemitones(other: Note): number {
            const octave: number = 12;
            const unisson:number  = 0;

            var distance = other.pitch() - this.pitch();

            return distance < unisson ? octave - distance*-1 : distance;
    }
 }