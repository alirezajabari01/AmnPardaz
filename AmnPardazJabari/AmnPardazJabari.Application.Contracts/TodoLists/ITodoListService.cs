using AmnPardazJabari.Application.Contracts.Abstractions;
using AmnPardazJabari.Application.Contracts.CustomResult;
using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Application.Contracts.TodoLists;

public interface ITodoListService : IScopeLifeTime
{
    void CreateTodoList(CreateTodoListRequest request);
    GetTodoListResponse GetTodoListById(int id);
    PaginatedResponse<GetTodoListResponse> GetAllPaginated(PaginatedRequest request);
    void Delete(int id);
    void Update(UpdateTodoListRequest request);
    void MarkAsChecked(int id);
}