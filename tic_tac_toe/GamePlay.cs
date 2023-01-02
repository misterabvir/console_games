namespace tic_tac_toe;

///<summary>
/// Игровая механика
///</summary>
public class GamePlay
{
    private Player _player1 = new Player(CellValue.CROSS); 
    private Player _player2 = new Player(CellValue.ZERO); 
    private Player _currentPlayer = new Player(" "); 
    private Field _field = new Field();
    private Random _rand = new Random();
    private Player FirstPlayer => _rand.Next(0,1) == 0 ? _player1 : _player2;
    private Player NextPlayer => _currentPlayer == _player2 ? _player1 : _player2;    
    private bool GameOver => _field.IsComplete || _field.Full;
    
    ///<summary>
    /// Новая игра
    ///</summary>
    public void NewGame()
    {
        _field = new Field();
        _currentPlayer = FirstPlayer;
        do{
            do
            {
                Console.Clear();
                Console.WriteLine($"Player \'{_currentPlayer.Sign}\' move next");
                Console.WriteLine(_field);
                Console.Write("Select Index:");
                if(int.TryParse(Console.ReadLine(), out int input) && input >= 0 && input < Field.AmountOfCells && _field.CanSign(input))
                {
                    _field.SetValue(input, _currentPlayer.Sign);                
                    break;   
                }
                continue;
            } while (true);
            _currentPlayer = NextPlayer;
        }while(!GameOver);
    }


}