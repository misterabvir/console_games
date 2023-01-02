namespace black_jack;

///<summary>
/// Игровая механика
///</summary>
public class GamePlay
{
    ///<summary>
    /// Старт игры
    ///</summary>
    public void GameStart()
    {
        HumanPlayer hPlayer = new HumanPlayer();
        AIPlayer aPlayer = new AIPlayer();
        do{            
            Deck deck = new Deck();
            deck.Shuffle();
            
            int playerScore = hPlayer.Playing(deck);
            
            if(playerScore > Rules.GAME_TARGET)         
            {
                Console.WriteLine(Messages.LOSE); 
                hPlayer.Money -= 50; 
                aPlayer.Money += 50;
            }
            else if(playerScore == Rules.GAME_TARGET)
            {
                Console.WriteLine(Messages.WIN); 
                hPlayer.Money += 50; 
                aPlayer.Money -= 50;
            }
            else
            {
                int aiScore = aPlayer.Playing(deck, playerScore);
                
                if(aiScore > Rules.GAME_TARGET)
                {
                    Console.WriteLine(Messages.WIN); 
                    hPlayer.Money += 50; 
                    aPlayer.Money -= 50;
                }
                else if (aiScore == playerScore)        {Console.WriteLine(Messages.DRAW);}
                else
                {
                    Console.WriteLine(Messages.LOSE); 
                    hPlayer.Money -= 50; 
                    aPlayer.Money += 50;
                }
            }

            Console.WriteLine($"GAME SCORE");
            Console.WriteLine($"HUMAN {hPlayer.Money}$ : {aPlayer.Money}$ AI");
            Console.WriteLine(Messages.AGAIN);
        }while(Console.ReadLine()?.ToUpper() == Messages.YES);

        Console.WriteLine(Messages.BYE);
    }
}