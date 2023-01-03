namespace black_jack;

public class AIPlayer : Player
{
    private Print _print = new Print();
    public override int Playing(Deck deck, int min = 0)
    {
        _hand = new Hand();
        _hand.AddCard(deck.GetCard());
        do
        {
            _hand.AddCard(deck.GetCard());
        } while (_hand.Cost() < min);
        
        _print.WriteLine(String.Format("{0} {1}", Messages.AIHAND, _hand), Style.INFO);
        return _hand.Cost();
    }
}