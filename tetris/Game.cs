namespace TetrisGame;

public class Game
{
    private List<GameComponent> components = new List<GameComponent>();
       
    public Game()
    {
        components.Add(Border.Instance);
        components.Add(Field.Instance);
        components.Add(Shape.Instance);
        components.Add(CommandStatus.Instance);
        components.Add(ScoreSystem.Instance);
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
        foreach (var item in components)
        {
            item.Init();        
        }
    }

    public void Update()
    {
        foreach (var item in components)
        {
            item.Update();           
            item.Draw();        
        }
    }
}
