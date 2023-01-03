namespace black_jack;

///<summary>
/// Игровая механика
///</summary>
public class GamePlay
{
    private Print _print = new Print();
    private Deck _deck = new Deck();
    private HumanPlayer _hPlayer = new HumanPlayer();
    private AIPlayer _aPlayer = new AIPlayer();


    ///<summary>
    /// Старт игры
    ///</summary>
    public void GameStart()
    {
        do{            
            _deck = new Deck();
            _deck.Shuffle(); 

            OneGame();

            _print.WriteLine(string.Format(Messages.SCORE, _hPlayer.Money, _aPlayer.Money), Style.RESULT);
            _print.Write(Messages.AGAIN, Style.SIMPLE);
        }while(Console.ReadLine()?.ToUpper() == Messages.YES);
    }

    public void OneGame()
    {
            int playerScore = _hPlayer.Playing(_deck);                        
            if(playerScore > Rules.GAME_TARGET)         Show(Results.LOSE);
            else if(playerScore == Rules.GAME_TARGET)   Show(Results.WIN);
            else
            {
                int aiScore = _aPlayer.Playing(_deck, playerScore);               
                if(aiScore > Rules.GAME_TARGET)         Show(Results.WIN);
                else if (aiScore == playerScore)        Show(Results.DRAW);
                else                                    Show(Results.LOSE);
            }
    }

    

    private void Show(Results results)
    {
        switch(results)
        {
            case Results.WIN:
                _print.WriteLine(Messages.WIN, Style.RESULT); 
                _hPlayer.Money += 50; 
                _aPlayer.Money -= 50;
                break;
            case Results.DRAW: 
                _print.WriteLine(Messages.WIN, Style.RESULT); 
                break;            
            case Results.LOSE:
                _print.WriteLine(Messages.LOSE, Style.RESULT); 
                _hPlayer.Money -= 50; 
                _aPlayer.Money += 50;
                break;
        }
    }
}