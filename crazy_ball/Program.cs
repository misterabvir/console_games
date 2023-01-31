using System;

namespace CrazyBall;
public class Program
{
    static void Main()
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        new Game().Start();
        Input.Instance.Start();
        Console.CursorVisible = true;
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}