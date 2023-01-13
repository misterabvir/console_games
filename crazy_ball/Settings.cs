namespace crazy_ball;

public class Settings
{
    static public Coords TitleCoords => new Coords(){Left = 0, Top = 0};
    static public Coords FieldCoords => new Coords(){Left = 0, Top = 2};
    static public Coords KeysCoords => new Coords(){Left = 0, Top = 23};    
    static public Coords PlatformCoords => new Coords(){Left = 1, Top = 20};
    static public Coords StatusCoords => new Coords(){Left = 0, Top = 23};
    static public Coords CursorEndGameCoords => new Coords(){Left = 0, Top = 26};

    static public int FieldLength => 70;
    static public int FieldHigh => 21;
    static public int FieldBorderSize => 1;

    static public int PlatformStart => FieldLength / 2;
    static public int PlatformDefaultSpeed => 2;
    static public int PlatformMaxSpeed => 10;
}