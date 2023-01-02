namespace black_jack;

public class HumanPlayer : Player
{
    public override int Playing(Deck deck, int min = 0)
    {
        _hand = new Hand();
        _hand.AddCard(deck.GetCard());
        
        do
        {
            Console.Clear();
            _hand.AddCard(deck.GetCard());
            Console.WriteLine($"{Messages.PLAYERHAND} {_hand}");

            if(_hand.Cost() > Rules.GAME_TARGET)
                break;

            Console.WriteLine(Messages.CARD);
        } while (Console.ReadLine()?.ToUpper() == Messages.YES);
        
        return _hand.Cost();
    }
}