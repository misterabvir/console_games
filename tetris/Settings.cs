namespace TetrisGame;

public class Settings
{
    static public (int Left, int Top) PositionBorder => (0, 0);
    static public (int Height, int Width) SizeBorder => (34, 36);
    static public string[] WallFieldSymbol => new string[]{"█"};

    static public (int Left, int Top) PositionField => (2, 1);
    static public (int Height, int Width) SizeField => (32, 32);
    static public string[] CellFieldSymbol => new string[] {"█", "[", "]"};

    static public (int Left, int Top) PositionStatus=> (0, 35);
    static public (int Height, int Width) SizeStatus => (1, 20);
    static public string[] StatusSymbol => new string[] {"LEFT", "TURN", "RIGHT"};
    
}