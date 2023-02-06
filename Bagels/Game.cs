namespace Bagels;

public class Game
{  
    public void Start()
    {
        do{
            new BagelsGamePlay().Start();
            Console.Write(Settings.Texts[(int)Keys.AGAIN]);
        }while(Console.ReadLine()?.ToUpper() == Settings.Texts[(int)Keys.YES]);
    }
}