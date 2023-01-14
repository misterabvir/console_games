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
        if(Game.Entity.Platform.Direction == Direction.LEFT)  Console.Write("LEFT ");
        if(Game.Entity.Platform.Direction == Direction.RIGHT) Console.Write("RIGHT");

        Console.Write(new string(' ', 10));
        Console.Write("SPEED: {0, 4}", Game.Entity.Platform.Speed);

        Console.Write(new string(' ', 10));
        Console.Write("BALL CORDS: X = {0, 4} Y = {1, 4}", Game.Entity.Ball.X, Game.Entity.Ball.Y);
        Console.Write(" COLLIDE: {0} ", Game.Entity.Platform.IsUnderTheBall(Game.Entity.Ball));
    }
    public override void End(){}
}