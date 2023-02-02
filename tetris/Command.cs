namespace TetrisGame;
public class Command:Singleton<Command>
{     
    public void MoveRight()
    {
        Shape.Instance.MoveRight();
        CommandStatus.Instance.Right = true;
    }

    public void MoveLeft()
    {
        Shape.Instance.MoveLeft(); 
        CommandStatus.Instance.Left = true;    
    }
    public void Turn()
    {
        Shape.Instance.Turn();
        CommandStatus.Instance.Turn = true;  
    }
}
