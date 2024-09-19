using System.Linq.Expressions;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Domain.TodoLists.Contracts;

public interface ITodoListRepository : IScopeLifeTime
{
    public bool IsExist(Expression<Func<TodoList, bool>> predicate);
    public void Add(TodoList user);
    public void Delete(TodoList user);
    public void Save();
    public void Update(TodoList user);
    public TodoList? GetById(long id);
    public TodoList? Find(Expression<Func<TodoList, bool>> predicate);
}