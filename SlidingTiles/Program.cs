namespace SlidingTiles;

public class Program
{
    static public void Main(string[] args) 
    {
        var board = new Board();
        board.Shuffle();
        ConsoleKey key;
        do {
            board.Print();
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow) board.Move(Side.DOWN);
            if (key == ConsoleKey.DownArrow) board.Move(Side.UP);
            if (key == ConsoleKey.RightArrow) board.Move(Side.LEFT);
            if (key == ConsoleKey.LeftArrow) board.Move(Side.RIGHT);

        } while (key != ConsoleKey.Escape);
    }
}


