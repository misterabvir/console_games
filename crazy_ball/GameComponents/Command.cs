namespace CrazyBall;

public class Command : Singleton<Command>
{
    public delegate void CommandEvent();
    public  event CommandEvent? OnLeftEvent;
    public  event CommandEvent? OnRightEvent;
    public  event CommandEvent? OnStopEvent;
    
    public void MoveLeft()
    {
        OnLeftEvent?.Invoke();
    }

    public void MoveRight()
    {
        OnRightEvent?.Invoke();
    }

    public void Stop()
    {
       OnStopEvent?.Invoke();
    }
}
