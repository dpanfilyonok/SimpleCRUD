namespace SimpleCRUD.Models;

public class IndexViewModel
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
    public SortViewModel SortViewModel { get; set; } = new(SortState.NameAsc);
    // public FilterViewModel FilterViewModel { get; set; } = new();
}