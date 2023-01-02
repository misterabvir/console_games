namespace black_jack;

public abstract class Player
{
    public int Money{get;set;}
    protected Hand _hand;

    public Player()
    {
        Money = Rules.GAME_START_MONEY;
        _hand = new Hand();
    }

    public abstract int Playing(Deck deck, int min = 0);
}