namespace CrazyBall;

public class Command : Singleton<Command>
{
    public void MoveLeft()
    {
        Platform.Instance.MoveLeft();
    }

    public void MoveRight()
    {
        Platform.Instance.MoveRight();
    }

    public void Stop()
    {
        Platform.Instance.Stop();
    }
}
