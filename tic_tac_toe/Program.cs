using System;

namespace tic_tac_toe;
public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GamePlay game = new GamePlay();
        game.StartGame();
    }
}

