namespace BlackJack2.Cards;

public class Deck
{
    private List<Card> cards = new List<Card>();

    
    public Deck()
    {
        ResetDeck();
    }

    public void ResetDeck()
    {
        for (int rank = 1; rank <= 13; rank++)
        {
            for (int suit = 0; suit < 4; suit++)
            {
                cards.Add(new Card((rank, suit)));
            }
        }
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 1; i < cards.Count; i++)
        {
            var index = rand.Next(0, cards.Count);
            var temp = cards[i];
            cards[i] = cards[index];
            cards[index] = temp;
        }
    }

    public Card GetCard()
    {
        if(cards.Count == 0) throw new Exception(message: "no any card in deck");
        Card card = cards[0];
        cards.Remove(card);
        return card;
    }
}
