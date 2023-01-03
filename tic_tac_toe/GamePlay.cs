namespace tic_tac_toe;

///<summary>
/// Игровая механика
///</summary>
public class GamePlay
{
    private Player _player1 = new Player(CellValue.CROSS); 
    private Player _player2 = new Player(CellValue.ZERO); 
    private Field _field = new Field();
    private Print _print = new Print();
    private Player _currentPlayer; 
    private Player NextPlayer => _currentPlayer == _player2 ? _player1 : _player2;    
    private bool GameOver => _field.IsComplete || _field.Full;

    ///<summary>
    /// Начало игры
    ///</summary>
    public void StartGame()
    {
        do
        {
            NewGame();
            ShowResultBlock();
        } while (Console.ReadLine()?.ToUpper() == Messages.CONFIRM);
    }

    private void NewGame()
    {
        _field = new Field();
        _currentPlayer = _player1;
        while(true)
        {            
            DoMove();
            
            if (!GameOver)
                _currentPlayer = NextPlayer;
            else
            {
                _print.Clear();
                if(_field.IsComplete)
                {
                    _print.WriteLine(String.Format(Messages.RESULT_WIN, _currentPlayer.Sign), Style.INFO);
                    _currentPlayer.SetWin();
                }
                else 
                    _print.WriteLine(Messages.RESULT_DRAW, Style.INFO);              
                break;
            }                
        }
    }

    private void DoMove()
    {
        while(true)
        {            
            ShowMoveBlock();
            if(int.TryParse(Console.ReadLine(), out int input) 
                                && input >= 0 
                                && input < Field.AmountOfCells 
                                && _field.CanSign(input))
            {
                _field.SetValue(input, _currentPlayer.Sign);                
                break;   
            }
        }
    }

    private void ShowMoveBlock()
    {
        _print.Clear();
        _print.WriteLine(string.Format(Messages.MOVE_TURN, _currentPlayer.Sign), Style.INFO);
        _print.WriteLine(_field.ToString(), Style.FIELD);
        _print.WriteLine(Messages.INPUT_NUMBER, Style.SIMPLE);
    }

    private void ShowResultBlock()
    {
        _print.WriteLine(_field.ToString(), Style.FIELD);
        _print.WriteLine(string.Format("SCORE: {0} {1} : {2} {3}",
                    _player1.Sign, _player1.Score, _player2.Score, _player2.Sign), Style.INFO);
        _print.WriteLine(Messages.PLAY_AGAIN, Style.SIMPLE);
    }
}