namespace CrazyBall;

public class Settings
{
    static public int SpeedGame => 10;

    static public (int width, int height) BorderSize => (136, 40); 
    static public (int left, int top) BorderPosition => (0, 0);


    static public (int width, int height) PlatformSize => (16, 1);
    static public (int left, int top) PlatformPosition => (58, 34);

    static public (int left, int top) BallPosition => (66, 30);   
    static public (int x, int y) BallSpeed => (2, -1);   
    
    static public (int Left, int Top) BlocksPosition => (4, 2);

    static public string FillSymbol => "█";    
    static public string EmptySymbol => " ";
    static public string BallSymbol => "☻";



    static public int CountOfBlackRows => 3;
    static public int CountOfBlackCols => 13;
    static public int LengthOffsetCols => 10;
    static public int LengthOffsetRows=> 3;


}
