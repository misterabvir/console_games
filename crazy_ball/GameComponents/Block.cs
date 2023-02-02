namespace CrazyBall;

public class Block : GameComponent
{
    int[,] block = new int[2,8];
    (int x, int y) position = (0,0);
    (int w, int h) size = (8, 2);
    public (int left, int top) Position 
    {
        get => position;
        set => position = value;
    }

    private ConsoleColor[] colors = {  ConsoleColor.White, 
                                        ConsoleColor.Magenta,
                                        ConsoleColor.DarkRed,
                                        ConsoleColor.DarkYellow,
                                        ConsoleColor.Green,
                                        ConsoleColor.Blue,
                                        ConsoleColor.Gray,
                                        ConsoleColor.Yellow};

    private ConsoleColor currentColor = default(ConsoleColor);

    public ConsoleColor Color => currentColor;

    private bool isNeedDraw = true;

    public bool Enabled
    {
        get => block[0,0] == 1;
        set
        {
            for (int row = 0; row < block.GetLength(0); row++)
            {
                for (int col = 0; col < block.GetLength(1); col++)
                {
                    block[row, col] = value ? 1 : 0;
                }
            }
            if(value)
            { 
                isNeedDraw = true;
                SetRandom();
            }

        }
    }

    public bool IsCollide(int x, int y)
    {
        bool isCollide = x >= position.x && x <= position.x + size.w &&
                         y >= position.y && y <= position.y + size.h;
        return isCollide && Enabled;
    }

    public override void Draw()
    {
        Console.ForegroundColor = currentColor;
        for (int row = 0; row < block.GetLength(0); row++)
        {
            for (int col = 0; col < block.GetLength(1); col++)
            {
                Console.SetCursorPosition(position.x + col, position.y + row);
                if(isNeedDraw)
                    Console.Write(block[row, col] == 1 ? Settings.FillSymbol : Settings.EmptySymbol);                   
            }
        }
        if(!Enabled) isNeedDraw = false;
        Console.ResetColor();
    }

    private void SetRandom()
    {
        currentColor = colors[new Random().Next(0, 8)];        
    }
}
