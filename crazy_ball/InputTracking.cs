namespace crazy_ball;

public class InputTracking
{
    public void Track()
    {
        var key = Console.ReadKey(true).Key;
        
        
        while (true)
        {
            
            key = Console.ReadKey(false).Key;
            if(key == ConsoleKey.Escape) break;
            if(key == ConsoleKey.RightArrow) Game.Entity.Platform.MoveRight();
            if(key == ConsoleKey.LeftArrow) Game.Entity.Platform.MoveLeft();

        }
    }
}