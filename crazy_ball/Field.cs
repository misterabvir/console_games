using System.Text;
namespace crazy_ball;

public class Field : Game
{
    const int START_Position_LEFT = 5;
    const int START_Position_TOP = 5;
    
    const int HIGH_SIZE = 21;
    const int LENGTH_SIZE = 70;
    
    
    public override void BeforeUpdate()
    {
        for (int y = 0; y < HIGH_SIZE; y++)
        {
            for (int x = 0; x < LENGTH_SIZE; x++)
            {                
                if(x <=1 || y == 0 || x >= LENGTH_SIZE - 2 || y == HIGH_SIZE - 1)
                    {
                        Console.SetCursorPosition(x + START_Position_LEFT, y + START_Position_TOP);
                        Console.Write('█');
                    }
            }
        }
    }
}