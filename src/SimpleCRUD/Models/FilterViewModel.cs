namespace SimpleCRUD.Models;

public class FilterViewModel
{
    public FilterViewModel(string name)
    {
        SelectedName = name;
    }
    
    public string SelectedName { get; }
}