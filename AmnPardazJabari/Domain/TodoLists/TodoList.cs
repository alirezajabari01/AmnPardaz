using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.TodoList.ValueObjects;
using AmnPardazJabari.Domain.Users;

namespace AmnPardazJabari.Domain.TodoLists;

public class TodoList : BaseEntity<int>, IScopeLifeTime
{
    private TodoList()
    {
        
    }
    public TodoList(string title, string description, DateTime startDate, DateTime endDate,Guid userId)
    {
        StartDate = startDate;
        EndDate = endDate;
        Description = new Description(description);
        Title = new Title(title);
        UserId = userId;
    }

    public bool Checked { get; set; } = false;
    public Title Title { get; set; }
    public Description Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; }
}