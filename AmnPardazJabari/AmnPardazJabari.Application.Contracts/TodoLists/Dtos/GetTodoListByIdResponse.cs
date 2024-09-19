using AmnPardazJabari.Domain.CustomMapping;
using AmnPardazJabari.Domain.TodoList;
using AmnPardazJabari.Domain.TodoLists;
using AutoMapper;

namespace AmnPardazJabari.Application.Contracts.TodoLists.Dtos;

public class GetTodoListByIdResponse : TodoListDto, IHaveCustomMapping
{
    public bool Checked { get; set; }

    public void CreateMappings(Profile profile)
    {
        profile.CreateMap<TodoList, GetTodoListByIdResponse>();
    }
}