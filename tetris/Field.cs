namespace TetrisGame;

public class Field : Singleton<Field>
{
    
    public int Max => lines.Max();
    private int[,] cells = new int[0, 0];
    private int[] lines = new int[0];
    private bool wasRemove = false;

    public delegate void FieldEvent();
    public event FieldEvent? OnBurn; 
    public event FieldEvent? OnRemove; 

    public override void Init()
    {
        size = Settings.SizeField;
        position = Settings.PositionField;
        cells = new int[size.height, size.width];       
        CheckLines();
        symbol = Settings.CellFieldSymbol;
    }

    public override void Draw()
    {                
        
        for (int row = 0; row < size.height; row++)
        {
            for (int col = 0; col < size.width; col++)
            {
                Console.SetCursorPosition(position.left + col, position.top + row);
                if (cells[row, col] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(symbol[0]);
                }
                else if (wasRemove && cells[row, col] == 0)
                 {
                    Console.ForegroundColor = default(ConsoleColor);
                    Console.Write(symbol[0]);
                 }
            }
        }
        
        wasRemove = false;
    }

    public bool IsCollide(int[,] shape, int left, int top)
    {
        for (int row = 0; row < shape.GetLength(0); row++)
        {
            for (int col = 0; col < shape.GetLength(1); col++)
            {
                if (shape[row, col] == 1)
                {
                    if(top  - position.top  + row >= cells.GetLength(0)) return true;
                    if(left - position.left + col >= cells.GetLength(1)) return true;                    
                    if (cells[top - position.top + row, left - position.left + col] == 1)
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
                    cells[shape.Position.Top - position.top + row, shape.Position.Left - position.left + col] = 1;
                }
            }
        }
       OnBurn?.Invoke();
       
        CheckLines();
    }

    public void CheckLines()
    {
        lines = new int[size.height];
        for (int row = 0; row < cells.GetLength(0); row++)
        {
           for (int col = 0; col < cells.GetLength(1); col++)
           {
                if(cells[row, col] == 1) lines[row]++;
           } 
        }

        if(lines.Max() == cells.GetLength(1))
        {
            int index = lines.ToList().IndexOf(cells.GetLength(1));
            Remove(index);
            CheckLines();
        }
    }

    private void Remove(int index)
    {        
        while(index > 0)
        {
            for (int col = 0; col < cells.GetLength(1); col++)
            {   
                cells[index, col] = cells[index - 1, col];
            }

            index--;
        }

        for (int col = 0; col < cells.GetLength(1); col++)
        {   
            cells[0, col] = 0;
        }
        wasRemove = true;
        OnRemove?.Invoke();
    }
}
