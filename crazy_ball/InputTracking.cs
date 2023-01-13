namespace crazy_ball;

public class InputTracking
{
    public void Track()
    {
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Platform.Speed++;                  
                    break;
                
                case ConsoleKey.DownArrow: 
                    Platform.Speed--;                   
                    break;
                
                case ConsoleKey.RightArrow:
                    Platform.Direction = Direction.RIGHT;
                    break;

                case ConsoleKey.LeftArrow:
                    Platform.Direction = Direction.LEFT;
                    break;

                case ConsoleKey.Escape:
                    break;

                default: break;
            }
        }
    }
}