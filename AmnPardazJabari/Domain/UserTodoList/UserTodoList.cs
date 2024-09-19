using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Users;

namespace AmnPardazJabari.Domain.UserTodoList;

public class UserTodoList:BaseEntity<int>
{
    public UserTodoList(int todoListId, Guid userId)
    {
        TodoListId = todoListId;
        UserId = userId;
    }
    public int TodoListId { get; set; }
    public Guid UserId { get; set; }

    public TodoList.TodoList TodoList { get; set; }
    public User User { get; set; }
}