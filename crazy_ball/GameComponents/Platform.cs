using System.Text;
namespace CrazyBall;

public class Platform : Singleton<Platform>
{
    object locker = new();
    
    private int x_speed = 0;

    private (int left, int top) _position = Settings.PlatformPosition;
    private int _length = 16;
    private StringBuilder sb = new StringBuilder();



    public void MoveLeft()
    {
        x_speed--;
        if(x_speed >= 0) x_speed = -1;
        if(x_speed < -3) x_speed = -3;
    }

    public void Stop()
    {
        x_speed = 0;
    }

    public void MoveRight()
    {
        x_speed ++;
        if(x_speed <= 0) x_speed = 1;
        if(x_speed > 3) x_speed = 3;
    }

    public override void Update()
    {
        _position.left += x_speed;
        if(_position.left > Settings.BorderSize.width - _length - 2 - Settings.BorderPosition.left)
            _position.left = Settings.BorderSize.width - _length - 2;
        if(_position.left < 2 - Settings.BorderPosition.left) _position.left = 2;
    }

    public bool IsPlatformCollide(int left, int top) => left >= _position.left && left <= _position.left + _length && top == _position.top;
    

    public override void Draw()
    {
        sb.Clear();
        sb.Append(new string(Settings.EmptySymbol[0], _position.left - 2));
        sb.Append(new string(Settings.FillSymbol[0], _length));
        sb.Append(new string(Settings.EmptySymbol[0], Settings.BorderSize.width - _position.left - _length - 2));
        Console.SetCursorPosition(2, _position.top);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(sb);
        Console.ResetColor();
    }
}
