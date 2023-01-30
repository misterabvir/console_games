using System;

namespace TetrisGame;
public class Program
{
    static private Input _input = Input.Instance;
    static private Game _game = new Game();
    
    
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
        _game.Start();
        _input.Start(); 
        Console.CursorVisible = true;   
        
        Console.Clear();
        System.Diagnostics.Process.GetCurrentProcess().Kill(); // остановить все потоки!
    }
}


