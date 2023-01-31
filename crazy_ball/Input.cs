namespace CrazyBall;

public class Input : Singleton<Input>
{
    public void Start()
    {
        var key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Escape)
        {
            // Thread.Sleep(100);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                break;
            }

            else if(key == ConsoleKey.LeftArrow)
            {
                Command.Instance.MoveLeft();
            }

            else if(key == ConsoleKey.RightArrow)
            {
                Command.Instance.MoveRight();
            }

            else if(key == ConsoleKey.DownArrow)
            {
                Command.Instance.Stop();
            }
        }
    }
}
