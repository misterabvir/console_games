namespace TetrisGame;

public class ScoreSystem: Singleton<ScoreSystem>
{
    public int score = 0;
    public override void Init()
    {
        Field.Instance.OnBurn += AddShapeBurnPoints; 
        Field.Instance.OnRemove += AddLineRemovePoints; 
    }

    public override void Draw()
    {
        Console.SetCursorPosition(Settings.ScoreStatusPosition.Left, 
                                Settings.ScoreStatusPosition.Top);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("SCORE {0:000000000}", score);
    }

    public void AddShapeBurnPoints()
    {
        score += Settings.ShapeBornPoints;
    }
    private void AddLineRemovePoints()
    {
        score += Settings.RemoveLinePoints;
    }


}
