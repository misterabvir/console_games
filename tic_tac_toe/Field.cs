namespace tic_tac_toe;

///<summary>
/// Игровое поле
///</summary>
public class Field
{
    ///<summary>
    /// Количество ячеек поля
    ///</summary>
    static public int AmountOfCells = 9;
    
    ///<summary>
    /// Есть ли выигрыш?
    ///</summary>
    public bool IsComplete =>   IsLine(_cells[0],_cells[1],_cells[2]) ||
                                IsLine(_cells[3],_cells[4],_cells[5]) ||
                                IsLine(_cells[6],_cells[7],_cells[8]) ||
                                
                                IsLine(_cells[0],_cells[3],_cells[6]) ||
                                IsLine(_cells[1],_cells[4],_cells[7]) ||
                                IsLine(_cells[2],_cells[5],_cells[8]) ||

                                IsLine(_cells[0],_cells[4],_cells[8]) ||
                                IsLine(_cells[6],_cells[4],_cells[2]);

    private bool IsLine(Cell cell1, Cell cell2, Cell cell3) => !cell1.IsEmpty && !cell2.IsEmpty && !cell3.IsEmpty
                                                            && cell1.Value == cell2.Value 
                                                            && cell1.Value == cell3.Value; 


    ///<summary>
    /// Поле заполнено?
    ///</summary>
    public bool Full => (_cells.Where(w => w.Value == CellValue.EMPTY).Count() == 0);

    private Cell [] _cells = new Cell[AmountOfCells];

    ///<summary>
    /// Создать поле
    ///</summary>
    public Field()
    {
        Clear();
    }

    private void Clear()
    {
        _cells = new Cell[AmountOfCells];
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = new Cell(){Index=i, Value = CellValue.EMPTY};
        }
    }

    ///<summary>
    /// Установить ячейку
    ///</summary>
    public void SetValue(int index, string sign)
    { 
        _cells[index].Value = sign;
    }
    
    ///<summary>
    /// Можно ли заполнить ячейку?
    ///</summary>
    public bool CanSign(int index) => _cells[index].IsEmpty;

    ///<summary>
    /// Строковая отрисовка поля
    ///</summary>
    public override string ToString()
    {
        string str  = "";      
        int amountCellsInline = 3;

        for (int i = 0; i < _cells.Length; i += amountCellsInline)
        {
            str+= ($" {(_cells[i].Value)} | {(_cells[i + 1].Value)} | {(_cells[i + 2].Value)} \t\t");
            str+= ($" {(_cells[i].Description)} | {(_cells[i + 1].Description)} | {(_cells[i + 2].Description)}");            
            if(i < (_cells.Length - amountCellsInline))
                str+= ("\n---|---|---\t\t---|---|---\n");
        }
        return str;
    }
}