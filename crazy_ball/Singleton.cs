namespace CrazyBall;

public class Singleton<T> : GameComponent where T: new()
{
    private static readonly Lazy<T> _instance = new Lazy<T>(()=>new T());
    static public T Instance
    {
        get
        {
            return _instance.Value;
        }
    }
}
