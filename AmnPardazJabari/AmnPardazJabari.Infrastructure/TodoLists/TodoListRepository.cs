using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.TodoLists;
using AmnPardazJabari.Domain.TodoLists.Contracts;
using AmnPardazJabari.Infrastructure.Context;

namespace AmnPardazJabari.Infrastructure.TodoLists;

public class TodoListRepository(DatabaseContext dbContext)
    : BaseRepository<TodoList>(dbContext), IScopeLifeTime, ITodoListRepository
{
    public void Save()
    {
        dbContext.SaveChanges();
    }
}