using AmnPardazJabari.Domain.CustomMapping;
using AmnPardazJabari.Domain.TodoList;
using AmnPardazJabari.Domain.TodoLists;
using AutoMapper;

namespace AmnPardazJabari.Application.Contracts.TodoLists.Dtos;

public class GetTodoListResponse : TodoListDto, IHaveCustomMapping
{
    public int Id { get; set; }
    public bool Checked { get; set; }
    public Guid UserId { get; set; }

    public void CreateMappings(Profile profile)
    {
        profile.CreateMap<TodoList, GetTodoListResponse>()
            .ForMember(s => s.Description,
                d =>
                    d.MapFrom(v => v.Description.Value))
            .ForMember(s => s.Title,
                d =>
                    d.MapFrom(v => v.Title.Value));
    }
}