namespace CrazyBall;

public class Border : Singleton<Border>
{
    private (int width, int height) _size = Settings.BorderSize;
    private (int left, int top) _position = Settings.BorderPosition;
    int[,] _border = new int[0, 0];


    public override void Init()
    {
        _border = new int[_size.height, _size.width];
        FillBorder();
    }

    private void FillBorder()
    {
        for (int row = 0; row < _size.height; row++)
        {
            for (int col = 0; col < _size.width; col++)
            {
                if(col <= 1 || row == 0 || col >= _size.width - 2 || row == _size.height - 1)
                    _border[row, col] = 1;
            }
        }
    }

    public override void Draw()
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int row = 0; row < _size.height; row++)
        {
            for (int col = 0; col < _size.width; col++)
            {
                if(_border[row, col] == 1)
                {
                    Console.SetCursorPosition(_position.left + col, _position.top + row);
                    Console.Write(Settings.FillSymbol);                   
                }
            }
        }
        Console.ResetColor();
    }
}
