namespace TetrisGame;
public class Shape : Singleton<Shape>
{
    public (int Left, int Top) Position => position;
    public int[,] Figure => shape;

    private (int left, int top) nextPosition = (0, 0);
    private int[,] nextShape = new int[0, 0];
    private int[,] shape = new int[0, 0];
    private Random rand = new Random();
    private int pointer = 0;
    private int[][,] aroundShapes = { new int[,] { } };


    public override void Init()
    {
        GetRandomShape();
        symbol = Settings.CellFieldSymbol;
        nextPosition = position;
    }

    public override void Update()
    {
        MoveDown();
    }

    public override void Draw()
    {
        Paint(reset: true); // clean old
        position.left = nextPosition.left;
        position.top = nextPosition.top;
        shape = nextShape;
        Paint(reset: false); // draw new
    }

    public void Turn()
    {
        if (pointer + 1 < aroundShapes.Length) pointer++;
        else pointer = 0;
        int[,] newShape = aroundShapes[pointer];
        if (!Field.Instance.IsCollide(newShape, position.left, position.top))
            nextShape = newShape;
    
    }

    public void MoveLeft()
    {
        int nextLeft = position.left - Settings.HorizontalShapeStep;
        if (nextLeft > Settings.PositionField.Left - Settings.VerticalBorderSize )
            nextPosition.left = nextLeft;        
    }

    public void MoveRight()
    {
        int nextLeft = position.left + Settings.HorizontalShapeStep;
        int rightShapeCell = nextLeft + shape.GetLength(1);
        int rightBorderCell = Settings.SizeField.Width + Settings.VerticalBorderSize + Settings.PositionField.Left;        
        if (rightShapeCell < rightBorderCell) nextPosition.left = nextLeft;       
    }

    public void MoveDown()
    {
        var nextTopPosition = nextPosition.top + Settings.VerticalShapeStep;
        if (nextTopPosition >= (Settings.SizeField.Height - shape.GetLength(0) + 2 * Settings.HorizontalBorderSize + Settings.PositionField.Top) 
            || Field.Instance.IsCollide(shape, position.left, nextTopPosition))
        {
            Field.Instance.BurnShape(this);
            GetRandomShape();
            return;
        }
        nextPosition.top = nextTopPosition;
    }

    private void Paint(bool reset = false)
    {
        size = (shape.GetLength(0), shape.GetLength(1));
        for (int row = 0; row < shape.GetLength(0); row++)
        {
            for (int col = 0; col < shape.GetLength(1); col++)
            {
                Console.SetCursorPosition(position.left + col, position.top + row);
                if(reset) Console.Write(" ");
                else if (shape[row, col] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(symbol[0]);
                    Console.ForegroundColor = default(ConsoleColor);
                }
            }
        }
    }

    public void GetRandomShape()
    {
        aroundShapes = ShapeLibrary.Shapes[rand.Next(0, ShapeLibrary.Length)]; 
        pointer = rand.Next(0, aroundShapes.Length);
        shape = nextShape = aroundShapes[pointer];

        int left = (Settings.SizeBorder.Width - shape.GetLength(1)) / 2;
        left = left % 2 == 0 ? left : left - 1; //center
        
        position = nextPosition = 
            (left, Settings.PositionField.Top + Settings.HorizontalBorderSize);
    }
}