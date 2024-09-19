using System.ComponentModel.DataAnnotations;

namespace AmnPardazJabari.Application.Contracts.TodoLists.Dtos;

public class TodoListDto
{
    [Required] public string Title { get; set; }
    [Required] public string Description { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
}