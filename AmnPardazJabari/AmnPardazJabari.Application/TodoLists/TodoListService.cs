using AmnPardazJabari.Application.Contracts.Abstractions;
using AmnPardazJabari.Application.Contracts.CustomResult;
using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using AmnPardazJabari.Application.UserId;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.TodoLists;
using AmnPardazJabari.Domain.TodoLists.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AmnPardazJabari.Application.TodoLists;

public class TodoListService(
    ITodoListRepository todoListRepository,
    IUserContext userContext,
    IMapper mapper)
    : ITodoListService, IScopeLifeTime
{
    public void CreateTodoList(CreateTodoListRequest request)
    {
        TodoList todoList = new(request.Title, request.Description, request.StartDate, request.EndDate,
            userContext.UserId);

        todoListRepository.Add(todoList);
        todoListRepository.Save();
    }

    public GetTodoListResponse GetTodoListById(int id)
    {
        var todoList = todoListRepository.Find
            (list => list.Id == id && list.UserId == userContext.UserId);

        return mapper.Map<GetTodoListResponse>(todoList);
    }

    public PaginatedResponse<GetTodoListResponse> GetAllPaginated(PaginatedRequest request)
    {
        var todoList = todoListRepository.GetQueryable()
            .Where(list => list.UserId == userContext.UserId)
            .AsNoTracking();

        var response = todoListRepository
            .CreatePage<IQueryable<GetTodoListResponse>>(todoList, request.PageNumber, request.PageSize)
            .ProjectTo<GetTodoListResponse>
                (mapper.ConfigurationProvider)
            .ToList();

        return new PaginatedResponse<GetTodoListResponse>
        (
            response,
            request.PageNumber,
            request.PageSize,
            todoList.Count()
        );
    }

    public void Delete(int id)
    {
        var todoList = todoListRepository.Find(list => list.Id == id && list.UserId == userContext.UserId)
                       ?? throw new NullReferenceException();

        todoList.DeletedDate = DateTime.Now;

        todoListRepository.Update(todoList);
        todoListRepository.Save();
    }

    public void Update(UpdateTodoListRequest request)
    {
        var todoList = todoListRepository.Find(list => list.Id == request.Id && list.UserId == userContext.UserId)
                       ?? throw new NullReferenceException();

        var mapped = mapper.Map(request, todoList);

        todoListRepository.Update(mapped);
        todoListRepository.Save();
    }

    public void MarkAsChecked(int id)
    {
        var todoList = todoListRepository.Find(list => list.Id == id && list.UserId == userContext.UserId)
                       ?? throw new NullReferenceException();

        todoList.Checked = true;

        todoListRepository.Update(todoList);
        todoListRepository.Save();
    }
}