namespace crazy_ball;

public class Platform : GameElement
{
    
    public Direction Direction{get; set;} = Direction.RIGHT;
    
    private int _speed = Settings.PlatformDefaultSpeed;
    public int Speed
    {
        get {return _speed;}
        set
        {
            if(value >= 1 && value <= Settings.PlatformMaxSpeed) _speed = value;
        }
    }
    
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
        if(Direction == Direction.RIGHT)
        {           
            _currentPosition += _speed;
            if(_currentPosition >= (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length))
            {
                _currentPosition = (Settings.FieldLength - Settings.FieldBorderSize * 2 - _length);
            }
        }        
        if(Direction == Direction.LEFT)
        {
            _currentPosition -= _speed;
            if(_currentPosition < 0)
            {
                _currentPosition = 0;
            }
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

    public bool IsUnderTheBall(Ball ball) => ball.Y == 19 && ball.X >= _currentPosition && ball.X <= (_currentPosition + _length);
    
}