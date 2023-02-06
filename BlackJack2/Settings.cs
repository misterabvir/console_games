namespace BlackJack2;

public class Settings
{
    public static int MaxPointsGame => 21;
    public static int HorizontalCardOffset => 6;
    public static int AcesPointBonus => 10;

    public static string[] Ranks => new string[] { "", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public static int[] PointsRanks => new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
    public static string[] Suits => new string[] { "♥", "♦", "♣", "♠" };
    public static int RankCount => 13;
    public static int SuitCount => 4;

    public static (int left, int top) PositionDealerText => (0,0);
    public static (int left, int top) PositionDealerHand => (0,2);
    public static (int left, int top) PositionHumanText=> (0,8);
    public static (int left, int top) PositionHumanHand=> (0,10);
    public static (int left, int top) PositionHumanChoiceText=> (0,15);
    public static (int left, int top) PositionResultText=> (0,15);
    public static (int left, int top) PositionGameResultText=> (0,16);
    public static (int left, int top) PositionAgainText=> (0,17);
}