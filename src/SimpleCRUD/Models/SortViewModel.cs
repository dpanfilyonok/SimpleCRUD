namespace SimpleCRUD.Models;

public class SortViewModel
{
    public SortViewModel(SortState sortOrder)
    {
        // значения по умолчанию
        NameSort = SortState.NameAsc;
        AgeSort = SortState.AgeAsc;
        Up = true;
 
        if (sortOrder is SortState.AgeDesc or SortState.NameDesc)
        {
            Up = false;
        }

        Current = sortOrder switch
        {
            SortState.NameDesc => NameSort = SortState.NameAsc,
            SortState.AgeAsc => AgeSort = SortState.AgeDesc,
            SortState.AgeDesc => AgeSort = SortState.AgeAsc,
            _ => NameSort = SortState.NameDesc
        };
    }
    
    public SortState NameSort { get; set; } // значение для сортировки по имени
    public SortState AgeSort { get; set; }    // значение для сортировки по возрасту
    public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
    public bool Up { get; set; }  // Сортировка по возрастанию или убыванию
}