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
        do{
            Deck deck = new Deck();
            deck.Shuffle();

            int playerScore = PlayerTurn(deck);
            
            if(playerScore > Rules.GAME_TARGET)         Console.WriteLine(Messages.LOSE);
            else if(playerScore == Rules.GAME_TARGET)   Console.WriteLine(Messages.WIN);
            else
            {
                int aiScore = AITurn(deck, playerScore);
                
                if(aiScore > Rules.GAME_TARGET)         Console.WriteLine(Messages.WIN);
                else if (aiScore == playerScore)        Console.WriteLine(Messages.DRAW);
                else                                    Console.WriteLine(Messages.LOSE);
            }
            Console.WriteLine(Messages.AGAIN);
        }while(Console.ReadLine()?.ToUpper() == Messages.YES);

        Console.WriteLine(Messages.BYE);
    }

    ///<summary>
    /// Играет игрок
    ///</summary>
    private int PlayerTurn(Deck deck)
    {
        Hand playerHand = new Hand();
        playerHand.AddCard(deck.GetCard());
        
        do
        {
            Console.Clear();
            playerHand.AddCard(deck.GetCard());
            Console.WriteLine($"{Messages.PLAYERHAND} {playerHand}");

            if(playerHand.Cost() > Rules.GAME_TARGET)
                break;

            Console.WriteLine(Messages.CARD);
        } while (Console.ReadLine()?.ToUpper() == Messages.YES);
        
        return playerHand.Cost();
    }

    ///<summary>
    /// Играет AI
    ///</summary>
    private int AITurn(Deck deck, int min)
    {
        Hand aiHand = new Hand();
        aiHand.AddCard(deck.GetCard());
        do
        {
            aiHand.AddCard(deck.GetCard());
        } while (aiHand.Cost() < min);
        
        Console.WriteLine($"{Messages.AIHAND} {aiHand}");
        return aiHand.Cost();
    }
}