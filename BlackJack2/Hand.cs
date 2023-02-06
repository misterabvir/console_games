using BlackJack2.Cards;
namespace BlackJack2;

public class Hand
{
    private List<Card> cards = new List<Card>();
    public bool IsDealer = false;

    public int Points
    {
        get
        {
            var points = cards.Select(item => item.Points).Sum();
            var aces = cards.Where(item => item.IsAce).Count();
            while (aces > 0)
            {
                if (points + Settings.AcesPointBonus <= Settings.MaxPointsGame)
                    points += Settings.AcesPointBonus;
                aces--;
            }
            return points;
        }
    }


    public Hand(bool isDealer) => IsDealer = isDealer;

    public void SetNewCard(Card card) => cards.Add(card);

    public void Print((int left, int top) position)
    {

        Console.SetCursorPosition(left: position.left, top: position.top);
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].IsFlipped = false;
            if (IsDealer && i == 0) cards[0].IsFlipped = true;
            cards[i].Print((position.left, position.top));
            position.left += Settings.HorizontalCardOffset;
        }
    }
}
