namespace black_jack;

public class AIPlayer : Player
{
    public override int Playing(Deck deck, int min = 0)
    {
        _hand = new Hand();
        _hand.AddCard(deck.GetCard());
        do
        {
            _hand.AddCard(deck.GetCard());
        } while (_hand.Cost() < min);
        
        Console.WriteLine($"{Messages.AIHAND} {_hand}");
        return _hand.Cost();
    }
}