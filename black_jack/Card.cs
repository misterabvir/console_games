namespace black_jack;

///<summary>
/// Карта
///</summary>
public class Card
{  
    private string [] _suitCard => new string[]{"♥", "♦", "♣", "♠"};
    private string [] _valueCard => new string[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    private int [] _valueCostCard => new int[]{2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11};   
    private int _indexSuit;
    private int _indexValue;

    ///<summary>
    /// значение карты
    ///</summary>
    public string Value => _valueCard[_indexValue];

    ///<summary>
    /// создание карты
    ///</summary>
    public Card(int indexSuit, int indexValue)
    {
        _indexSuit = indexSuit;
        _indexValue = indexValue;
    }

    ///<summary>
    /// стоимость карты
    ///</summary>
    public int Cost => _valueCostCard[_indexValue];
    
    ///<summary>
    /// строковое представление
    ///</summary>
    public override string ToString() => $"{_valueCard[_indexValue]}{_suitCard[_indexSuit]}";
}