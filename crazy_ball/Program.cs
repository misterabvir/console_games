using System;

namespace crazy_ball;

public class Program
{

    static void Main()
    {
        Field field = new Field();

        while (true)
        {
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine(field);
            field.Update();
        }
    }



 
}