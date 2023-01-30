using System.Diagnostics;
namespace TetrisGame;

public class Input : Singleton<Input>
{
    public void Start()
    {
        var key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Escape)
        {
            Thread.Sleep(50);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
               Console.Clear();
                break;
            }
            if (key == ConsoleKey.LeftArrow) Command.Instance.MoveLeft();
            if (key == ConsoleKey.RightArrow) Command.Instance.MoveRight();
            if (key == ConsoleKey.Spacebar) Command.Instance.Turn();
        }
    }
}
