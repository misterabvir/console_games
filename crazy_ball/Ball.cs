namespace crazy_ball;

public class Ball : GameElement
{
    
    public int X => _left;
    public int Y => _top;
    
    public int XSpeed
    {
        get
        {
            return _xSpeed;
        }
        set
        {
            if(value >= -5 && value <= 5) _xSpeed = value;
        }
    }

    private int _xSpeed;


    private int _ySpeed;    
    private int _xLast;
    private int _yLast;



    public Ball()
    {
        SetDefault();
    }
    
    private void SetDefault()
    {
        _left = Settings.BallStartCoords.Left;
        _top  = Settings.BallStartCoords.Top;
        _xSpeed = Settings.BallSpeedHorizontal;
        _ySpeed = Settings.BallSpeedVertical;        
    }

    public override void Begin()
    {
        Console.SetCursorPosition(_left, _top);
        Console.Write('O');
    }
    public override void Update()
    {
        if(_left + _xSpeed < Settings.GameAreaLeft || _left + _xSpeed >= Settings.GameAreaRight) _xSpeed *= -1;  
        if(_top  + _ySpeed < Settings.GameAreaTop || _top  + _ySpeed >= Settings.GameAreaBottom) _ySpeed *= -1;  

        if(Game.Entity.Platform.IsUnderTheBall(this) == true)
        { 
            _ySpeed *= -1;
        }

        _xLast = _left;
        _yLast = _top;

        _left += _xSpeed;
        _top  += _ySpeed;
    }
    public override void Draw()
    {
        Console.SetCursorPosition(_xLast,_yLast);
        Console.Write(' ');        
        
        Console.SetCursorPosition(_left, _top);
        Console.Write('O');
    }
    public override void End(){}
}