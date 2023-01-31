namespace CrazyBall;

public class Block : GameComponent
{
    int[,] _block = new int[2,8];
    (int x, int y) _position = (0,0);
    (int w, int h) _size = (8, 2);
    public (int left, int top) Position 
    {
        get => _position;
        set => _position = value;
    }

    private ConsoleColor[] _colors = {  ConsoleColor.White, 
                                        ConsoleColor.Magenta,
                                        ConsoleColor.DarkRed,
                                        ConsoleColor.DarkYellow,
                                        ConsoleColor.Green,
                                        ConsoleColor.Blue,
                                        ConsoleColor.Gray,
                                        ConsoleColor.Yellow};

    private ConsoleColor _currentColor =default(ConsoleColor);

    private bool _isNeedDraw = true;

    public bool Enabled
    {
        get => _block[0,0] == 1;
        set
        {
            for (int row = 0; row < _block.GetLength(0); row++)
            {
                for (int col = 0; col < _block.GetLength(1); col++)
                {
                    _block[row, col] = value ? 1 : 0;
                }
            }
            if(value)
            { 
                _isNeedDraw = true;
                SetRandom();
            }

        }
    }

    public bool IsCollide(int x, int y)
    {
        bool isCollide = x >= _position.x && x <= _position.x + _size.w &&
                         y >= _position.y && y <= _position.y + _size.h;
        return isCollide && Enabled;
    }

    public override void Draw()
    {
        Console.ForegroundColor = _currentColor;
        for (int row = 0; row < _block.GetLength(0); row++)
        {
            for (int col = 0; col < _block.GetLength(1); col++)
            {
                Console.SetCursorPosition(_position.x + col, _position.y + row);
                if(_isNeedDraw)
                    Console.Write(_block[row, col] == 1 ? Settings.FillSymbol : Settings.EmptySymbol);                   
            }
        }
        if(!Enabled) _isNeedDraw = false;
        Console.ResetColor();
    }

    private void SetRandom()
    {
        _currentColor = _colors[new Random().Next(0, 8)];        
    }
}
