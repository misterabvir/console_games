namespace Bagels;

public enum Keys { LOOSE, WIN, PATH, FERMI, PICO, BAGELS, TRYING, AGAIN, YES };
public class Settings
{             
    static public string[] Texts => new string[] 
    {
        "You loose! I guess: ",
        "You win!",
        "Rules.txt",
        "\tFermi",
        "\tPico",
        "\tBagels",
        "Your {0} trying: ",
        "Do you wanna play again? (y/n): ",
        "Y",
    };

    static public int MaxTrying => 10;
}

