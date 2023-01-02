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
    public string Value {get; set;}

    ///<summary>
    /// Пустая?
    ///</summary>
    public bool IsEmpty => Value == CellValue.EMPTY;
    
    ///<summary>
    /// Описание
    ///</summary>
    public string Description => IsEmpty ? Index.ToString() : " ";
    
    ///<summary>
    /// Создать
    ///</summary>
    public Cell()
    {
        Index = 0;
        Value = CellValue.EMPTY;
    }
}