namespace crazy_ball;

public class Game
{
    private bool _work = true;
    public Game()
    {
        Console.Clear();
        BeforeUpdate();
        StartUpdate();
    }

    public virtual void BeforeUpdate(){}
    public virtual void Update(){}
    public virtual void AfterUpdate(){}

    private async Task StartUpdate()
    {
        await Task.Run(() =>
        {
            while (_work)
            {
                Update();                
                Task.Delay(100).Wait();
            }
            AfterUpdate();
        });
    }
}