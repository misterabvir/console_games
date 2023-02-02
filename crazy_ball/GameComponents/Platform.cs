using System.Text;
namespace CrazyBall;

public class Platform : Singleton<Platform>
{
    object locker = new();
    
    private int xSpeed = 0;

    private (int left, int top) position = Settings.PlatformPosition;
    private int length = 16;
    private StringBuilder sb = new StringBuilder();

    public override void Init()
    {
        Command.Instance.OnLeftEvent += MoveLeft;
        Command.Instance.OnRightEvent += MoveRight;
        Command.Instance.OnStopEvent += Stop;
    }

    public void MoveLeft()
    {
        xSpeed--;
        if(xSpeed >= 0) xSpeed = -1;
        if(xSpeed < -3) xSpeed = -3;
    }

    public void Stop()
    {
        xSpeed = 0;
    }

    public void MoveRight()
    {
        xSpeed++;
        if(xSpeed <= 0) xSpeed = 1;
        if(xSpeed > 3) xSpeed = 3;
    }

    public override void Update()
    {
        
        position.left += xSpeed;
        if(position.left > Settings.BorderSize.width - length - 2 - Settings.BorderPosition.left)
            position.left = Settings.BorderSize.width - length - 2;
        if(position.left < 2 - Settings.BorderPosition.left) position.left = 2;
    }

    public bool IsPlatformCollide(int left, int top) => left >= position.left && left <= position.left + length && top == position.top;
    

    public override void Draw()
    {
        sb.Clear();
        sb.Append(new string(Settings.EmptySymbol[0], position.left - 2));
        sb.Append(new string(Settings.FillSymbol[0], length));
        sb.Append(new string(Settings.EmptySymbol[0], Settings.BorderSize.width - position.left - length - 2));
        Console.SetCursorPosition(2, position.top);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(sb);
        Console.ResetColor();
    }
}
