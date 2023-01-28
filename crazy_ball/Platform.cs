namespace crazy_ball;

public class Platform : GameElement
{
    private bool _moveRight;
    private bool _moveLeft;
    
    public bool MoveRight
    {
        get
        {
            return _moveRight;
        }
        set
        {
            if(!value || (value && !_moveLeft)) 
                _moveRight = value;
        }
    }
    public bool MoveLeft
    {
        get
        {
            return _moveLeft;
        }
        set
        {
            if(!value || (value && !_moveRight)) 
                _moveLeft = value;
        }
    }
    

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
        if(MoveRight)
        {           
            _currentPosition += _speed;
            if(_currentPosition >= (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length))
            {
                _currentPosition = (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length);
            }
        }        
        if(MoveLeft)
        {
            _currentPosition -= _speed;
            if(_currentPosition < 0)
            {
                _currentPosition = 0;
            }
        }

        MoveLeft = MoveRight = false;
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