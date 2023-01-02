namespace tic_tac_toe;

///<summary>
/// Игрок
///</summary>
public class Player
{
    ///<summary>
    /// Знак игрока
    ///</summary>
    public string Sign {get; private set;}
    
    ///<summary>
    /// Счет побед игрока
    ///</summary>
    public int Score{get; private set;}
    
    ///<summary>
    /// Создать игрока
    ///</summary>
    public Player(string sign)
    {
        Sign = sign;
        Score = 0;
    }

    ///<summary>
    /// Засчитать победу
    ///</summary>
    public void SetWin() 
    { 
        Score++;
    }

    ///<summary>
    /// Сбросить счет
    ///</summary>   
    public void Reset()
    { 
        Score = 0;
    }
}