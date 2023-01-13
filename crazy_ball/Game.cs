namespace crazy_ball;

public class Game
{
  
    private Field _field = new Field();
    private Title _title = new Title();
    private Platform _platform = new Platform();
    private GameStatus _status = new GameStatus();   
    private GameBehavior _behavior = GameBehavior.Behavior;

    public Game()
    {
        PreLoad();
        
        Load();

        Start();

        Stop();       
    }

    private void PreLoad()
    {
        Console.CursorVisible = false;
        Console.Clear(); 
    }

    private void Load()
    {
        _behavior.Add(_field);
        _behavior.Add(_title);
        _behavior.Add(_platform);
        _behavior.Add(_status);
    }

    private void Start()
    {
        _behavior.Start();
        InputTracking _input = new InputTracking();
        _input.Track();
    }
    
    private void Stop()
    {
        GameBehavior.Behavior.Stop();
        Console.SetCursorPosition(Settings.CursorEndGameCoords.Left, Settings.CursorEndGameCoords.Top);
        Console.CursorVisible = true;
    }
}