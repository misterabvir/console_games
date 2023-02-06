using BlackJack2.Cards;
namespace BlackJack2;

public class GamePlay
{
    enum Status { AIPLAY, HUMANPLAY, END };
    Status GameStatus = Status.HUMANPLAY;
    private string choice = string.Empty;
    Hand player = new Hand(isDealer: false);

    Hand ai = new Hand(isDealer: true);

    Deck deck = new Deck();

    public void Start()
    {
        GetHands();
        GameStatus = Status.HUMANPLAY;
        do
        {
            PrintField();
            GetMove();
            CheckResult();
        } while (GameStatus != Status.END);
    }

    private void GetHands()
    {
        player = new Hand(isDealer: false);
        ai = new Hand(isDealer: true);
        deck = new Deck();
        deck.Shuffle();
        ai.SetNewCard(deck.GetCard());
        ai.SetNewCard(deck.GetCard());
        player.SetNewCard(deck.GetCard());
        player.SetNewCard(deck.GetCard());
    }

    private void PrintField()
    {
        Console.Clear();
        PrintDealerText(position: Settings.PositionDealerText);
        ai.Print(position: Settings.PositionDealerHand);
        PrintHumanText(position: Settings.PositionHumanText);
        player.Print(position: Settings.PositionHumanHand);
        PrintHumanChoice(position: Settings.PositionHumanChoiceText);
    }

    private void GetMove()
    {
        if(GameStatus == Status.HUMANPLAY)
        {
            if (choice.ToUpper() == "H" || choice.ToUpper() == "D")
                player.SetNewCard(deck.GetCard());                      
            if (player.Points < Settings.MaxPointsGame && choice.ToUpper() == "H") 
                return;               
            GameStatus = Status.AIPLAY;
            ai.IsDealer = false;
        }
        else if (GameStatus == Status.AIPLAY)
        {
            if (player.Points < 21 && ai.Points < player.Points)
            {               
                Thread.Sleep(1000);
                ai.SetNewCard(deck.GetCard());               
            }
        }
        PrintField();
    }

    private void CheckResult()
    {
        Console.SetCursorPosition(Settings.PositionResultText.left, Settings.PositionResultText.top);
        if(GameStatus == Status.HUMANPLAY)
        {
            if(player.Points >= 21)
            {
                PrintResultGame("You win!!!");
                GameStatus = Status.END;
                return;
            }
        }
        else if(GameStatus == Status.AIPLAY)
        {
            if (player.Points == 21 || ai.Points > 21)
            {
                PrintResultGame("You win!!!");
                GameStatus = Status.END;
                return;
            }
            if (player.Points > 21 || ai.Points > player.Points) 
            {
                PrintResultGame("You lose");
                GameStatus = Status.END;
                return; 
            }                  
            if (ai.Points == player.Points)
            {
                PrintResultGame("Its draw!!!");
                GameStatus = Status.END;
                return;
            }

        }
    }

    private void PrintDealerText((int left, int top) position)
    {
        Console.SetCursorPosition(left: position.left, top: position.top);
        if (GameStatus == Status.HUMANPLAY)
        {
            Console.Write("AI say \"You turn now. Make a decision\"");
        }
        else
        {
            Console.Write("AI say \"Let see. I have : {0}\"", ai.Points);
        }
    }
    private void PrintHumanText((int left, int top) position)
    {
        Console.SetCursorPosition(left: position.left, top: position.top);
        Console.Write("PLAYER HAVE {0} POINTS", player.Points);
    }
    private void PrintHumanChoice((int left, int top) position)
    {
        if (GameStatus == Status.HUMANPLAY)
        {
            do
            {
                Console.SetCursorPosition(left: position.left, top: position.top);
                Console.Write("Your choice: (H)it (S)tand (D)ouble:     \b\b\b\b");
                choice = Console.ReadLine() ?? "";
            } while (choice.ToUpper() != "H" && choice.ToUpper() != "S" && choice.ToUpper() != "D");
        }
    }

    private void PrintResultGame(string message)
    {
        Console.SetCursorPosition(left: Settings.PositionGameResultText.left, top: Settings.PositionGameResultText.top);
        Console.Write(message);
    }
}