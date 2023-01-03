namespace black_jack;

public class Print
{
    private ConsoleColor GetColor(Style style)
    {
        switch (style)
        {
            case Style.SIMPLE: return ConsoleColor.Gray;
            case Style.INFO: return ConsoleColor.Green;
            case Style.RESULT: return ConsoleColor.Yellow;
            default: return ConsoleColor.Gray;
        }
    }

    public void WriteLine(string str, Style style)
    {
        Console.ForegroundColor = GetColor(style);
        Console.WriteLine(str);
        Console.ForegroundColor = GetColor(Style.SIMPLE);
    }

    public void Write(string str, Style style)
    {
        Console.ForegroundColor = GetColor(style);
        Console.Write(str);
        Console.ForegroundColor = GetColor(Style.SIMPLE);
    }

    public void Clear() => Console.Clear();
}