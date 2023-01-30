namespace TetrisGame;
public class Shape : Singleton<Shape>
{
    public (int Left, int Top) Position => _position;
    private (int left, int top) _newPosition = (0, 0);
    public int[,] Figure => _shape;
    int[,] _newShape = new int[0, 0];
    int[,] _shape = new int[0, 0];

    private Random _rand = new Random();

    private Input _input = Input.Instance;
    private int _pointer = 0;
    private int[][,] _aroundShapes = { new int[,] { } };


    public override void Init()
    {
        GetRandomShape();
        _symbol = Settings.CellFieldSymbol;
        _newPosition = _position;
    }

    public override void Update()
    {
        MoveDown();
    }

    public void Turn()
    {
        if (_pointer + 1 < _aroundShapes.Length) _pointer++;
        else _pointer = 0;
        int[,] newShape = _aroundShapes[_pointer];
        if (!Field.Instance.IsCollide(newShape, _position.left, _position.top))
        {
            _newShape = newShape;
        }
    }

    public void MoveLeft()
    {
        if (_newPosition.left >= 4)
        {
            _newPosition.left -= 2;
        }
    }

    public void MoveRight()
    {
        if (_newPosition.left + 2 + _shape.GetLength(1) <= Settings.SizeField.Width + 2)
        {
            _newPosition.left += 2;
        }
    }

    public void MoveDown()
    {
        if (_newPosition.top + 1 >= Settings.SizeField.Height - _shape.GetLength(0) + 2 || Field.Instance.IsCollide(_shape, _newPosition.left, _newPosition.top + 1))
        {
            Field.Instance.BurnShape(this);
            GetRandomShape();
            return;
        }

        _newPosition.top++;
    }

    private void ResetDraw()
    {
        _size = (_shape.GetLength(0), _shape.GetLength(1));
        for (int row = 0; row < _shape.GetLength(0); row++)
        {
            for (int col = 0; col < _shape.GetLength(1); col++)
            {
                Console.SetCursorPosition(_position.left + col, _position.top + row);
                Console.Write(" ");
            }
        }
    }

    public override void Draw()
    {
        ResetDraw();
        _position.left = _newPosition.left;
        _position.top = _newPosition.top;

        _shape = _newShape;
        for (int row = 0; row < _shape.GetLength(0); row++)
        {
            for (int col = 0; col < _shape.GetLength(1); col++)
            {
                Console.SetCursorPosition(_position.left + col, _position.top + row);
                if (_shape[row, col] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(_symbol[0]);
                    Console.ForegroundColor = default(ConsoleColor);
                }
            }
        }
    }

    int[][][,] _shapes =
    {
        new int[][,]
        {
            new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 }
            }
        },

        new int[][,]
        {
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 0 }
            },
            new int[,]
            {
                { 1, 1, 0, 0 },
                { 1, 1, 0, 0 },
                { 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 0, 0, 0, 0, 1, 1 },
                { 1, 1, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1, 1, 1 },
                { 0, 0, 1, 1 },
                { 0, 0, 1, 1 }
            },
        },
        new int[][,]
        {
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 0, 0, 0, 0, 1, 1 }
            },
            new int[,]
            {
                { 0, 0, 1, 1 },
                { 0, 0, 1, 1 },
                { 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 0, 0 },
                { 1, 1, 0, 0 }
            },
        },
        new int[][,]
        {
            new int[,]
            {
                { 1, 1, 1, 1, 0, 0 },
                { 0, 0, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 0, 0, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 0, 0 }
            },
        },
        new int[][,]
        {
            new int[,]
            {
                { 0, 0, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 0, 0 }
            },
            new int[,]
            {
                { 1, 1, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 1, 1 }
            },
        },
        new int[][,]
        {
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1 },
                { 1, 1 },
                { 1, 1 },
                { 1, 1 }
            },
        }};
    
    public void GetRandomShape()
    {
        _pointer = 0;
        _aroundShapes = _shapes[_rand.Next(0, 6)];
        _shape = _newShape = _aroundShapes[_pointer];
        int left = (Settings.SizeBorder.Width - _shape.GetLength(1)) / 2;
        left = left % 2 == 0 ? left : left - 1;
        _position = _newPosition = (left, Settings.PositionField.Top + 2);
    }

    private int[,] GetTurnedShape()
    {
        int[,] turned = new int[_shape.GetLength(1), _shape.GetLength(0)];

        for (int row = 0; row < _shape.GetLength(0); row++)
        {
            for (int col = 0; col < _shape.GetLength(1); col++)
            {
                turned[col, row] = _shape[row, col];
            }
        }
        return turned;
    }
}