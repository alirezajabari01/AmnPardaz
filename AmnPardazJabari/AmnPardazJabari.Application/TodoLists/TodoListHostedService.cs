using AmnPardazJabari.Application.Contracts.TodoLists;
using AmnPardazJabari.Domain.TodoLists.Contracts;

namespace AmnPardazJabari.Application.TodoLists;

public class TodoListHostedService(ITodoListRepository todoListRepository) :ITodoListHostedService
{
    public List<int> GetCloseToEndDateTodoLists()
        => todoListRepository.GetQueryable()
            .Where(list => !list.Checked &&
                           list.StartDate < DateTime.Now &&
                           list.EndDate.Hour - 12 < DateTime.Now.Hour)
            .Select(list => list.Id)
            .ToList();
}