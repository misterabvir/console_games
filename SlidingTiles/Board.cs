namespace SlidingTiles;

public class Board
{
    (int height, int length) sizeBoard => (4, 4);
    (int height, int length) sizeTile => (3, 7);
    (int left, int top) startPosition => (0, 1);
    (int row, int col) current = (3, 3);

    int[,] tilePointer;

    public bool IsRight 
    {
        get
        {
            for (int row = 0; row < sizeBoard.height; row++)
            {
                for (int col = 0; col < sizeBoard.length; col++)
                {
                   if(tilePointer[row, col] != row * sizeBoard.height + col + 1) return false;
                }
            }
            return true;
        }

    }


    public Board()
    {
        tilePointer = new int[sizeBoard.height, sizeBoard.length];
        FillTile();
    }

    private void FillTile()
    {
        for (int row = 0; row < sizeBoard.height; row++)
        {
            for (int col = 0; col < sizeBoard.length; col++)
            {
                tilePointer[row, col] = row * sizeBoard.height + col + 1;
            }
        }
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 0; i < 1000; i++)
        {
            Move((Side)rand.Next(0, 4));
        }
    }


    public void Print()
    {
        int left = 0, top = 0; 
        
        for (int row = 0; row < sizeBoard.height; row++)
        {
            for (int col = 0; col < sizeBoard.length; col++)
            {
                string[] tile = BitmapTiles.Tiles[tilePointer[row, col]];
                left = startPosition.left + col * sizeTile.length;
                top = startPosition.top + row * sizeTile.height;
                foreach (var str in tile)
                {
                    Console.SetCursorPosition(left, top++);
                    Console.Write(str);
                }
             }
        }
    }

    public void Move(Side side)
    { 
        switch (side) 
        {
            case Side.LEFT:
                if (current.col - 1 < 0) break;
                (tilePointer[current.row, current.col], tilePointer[current.row, current.col - 1]) =
                (tilePointer[current.row, current.col - 1], tilePointer[current.row, current.col]);
                current.col -= 1;
                break;
            case Side.RIGHT:
                if (current.col + 1 > tilePointer.GetLength(0) - 1) break;
                (tilePointer[current.row, current.col], tilePointer[current.row, current.col + 1]) =
                (tilePointer[current.row, current.col + 1], tilePointer[current.row, current.col]);
                current.col += 1;
                break;
            case Side.UP:
                if (current.row - 1 < 0) break;
                (tilePointer[current.row, current.col], tilePointer[current.row - 1, current.col]) =
                (tilePointer[current.row - 1, current.col], tilePointer[current.row, current.col]);
                current.row -= 1;
                break;
            case Side.DOWN:
                if (current.row + 1 > tilePointer.GetLength(1) - 1) break;
                (tilePointer[current.row, current.col], tilePointer[current.row + 1, current.col]) =
                (tilePointer[current.row + 1, current.col], tilePointer[current.row, current.col]);
                current.row += 1;
                break;
        }
        
       

    }
}


