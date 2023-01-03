namespace black_jack;

public class HumanPlayer : Player
{
    private Print _print = new Print();
    
    public override int Playing(Deck deck, int min = 0)
    {
        _hand = new Hand();
        _hand.AddCard(deck.GetCard());
        
        do
        {
            _print.Clear();
            _hand.AddCard(deck.GetCard());
            _print.WriteLine(String.Format($"{Messages.PLAYERHAND} {_hand}"), Style.INFO);

            if(_hand.Cost() > Rules.GAME_TARGET)
                break;

            _print.Write(String.Format(Messages.CARD), Style.SIMPLE);
        } while (Console.ReadLine()?.ToUpper() == Messages.YES);
        
        return _hand.Cost();
    }
}