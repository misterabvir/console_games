namespace TetrisGame;

public class CommandStatus : Singleton<CommandStatus>
{
    private string spaces = "";
    string[] titles = { "LEFT", "RIGHT", "TURN" };

    public bool Left { get; set; }
    public bool Turn { get; set; }
    public bool Right { get; set; }

    public override void Init()
    {
        var lengthSpaces = ((Settings.SizeBorder.Width / titles.Length)
                        - (int)titles.Select(item => item.Length).Average()) / 2;
        spaces = new string(' ', lengthSpaces);
    }

    public override void Draw()
    {
        Console.SetCursorPosition(Settings.PositionStatus.Left, Settings.PositionStatus.Top);
        Console.ForegroundColor = Left ? ConsoleColor.Green : ConsoleColor.DarkGray;
        Console.Write("{0}{1}{0}", spaces, titles[0]);
        Console.ForegroundColor = Turn ? ConsoleColor.Green : ConsoleColor.DarkGray;
        Console.Write("{0}{1}{0}", spaces, titles[2]);
        Console.ForegroundColor = Right ? ConsoleColor.Green : ConsoleColor.DarkGray;
        Console.Write("{0}{1}{0}", spaces, titles[1]);
        Left = Turn = Right = false;
    }
}
