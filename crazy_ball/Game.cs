namespace CrazyBall
{
    public class Game
    {
        private List<GameComponent> components = new List<GameComponent>();

        public Game()
        {
           components.Add(Border.Instance);
           components.Add(Platform.Instance);
           components.Add(Ball.Instance);
           components.Add(Blocks.Instance);
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
            foreach (var item in components)
            {
                item.Init();
            }
        }
        private void Update()
        {
            foreach (var item in components)
            {
                item.Update();
                item.Draw();
            }
        }
    }

}