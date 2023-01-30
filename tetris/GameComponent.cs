namespace TetrisGame;

public class GameComponent
{
    protected (int height, int width) _size;
    protected (int left, int top) _position;
    protected string[] _symbol = {""};
   
    public virtual void Init(){}   
    public virtual void Update(){}
    public virtual void Draw(){}

    
}
