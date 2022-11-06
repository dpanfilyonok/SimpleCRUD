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
    
    public SortState NameSort { get; set; } 
    public SortState AgeSort { get; set; }    
    public SortState Current { get; set; } 
    public bool Up { get; set; }
}