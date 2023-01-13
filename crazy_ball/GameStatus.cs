namespace crazy_ball;

public class GameStatus : GameElement
{
    public GameStatus()
    {
        _left = Settings.StatusCoords.Left;
        _top = Settings.StatusCoords.Top;
    }

    public override void Begin(){}
    public override void Update(){}

    public override void Draw()
    {
        Console.SetCursorPosition(_left, _top);
        if(Platform.Direction == Direction.LEFT)  Console.Write("LEFT ");
        if(Platform.Direction == Direction.RIGHT) Console.Write("RIGHT");
        Console.Write(new string(' ', 10));
        Console.Write("SPEED: {0, 4}", Platform.Speed);
    }
    public override void End(){}
}