namespace TetrisGame;
public class Singleton<T> : GameComponent where T: new()
{
    //Синглтон с наследованием
    private static readonly Lazy<T> _instance = new Lazy<T>(()=>new T());
    static public T Instance
    {
        get
        {
            return _instance.Value;
        }
    }
}
