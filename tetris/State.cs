namespace TetrisGame;

public class State : Singleton<State>
{

    public override void Draw()
    {
            Console.SetCursorPosition(Settings.PositionStatus.Left, Settings.PositionStatus.Top);

            // Console.ForegroundColor = Input.Instance.Left ? ConsoleColor.DarkGreen : ConsoleColor.DarkGray;
            // Console.Write(Settings.StatusSymbol[0]);
            // Console.ForegroundColor = Input.Instance.Turn ? ConsoleColor.DarkGreen : ConsoleColor.DarkGray;
            // Console.Write($" {Settings.StatusSymbol[1]} ");
            // Console.ForegroundColor = Input.Instance.Right ? ConsoleColor.DarkGreen : ConsoleColor.DarkGray;
            // Console.Write(Settings.StatusSymbol[2]);            
            // Console.ForegroundColor = Input.Instance.Right ? ConsoleColor.DarkGreen : ConsoleColor.DarkGray;
            Console.Write(Field.Instance.Max);
    }
}
