using AmnPardazJabari.Abstractions.ControllerBasic;
using AmnPardazJabari.Application.Contracts.Abstractions;
using AmnPardazJabari.Application.Contracts.CustomResult;
using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Controllers.User;
public class TodoListController(ITodoListService todoListService) : UserBaseController
{
    [HttpPost]
    public void Create(CreateTodoListRequest request) => todoListService.CreateTodoList(request);

    [HttpGet("{id:int}")]
    public GetTodoListResponse Get(int id) => todoListService.GetTodoListById(id);

    [HttpGet]
    public PaginatedResponse<GetTodoListResponse> GetAllPaginated([FromQuery] PaginatedRequest request)
        => todoListService.GetAllPaginated(request);

    [HttpDelete("{id:int}")]
    public void Delete(int id) => todoListService.Delete(id);

    [HttpPut]
    public void Update(UpdateTodoListRequest request) => todoListService.Update(request);

    [HttpPatch("{id:int}")]
    public void Check(int id) => todoListService.MarkAsChecked(id);
}