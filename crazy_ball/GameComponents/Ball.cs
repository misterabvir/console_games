namespace CrazyBall
{
    public class Ball : Singleton<Ball>
    {
   
        (int left, int top) _position = Settings.BallPosition;
        (int left, int top) _newPosition = Settings.BallPosition;
        (int x, int y) _speed = Settings.BallSpeed;

        public override void Update()
        {
            
            
            if(_position.left  +_speed.x < Settings.BorderPosition.left + 2 
                || _position.left + _speed.x > Settings.BorderSize.width - Settings.BorderPosition.left - 3
                || Platform.Instance.IsPlatformCollide(_position.left + _speed.x, _position.top)
                || Blocks.Instance.IsCollide(_position.left + _speed.x, _position.top))
            {
                _speed.x *= -1;
            }
            if(_position.top  + _speed.y < Settings.BorderPosition.top + 2 
                || _position.top + _speed.y > Settings.BorderSize.height - Settings.BorderPosition.top - 2
                || Platform.Instance.IsPlatformCollide(_position.left, _position.top + _speed.y)
                || Blocks.Instance.IsCollide(_position.left, _position.top + _speed.y))
            {
                _speed.y *= -1;
            }
            _newPosition.left += _speed.x;
            _newPosition.top  += _speed.y;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_position.left, _position.top);
            Console.Write(Settings.EmptySymbol);
            _position.left = _newPosition.left;
            _position.top = _newPosition.top;
            Console.SetCursorPosition(_position.left, _position.top);
            Console.Write(Settings.BallSymbol);
        }
    }
}