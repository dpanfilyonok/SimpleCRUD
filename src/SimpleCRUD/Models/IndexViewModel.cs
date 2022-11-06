namespace SimpleCRUD.Models;

public class IndexViewModel
{
    public IndexViewModel(
        IEnumerable<User> users, 
        PageViewModel pageViewModel, 
        FilterViewModel filterViewModel, 
        SortViewModel sortViewModel)
    {
        Users = users;
        PageViewModel = pageViewModel;
        FilterViewModel = filterViewModel;
        SortViewModel = sortViewModel;
    }

    public IEnumerable<User> Users { get; }
    public PageViewModel PageViewModel { get; }
    public FilterViewModel FilterViewModel { get;}
    public SortViewModel SortViewModel { get;}
}