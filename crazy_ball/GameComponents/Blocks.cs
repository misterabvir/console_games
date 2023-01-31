namespace CrazyBall;
public class Blocks : Singleton<Blocks>
{
  private List<Block> _blocks = new List<Block>();
  private (int left, int top) _position = Settings.BlocksPosition;
  private int _offset = 10;



  public override void Init()
  {
    for (int c = 0; c <= 12; c++)
    {
      for (int r = 0; r < 2; r++)
      {
        _blocks.Add(new Block(){ Position = ( _position.left + c * 10, _position.top + r * 3), Enabled = true});
      }           
    }
  }

    
  public bool IsCollide(int x, int y)
  {
    foreach (var item in _blocks)
    {
        if(item.IsCollide(x, y)) 
        {
          item.Enabled = false;
          return true;        
        }
    }
    return false;
  }


  public override void Draw()
  {
      foreach(var item in _blocks)
          item.Draw();
  }
}
