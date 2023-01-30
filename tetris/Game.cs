namespace TetrisGame;

public class Game
{
    private List<GameComponent> _components = new List<GameComponent>();
       
    public Game()
    {
        _components.Add(Border.Instance);
        _components.Add(Field.Instance);
        _components.Add(Shape.Instance);
        _components.Add(State.Instance);
    }

    public void Start()
    {
        Init();
        
        new Thread(() =>
        {
            while (true) 
            {
                Update();
                Thread.Sleep(200);                             
            }
        }
        ).Start();
    }

    public void Init()
    {
        
        foreach (var item in _components)
        {
            item.Init();        
        }
    }

    public void Update()
    {
        foreach (var item in _components)
        {
            item.Update();           
            item.Draw();        
        }
    }
}
