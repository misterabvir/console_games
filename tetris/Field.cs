namespace TetrisGame;

public class Field : Singleton<Field>
{
    
    public int Max => _lines.Max();
    private int[,] _cells = new int[0, 0];
    private int[] _lines = new int[0];
    private bool _wasRemove = false;


    public override void Init()
    {
        _size = Settings.SizeField;
        _position = Settings.PositionField;
        _cells = new int[_size.height, _size.width];       
        CheckLines();
        _symbol = Settings.CellFieldSymbol;
    }

    public override void Draw()
    {                
        for (int row = 0; row < _size.height; row++)
        {
            for (int col = 0; col < _size.width; col++)
            {
                Console.SetCursorPosition(_position.left + col, _position.top + row);
                if (_cells[row, col] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(_symbol[0]);
                }
                else if (_wasRemove && _cells[row, col] == 0)
                 {
                    Console.ForegroundColor = default(ConsoleColor);
                    Console.Write(_symbol[0]);
                 }
            }
        }
        _wasRemove = false;
    }

    public bool IsCollide(int[,] shape, int left, int top)
    {
        for (int row = 0; row < shape.GetLength(0); row++)
        {
            for (int col = 0; col < shape.GetLength(1); col++)
            {
                if (shape[row, col] == 1)
                {
                    if(top  - _position.top  + row >= _cells.GetLength(0)) return true;
                    if(left - _position.left + col >= _cells.GetLength(1)) return true;                    
                    if (_cells[top - _position.top + row, left - _position.left + col] == 1)
                        return true;
                }
            }
        }
        return false;
    }
    
    public void BurnShape(Shape shape)
    {
        for (int row = 0; row < shape.Figure.GetLength(0); row++)
        {
            for (int col = 0; col < shape.Figure.GetLength(1); col++)
            {
                if (shape.Figure[row, col] == 1)
                {
                    _cells[shape.Position.Top - _position.top + row, shape.Position.Left - _position.left + col] = 1;
                }
            }
        }
        CheckLines();
    }

    public void CheckLines()
    {
        _lines = new int[_size.height];
        for (int row = 0; row < _cells.GetLength(0); row++)
        {
           for (int col = 0; col < _cells.GetLength(1); col++)
           {
                if(_cells[row, col] == 1) _lines[row]++;
           } 
        }

        if(_lines.Max() == _cells.GetLength(1))
        {
            int index = _lines.ToList().IndexOf(_cells.GetLength(1));
            Remove(index);
            CheckLines();
        }
    }

    private void Remove(int index)
    {
        while(index > 0)
        {
            for (int col = 0; col < _cells.GetLength(1); col++)
            {   
                _cells[index, col] = _cells[index - 1, col];
            }

            index--;
        }

        for (int col = 0; col < _cells.GetLength(1); col++)
        {   
            _cells[0, col] = 0;
        }
        _wasRemove = true;
    }
}
