using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Application.Contracts.TodoLists;

public interface ITodoListService : IScopeLifeTime
{
    void CreateTodoList(CreateTodoListRequest request);
    GetTodoListByIdResponse GetTodoListById(int id);
}