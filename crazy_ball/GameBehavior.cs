namespace crazy_ball;

public class GameBehavior
{
    private CancellationTokenSource cts = new CancellationTokenSource();
    private List<GameElement> _elements = new List<GameElement>();

    static private GameBehavior? _behavior = null;
    static public GameBehavior Behavior
    {
        get
        {
            if(_behavior == null)
                _behavior = new GameBehavior();
            return _behavior;
        }
    }
    private GameBehavior(){}

    public void Start()
    {               
        
        OnBegin();
        new Thread(() =>
            {
                while(true)
                {
                    OnUpdate();
                    OnDrawUpdate();

                    Thread.Sleep(Settings.SpeedUpdate);
                }
            }).Start();
    }



    private void OnBegin()
    {
        foreach (var element in _elements)
        {
            element.Begin();
        }
    }
    private void OnUpdate()
    {
        foreach (var element in _elements)
        {
            element.Update();
        }
    }
    private void OnDrawUpdate()
    {
        foreach (var element in _elements)
        {
            element.Draw();
        }
    }
    private void OnEnd()
    {
        foreach (var element in _elements)
        {
            element.End();
        }
    }

    public void Add(GameElement element)
    {
        _elements.Add(element);
    }
}