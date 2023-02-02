namespace CrazyBall;

public class Border : Singleton<Border>
{
    private (int width, int height) size = Settings.BorderSize;
    private (int left, int top) position = Settings.BorderPosition;
    int[,] border = new int[0, 0];


    public override void Init()
    {
        border = new int[size.height, size.width];
        FillBorder();
    }

    private void FillBorder()
    {
        for (int row = 0; row < size.height; row++)
        {
            for (int col = 0; col < size.width; col++)
            {
                if(col <= 1 || row == 0 || col >= size.width - 2 || row == size.height - 1)
                    border[row, col] = 1;
            }
        }
    }

    public override void Draw()
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int row = 0; row < size.height; row++)
        {
            for (int col = 0; col < size.width; col++)
            {
                if(border[row, col] == 1)
                {
                    Console.SetCursorPosition(position.left + col, position.top + row);
                    Console.Write(Settings.FillSymbol);                   
                }
            }
        }
        Console.ResetColor();
    }
}
