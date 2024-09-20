namespace AmnPardazJabari.Application.Contracts.TodoLists;

public interface ITodoListHostedService
{
    List<int> GetCloseToEndDateTodoLists();
}