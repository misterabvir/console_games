namespace crazy_ball;

public abstract class GameElement
{
    protected int _left;
    protected int _top;

    public abstract void Begin();
    public abstract void Update();
    public abstract void Draw();
    public abstract void End();
} 