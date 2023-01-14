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
                    Game.Entity.Platform.Speed++;                  
                    break;
                
                case ConsoleKey.DownArrow: 
                    Game.Entity.Platform.Speed--;                   
                    break;
                
                case ConsoleKey.RightArrow:
                    Game.Entity.Platform.Direction = Direction.RIGHT;
                    break;

                case ConsoleKey.LeftArrow:
                    Game.Entity.Platform.Direction = Direction.LEFT;
                    break;

                case ConsoleKey.Escape:
                    break;

                default: break;
            }
        }
    }
}