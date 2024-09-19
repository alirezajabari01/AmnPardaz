using AmnPardazJabari.Abstractions.ControllerBasic;
using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Application.Contracts.TodoLists.Dtos;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmnPardazJabari.Controllers;

[SecurityFilter(RoleId.User)]
public class TodoListController(ITodoListService todoListService) : UserBaseController
{
    [HttpPost]
    public void Create(CreateTodoListRequest request) => todoListService.CreateTodoList(request);
    
    [HttpGet("{id:int}")]
    public GetTodoListByIdResponse Get(int id)=>todoListService.GetTodoListById(id);
}