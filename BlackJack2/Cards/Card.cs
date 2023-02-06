namespace BlackJack2.Cards
{
    public class Card
    {        
        private (int iRank, int iSuit) indexes;
        public bool IsAce => indexes.iRank == 1;
        private string[] cardPresentation
        {
            get
            {
                if (IsFlipped) return new String[] { " ___ ", 
                                                     "|## |", 
                                                     "|###|", 
                                                     "|_##|" };
                if (indexes.iRank == 10) return new String[] { " ___ ", 
                                                               "|10 |", 
                                                string.Format("| {0} |", Suit), 
                                                               "|_10|" };
                return new String[] { " ___ ", 
                        string.Format("|{0}  |", Rank), 
                        string.Format("| {0} |", Suit), 
                        string.Format("|__{0}|", Rank) };
            }
        }

        public string Rank => Settings.Ranks[indexes.iRank];
        public string Suit => Settings.Suits[indexes.iSuit];
        public int Points => Settings.PointsRanks[indexes.iRank];
        public bool IsFlipped { get; set; } = false;

        public Card((int iRank, int iSuit) index)
        {
            if (index.iRank < 0 || index.iRank >= Settings.Ranks.Length || index.iSuit < 0 || index.iSuit >= Settings.Suits.Length)
                throw new IndexOutOfRangeException();
            indexes = index;
        }

        public void Print((int left, int top) position)
        {           
            foreach (var str in cardPresentation)
            {
                Console.SetCursorPosition(left: position.left, top: position.top);
                Console.Write(str);
                position.top++;
            }
        }
    }
}