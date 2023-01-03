namespace tic_tac_toe;

///<summary>
/// Игровое поле
///</summary>
public class Field
{
    ///<summary>
    /// Количество ячеек поля
    ///</summary>
    public static int AmountOfCells => 9;

    private Cell [] _cells = new Cell[AmountOfCells];
    
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
                                                            && cell1.Sign == cell2.Sign 
                                                            && cell1.Sign == cell3.Sign; 


    ///<summary>
    /// Поле заполнено?
    ///</summary>
    public bool Full => (_cells.Where(w => w.Sign == CellValue.EMPTY).Count() == 0);


    ///<summary>
    /// Создать поле
    ///</summary>
    public Field()
    {
        _cells = new Cell[AmountOfCells];
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = new Cell(){Index=i, Sign = CellValue.EMPTY};
        }
    }

    ///<summary>
    /// Установить ячейку
    ///</summary>
    public void SetValue(int index, string sign)
    { 
        _cells[index].Sign = sign;
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
            str += string.Format(Messages.SIGN_LINE, 
                            _cells[i    ].Sign, 
                            _cells[i + 1].Sign, 
                            _cells[i + 2].Sign);
            str += string.Format(Messages.AVAILABLE_LINE, 
                            _cells[i    ].AvailableIndex, 
                            _cells[i + 1].AvailableIndex, 
                            _cells[i + 2].AvailableIndex);            
            if(i < (_cells.Length - amountCellsInline))
                str += Messages.FIELD_LINE;
        }
        return str;
    }
}