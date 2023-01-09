namespace crazy_ball;

public class Cell
{
    public CellValue Value {get; set;} = CellValue.Empty;

    public override string ToString()
    {
        return ((char)Value).ToString();
    }
}