using System;
namespace BlackJack2
{
    public class Game
    {
        public void Start()
        {
            while(true)
            {
                new GamePlay().Start();
                Console.SetCursorPosition(Settings.PositionAgainText.left, Settings.PositionAgainText.top);
                Console.Write("Do you wanna play again? ");
                if(Console.ReadLine()?.ToUpper() != "Y") break;
            }
        }
    }
}