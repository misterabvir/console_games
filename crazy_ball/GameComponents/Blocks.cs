namespace CrazyBall;
public class Blocks : Singleton<Blocks>
{
  private List<Block> blocks = new List<Block>();
  private (int left, int top) position = Settings.BlocksPosition;
  public delegate void Collide(Block block, ConsoleColor color);
  public event Collide? OnCollide;


  public override void Init()
  {
    for (int row = 0; row < Settings.CountOfBlackRows; row++)
    {
      for (int col = 0; col < Settings.CountOfBlackCols; col++)
      {
        blocks.Add(new Block(){ 
          Position = (position.left + col * Settings.LengthOffsetCols, 
                      position.top  + row * Settings.LengthOffsetRows), 
          Enabled = true});
      }           
    }
  }

    
  public bool IsCollide(int left, int top)
  {
    foreach (var item in blocks)
    {
        if(item.IsCollide(left, top)) 
        {
          item.Enabled = false;
          OnCollide?.Invoke(item, item.Color);
          return true;        
        }
    }
    return false;
  }


  public override void Draw()
  {
      foreach(var item in blocks)
          item.Draw();
  }
}
