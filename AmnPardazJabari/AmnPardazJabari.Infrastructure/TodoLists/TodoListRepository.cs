using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.TodoLists;
using AmnPardazJabari.Domain.TodoLists.Contracts;
using AmnPardazJabari.Infrastructure.Context;

namespace AmnPardazJabari.Infrastructure.TodoLists;

public class TodoListRepository(DatabaseContext dbContext)
    : BaseRepository<TodoList>(dbContext), IScopeLifeTime, ITodoListRepository
{
    public IQueryable<TodoList> CreatePage<TResult>(IQueryable<TodoList> query, int pageNumber, int pageSize)
    {
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize < 1 ? 10 : pageSize;

        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
    public void Save()
    {
        dbContext.SaveChanges();
    }
}