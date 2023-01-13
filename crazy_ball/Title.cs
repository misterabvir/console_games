namespace crazy_ball;

public class Title :GameElement
{   
    public Title()
    {
        _left = Settings.TitleCoords.Left;
        _top = Settings.TitleCoords.Top;
    }
    public override void Begin()
    {
        Console.SetCursorPosition(_left, _top);
        Console.WriteLine("Title");   
    }
    public override void Update(){}
    public override void Draw(){}
    public override void End(){}
}