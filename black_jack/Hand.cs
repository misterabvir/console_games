namespace black_jack;

public class Hand
{
    private List<Card> _cards = new List<Card>();
    
    ///<summary>
    /// Добавить карту
    ///</summary>
    public void AddCard(Card card) => _cards.Add(card);

    ///<summary>
    /// Расчет стоимости всех карт, с учетом разной стоимости тузов 
    ///</summary>
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

    ///<summary>
    /// Строковое представление
    ///</summary>
    public override string ToString() =>  $"{string.Join('-', _cards.Select(c=>c.ToString()).ToArray())} : {Cost()} points";
}
