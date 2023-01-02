namespace tic_tac_toe;

///<summary>
/// Ячейка
///</summary>
public class Cell
{
    ///<summary>
    /// Индекс ячейки
    ///</summary>
    public int Index {get; set;}

    ///<summary>
    /// Значение ячейки
    ///</summary>
    public string Sign {get; set;}

    ///<summary>
    /// Пустая?
    ///</summary>
    public bool IsEmpty => Sign == CellValue.EMPTY;
    
    ///<summary>
    /// Описание
    ///</summary>
    public string AvailableIndex => IsEmpty ? Index.ToString() : " ";
    
    ///<summary>
    /// Создать
    ///</summary>
    public Cell()
    {
        Index = 0;
        Sign = CellValue.EMPTY;
    }
}