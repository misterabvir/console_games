namespace Bagels;

public class BagelsGamePlay
{
    static private string rules = "";
    
    int[] guessesNumber = new int[3];
    int guess = 0; 

    int[] tryNumber = new int[3];
    
    int countOfTrying = 1;
    
    bool IsCorrect(int[] array) => array[0] != array[1] && array[0] != array[2] && array[1] != array[2];
    
    bool IsRight() => guessesNumber[0] == tryNumber[0] && guessesNumber[1] == tryNumber[1] && guessesNumber[2] == tryNumber[2];

    public void Start()
    {
        PrintRules();
        GuessNumber();
        do
        {
            TryingToAsk();
            CheckResult();
            countOfTrying++;
            if (IsRight() || countOfTrying > Settings.MaxTrying) break;
        } while (true);
        Console.WriteLine(IsRight() ? Settings.Texts[(int)Keys.WIN]: (Settings.Texts[(int)Keys.LOOSE] + guess));
    }

    void PrintRules()
    {
        if(rules == "")
            rules = new System.IO.StreamReader(Settings.Texts[(int)Keys.PATH]).ReadToEnd();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(rules);
        Console.ResetColor();
    }

    void GuessNumber()
    {
        do
        {
            guess = new Random().Next(100, 1000);
            if (TryParse(guess, out int[] array))
            {
                guessesNumber = array;
            }
        } while (!IsCorrect(guessesNumber));
    }

    bool TryParse(int number, out int[] array)
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

    void TryingToAsk()
    {
        int number = 0;
        do
        {
            Console.Write(Settings.Texts[(int)Keys.TRYING], countOfTrying);
        } while (!int.TryParse(Console.ReadLine(), out number) || !TryParse(number, out tryNumber) || !IsCorrect(tryNumber));
    }

    void CheckResult()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        bool noDigitsCorrect = true;
        for (int t = 0; t < 3; t++)
            for (int g = 0; g < 3; g++)
                if (guessesNumber[g] == tryNumber[t])
                {
                    if (g == t) Console.Write(Settings.Texts[(int)Keys.FERMI]);
                    else Console.Write(Settings.Texts[(int)Keys.PICO]);
                    noDigitsCorrect = false;
                }
        if (noDigitsCorrect) Console.Write(Settings.Texts[(int)Keys.BAGELS]);
        Console.ResetColor();
        Console.WriteLine();
    }
}