namespace TetrisGame;

public class Border : Singleton<Border>
{
    private int[,] borders = new int[0, 0];

    public override void Init()
    {
        size = Settings.SizeBorder;
        position = Settings.PositionBorder;
        symbol = Settings.WallFieldSymbol;        
        borders = new int[size.height, size.width];        
        for (int row = 0; row < size.height; row++)
        {
            for (int col = 0; col < size.width; col++)
            {
                if(col <= 1 
                || row == 0 
                || row == size.height - Settings.HorizontalBorderSize 
                || col >= size.width - Settings.VerticalBorderSize)
                    borders[row, col] = 1;
                else 
                    borders[row, col] = 0;
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
                Console.SetCursorPosition(position.left + col, position.top + row);
                if(borders[row, col] == 1)
                {
                    Console.Write(symbol[0]);
                } 
            }
        }
    }
}
