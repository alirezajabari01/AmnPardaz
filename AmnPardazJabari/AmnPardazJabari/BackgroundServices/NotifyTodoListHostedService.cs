using System.Text;
using AmnPardazJabari.Application.Contracts.TodoLists;
using Newtonsoft.Json;

namespace AmnPardazJabari.BackgroundServices;

public class NotifyTodoListHostedService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITodoListHostedService _todoListService;

    public NotifyTodoListHostedService(IHttpClientFactory httpClientFactory, IServiceScopeFactory serviceScopeFactory)
    {
        _httpClientFactory = httpClientFactory;
        _todoListService = serviceScopeFactory.CreateScope().ServiceProvider.GetService<ITodoListHostedService>() ??
                           throw new NullReferenceException();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var ids = _todoListService.GetCloseToEndDateTodoLists();
        
        var client = _httpClientFactory.CreateClient();
        
        var url = "http://localhost:20563/api/NotifyUser/Notify";
        
        var jsonContent = JsonConvert.SerializeObject(ids);
        
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(url, content, stoppingToken);

        await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
    }
}