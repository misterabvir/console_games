using System.Text;
namespace crazy_ball;

public class Field : GameElement
{     
    public Field()
    {
        _left = Settings.FieldCoords.Left;
        _top = Settings.FieldCoords.Top;
    }

    public override void Begin()
    {

    }
    
    public override void Update()
    {
        for (int y = 0; y < Settings.FieldHigh; y++)
        {
            for (int x = 0; x < Settings.FieldLength; x++)
            {                
                if(x == 0 || y == 0 || x >= Settings.FieldLength - Settings.FieldBorderSize || y == Settings.FieldHigh - Settings.FieldBorderSize)
                {
                    Console.SetCursorPosition(x + _left, y + _top);
                    Console.Write('█');
                }
            }
        }

    }
    public override void Draw(){ }
    public override void End(){}
}