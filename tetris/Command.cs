namespace TetrisGame;
public class Command:Singleton<Command>
{
    
    
    public void MoveRight()
    {
        Shape.Instance.MoveRight();
    }

    public void MoveLeft()
    {
        Shape.Instance.MoveLeft();     
    }
    public void Turn()
    {
        Shape.Instance.Turn();  
    }
}
