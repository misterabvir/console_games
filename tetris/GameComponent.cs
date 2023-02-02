namespace TetrisGame;

public class GameComponent
{
    protected (int height, int width) size;
    protected (int left, int top) position;
    protected string[] symbol = {""};
   
    ///<summary>Initialization before start loop</summary>
    public virtual void Init(){}      
    ///<summary>Loop Update</summary>
    public virtual void Update(){}
    ///<summary>Loop Draw</summary>
    public virtual void Draw(){}   
}
