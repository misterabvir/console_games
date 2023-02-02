namespace CrazyBall
{
    public class Ball : Singleton<Ball>
    {
        private ConsoleColor currentColor = ConsoleColor.White;
        (int left, int top) position = Settings.BallPosition;
        (int left, int top) newPosition = Settings.BallPosition;
        (int x, int y) speed = Settings.BallSpeed;

        public override void Init()
        {
            Blocks.Instance.OnCollide += CollideEvent;
        }

        private void CollideEvent(Block block, ConsoleColor color)
        {
            if(block!=null)
                currentColor = color;
        }

        public override void Update()
        {                        
            if(position.left  +speed.x < Settings.BorderPosition.left + 2 
                || position.left + speed.x > Settings.BorderSize.width - Settings.BorderPosition.left - 3
                || Platform.Instance.IsPlatformCollide(position.left + speed.x, position.top)
                || Blocks.Instance.IsCollide(position.left + speed.x, position.top))
            {
                speed.x *= -1;
            }
            if(position.top  + speed.y < Settings.BorderPosition.top + 2 
                || position.top + speed.y > Settings.BorderSize.height - Settings.BorderPosition.top - 2
                || Platform.Instance.IsPlatformCollide(position.left, position.top + speed.y)
                || Blocks.Instance.IsCollide(position.left, position.top + speed.y))
            {
                speed.y *= -1;
            }
            newPosition.left += speed.x;
            newPosition.top  += speed.y;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(position.left, position.top);
            Console.Write(Settings.EmptySymbol);
            position.left = newPosition.left;
            position.top = newPosition.top;
            Console.SetCursorPosition(position.left, position.top);
            Console.ForegroundColor = currentColor;
            Console.Write(Settings.BallSymbol);
        }
    }
}