namespace CrazyBall
{
    public class Game
    {
        private List<GameComponent> _components = new List<GameComponent>();

        public Game()
        {
           _components.Add(Border.Instance);
           _components.Add(Platform.Instance);
           _components.Add(Ball.Instance);
           _components.Add(Blocks.Instance);
        }

        public void Start()
        {
            Init();
            new Thread(() =>
            {
                while (true) 
                {
                    Update();
                    Thread.Sleep(Settings.SpeedGame);                             
                }
            }
            ).Start();
        }

        private void Init()
        {
            foreach (var item in _components)
            {
                item.Init();
            }
        }
        private void Update()
        {
            foreach (var item in _components)
            {
                item.Update();
                item.Draw();
            }
        }
    }

}