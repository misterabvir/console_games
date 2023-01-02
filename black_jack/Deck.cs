namespace black_jack;

public class Deck
{
    private Card[] _cards;
    private int _amountCards => 52; 
    private int _amountSuits => 4; 
    private int _amountValues => 13; 
    private int _pointer = 0;

    public Deck()
    {
        _cards = new Card[_amountCards];
        Create();
    }

    private void Create()
    {       
        for (int suitIndex = 0; suitIndex < _amountSuits; suitIndex++)
            for (int valIndex = 0; valIndex < _amountValues; valIndex++)
                _cards[suitIndex * _amountValues + valIndex] = new Card(suitIndex, valIndex);
    }

    public void Shuffle()
    {        
        for (int i = 0; i < _amountCards; i++)
        {
            var rand = new Random().Next(0, _amountCards);
            var temp = _cards[i];
            _cards[i] = _cards[rand];
            _cards[rand] = temp; 
        }
        _pointer = 0;
    }

    public Card GetCard()
    {
        Card card = _cards[_pointer];
        _pointer++;
        if(_pointer >= _amountCards)
            Shuffle();
        return card;
    }
}