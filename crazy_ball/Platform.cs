namespace crazy_ball;

public class Platform : GameElement
{
   

    private int _speed = Settings.PlatformDefaultSpeed;

    
    private int _length = 11;
    
    private int _currentPosition;

    public Platform()
    {
        _left = Settings.PlatformCoords.Left;
        _top = Settings.PlatformCoords.Top;
        _currentPosition = Settings.PlatformStart - _length/2;
    }

    public override void Begin(){}

    public override void Update()
    {        
    
    }

    public void MoveLeft()
    {
        
        if(_currentPosition - _speed < 0)
        {
            _currentPosition = 0;
        }   
        else 
        {
            _currentPosition -= _speed;
        }

    }

    public void MoveRight()
    {
        
        if(_currentPosition + _speed <= (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length))
        {
            _currentPosition += _speed;
        }
        else
        {
            _currentPosition = (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length);
        }
    }

    public override void Draw()
    {
        Console.SetCursorPosition(_left, _top);
        Console.Write(new String(' ', _currentPosition) 
                    + new String('#', _length) 
                    + new String(' ', (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length) - _currentPosition));
    }

    public override void End(){}

    public bool IsUnderTheBall(Ball ball) => ((ball.Y == 19 || ball.Y == 21) && ball.X >= _currentPosition && ball.X <= (_currentPosition + _length))
                                                ||((ball.Y == 20) && (ball.X+1 == _currentPosition || ball.X - 1 == (_currentPosition + _length)));
    
}