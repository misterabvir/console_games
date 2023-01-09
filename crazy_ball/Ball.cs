namespace crazy_ball;

public class Ball
{
    public int X { get; private set; }
    public int Y { get; private set; }  

    private int _x_speed=0;
    private int _y_speed=0;
    private Random _rand = new Random();

    private int _min_x, _max_x, _min_y, _max_y;

    public Ball(int min_x, int max_x, int min_y, int max_y)
    {
        _min_x = min_x;
        _min_y = min_y;
        _max_x = max_x;
        _max_y = max_y;
        
        X = _rand.Next(min_x, max_x);
        Y = _rand.Next(min_y, max_y);

        _x_speed = _rand.Next(-2, 3);
        _y_speed = _rand.Next(-1, 2);
    }

    public void Move()
    {
        if(X +_x_speed < _min_x || X + _x_speed > _max_x)
            _x_speed *= -1;
        if(Y +_y_speed < _min_x || Y + _y_speed > _max_y)
            _y_speed *= -1;
        
        X += _x_speed;
        Y += _y_speed;
    }
}