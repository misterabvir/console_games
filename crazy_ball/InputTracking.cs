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
                case ConsoleKey.RightArrow:                    
                    Game.Entity.Platform.MoveRight = true;
                    break;

                case ConsoleKey.LeftArrow:                   
                    Game.Entity.Platform.MoveLeft = true;
                    break;

                case ConsoleKey.Escape:
                    break;

                default: break;
            }
        }
    }
}