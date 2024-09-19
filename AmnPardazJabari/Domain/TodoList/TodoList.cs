using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.TodoList.ValueObjects;

namespace AmnPardazJabari.Domain.TodoList;

public class TodoList : BaseEntity<int>
{
    public TodoList(bool @checked, string title, string description, DateTime startDate, DateTime endDate)
    {
        Checked = @checked;
        StartDate = startDate;
        EndDate = endDate;
        Description = new Description(description);
        Title = new Title(title);
    }
    public bool Checked { get; set; }
    public Title Title { get; set; }
    public Description Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public List<UserTodoList.UserTodoList> UserTodoList { get; set; }
}