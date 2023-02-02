namespace TetrisGame;

public class Settings
{
    static public (int Left, int Top) PositionBorder => (0, 2);
    static public (int Height, int Width) SizeBorder => (34, 36);
    static public string[] WallFieldSymbol => new string[] { "█" };
    static public int HorizontalBorderSize => 1;
    static public int VerticalBorderSize => 2;

    static public (int Left, int Top) PositionField => (PositionBorder.Left + 2, PositionBorder.Top + 1);
    static public (int Height, int Width) SizeField => (32, 32);
    static public string[] CellFieldSymbol => new string[] { "█", "[", "]" };

    static public (int Left, int Top) PositionStatus => (PositionBorder.Left, PositionBorder.Top + SizeBorder.Height);
    static public int HorizontalShapeStep => 2;
    static public int VerticalShapeStep => 1;

    static public (int Left, int Top) ScoreStatusPosition => (0, 1);
    static public int ShapeBornPoints => 100;
    static public int RemoveLinePoints => 10000;
}