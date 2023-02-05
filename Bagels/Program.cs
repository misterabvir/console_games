using System;

namespace Bagels;
public class Program
{
    static int[] guessesNumber = new int[3];
    static int[] tryNumber = new int[3];

    static void Main()
    {
        PrintRules();
        Guess();
        //Console.WriteLine("GUESS: " + string.Join(", ", guessesNumber));
        do
        {
            TryingToAsk();
            //Console.WriteLine("GUESS: " + string.Join(", ", tryNumber));
            CheckResult();
        } while (!IsRight());

    }

    static void PrintRules()
    {
        string rules = new System.IO.StreamReader("Rules.txt").ReadToEnd();
        Console.WriteLine(rules);
    }

    static void Guess()
    {
        int number = 0;
        do
        {
            number = new Random().Next(100, 1000);
            if (TryParse(number, out int[] array))
            {
                guessesNumber = array;
            }
        } while (!IsCorrect(guessesNumber));
    }

    static bool TryParse(int number, out int[] array)
    {
        array = new int[3];
        if (number < 100 || number >= 1000) return false;

        int index = 2;
        while (number > 0)
        {
            array[index--] = number % 10;
            number /= 10;
        }
        return true;
    }

    static bool IsCorrect(int[] array)
    {
        return array[0] != array[1] && array[0] != array[2] && array[1] != array[2];
    }

    static bool IsRight() => guessesNumber[0] == tryNumber[0] && guessesNumber[1] == tryNumber[1] && guessesNumber[2] == tryNumber[2];

    static void TryingToAsk()
    {
        int number = 0;
        do
        {
            Console.Write("Your trying: ");
        } while (!int.TryParse(Console.ReadLine(), out number) || !TryParse(number, out tryNumber) || !IsCorrect(tryNumber));
    }

    static void CheckResult()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (tryNumber[0] == guessesNumber[0]) Console.Write("Fermi ");
        if (tryNumber[1] == guessesNumber[1]) Console.Write("Fermi ");
        if (tryNumber[2] == guessesNumber[2]) Console.Write("Fermi ");
        if (tryNumber[0] == guessesNumber[1] || tryNumber[0] == guessesNumber[2]) Console.Write("Pico ");
        if (tryNumber[1] == guessesNumber[0] || tryNumber[1] == guessesNumber[2]) Console.Write("Pico ");
        if (tryNumber[2] == guessesNumber[0] || tryNumber[2] == guessesNumber[1]) Console.Write("Pico ");
        if (tryNumber[0] != guessesNumber[0] && tryNumber[0] != guessesNumber[1] && tryNumber[0] != guessesNumber[2]
        && tryNumber[1] != guessesNumber[0] && tryNumber[1] != guessesNumber[1] && tryNumber[1] != guessesNumber[2]
        && tryNumber[2] != guessesNumber[0] && tryNumber[2] != guessesNumber[1] && tryNumber[2] != guessesNumber[2]) Console.Write("Bagels ");
        Console.ResetColor();
        Console.WriteLine();
    }

}

git 