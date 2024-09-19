using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using AmnPardazJabari.Application.UserId;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.TodoLists;
using AmnPardazJabari.Domain.TodoLists.Contracts;
using AutoMapper;

namespace AmnPardazJabari.Application.TodoLists;

public class TodoListService(
    ITodoListRepository todoListRepository,
    IUserContext userContext,
    IMapper mapper)
    : ITodoListService, IScopeLifeTime
{
    public void CreateTodoList(CreateTodoListRequest request)
    {
        TodoList todoList = new(request.Title, request.Description, request.StartDate, request.EndDate);

        todoListRepository.Add(todoList);
        todoListRepository.Save();
    }

    public GetTodoListByIdResponse GetTodoListById(int id)
    {
        //TodoLists todoList = todoListRepository.Find(list => list.Id == id && li)
        return null;
    }
}