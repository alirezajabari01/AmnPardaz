using AmnPardazJabari.Domain.CustomMapping;
using AmnPardazJabari.Domain.TodoLists;
using AutoMapper;

namespace AmnPardazJabari.Application.Contracts.TodoLists.Dtos;

public class UpdateTodoListRequest : TodoListDto,IHaveCustomMapping
{
    public int Id { get; set; }
    public void CreateMappings(Profile profile)
    {
        profile.CreateMap<UpdateTodoListRequest,TodoList>()
            .ForPath(s => s.Description.Value,
                d =>
                    d.MapFrom(v => v.Description))
            .ForPath(s => s.Title.Value,
                d =>
                    d.MapFrom(v => v.Title));
    }
}