namespace black_jack;

public class Hand
{
    private List<Card> _cards = new List<Card>();

    public void AddCard(Card card) => _cards.Add(card);

    public override string ToString() =>  $"{string.Join('-', _cards.Select(c=>c.ToString()).ToArray())} : {Cost()} points";

    public int Cost()
    {
        int countAces = _cards.Where(c=>c.Value == "A").Count();
        int normal = _cards.Select(c=>c.Cost).Sum();

        if(countAces > 0) 
        {
            if(normal < Rules.GAME_TARGET) return normal;
            while(countAces > 0 && normal > Rules.GAME_TARGET)
            {    
                normal -= 10;
                countAces--;
            }
        }
        return normal;        
    }
}
