namespace TetrisGame;

public class Border : Singleton<Border>
{
    private int[,] _borders = new int[0, 0];


    public override void Init()
    {
        _size = Settings.SizeBorder;
        _position = Settings.PositionBorder;
        _symbol = Settings.WallFieldSymbol;
        
        _borders = new int[_size.height, _size.width];
        
        for (int row = 0; row < _size.height; row++)
        {
            for (int col = 0; col < _size.width; col++)
            {
                if(col <= 1 || row == 0 || row == _size.height -  1 || col >= _size.width - 2)
                    _borders[row, col] = 1;
                else 
                    _borders[row, col] = 0;
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
                Console.SetCursorPosition(_position.left + col, _position.top + row);
                if(_borders[row, col] == 1)
                {
                    Console.Write(_symbol[0]);
                } 
            }
        }
    }
}
