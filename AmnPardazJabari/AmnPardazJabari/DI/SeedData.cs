using AmnPardazJabari.Infrastructure.Abstractions;
using AmnPardazJabari.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AmnPardazJabari.DI;

public static class SeedData
{
    public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
    { 
        //Use C# 8 using variables
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbContext = scope.ServiceProvider.GetService<DatabaseContext>(); //Service locator

        //Dos not use Migrations, just Create Database with latest changes
        //dbContext.Database.EnsureCreated();
        //Applies any pending migrations for the context to the database like (Update-Database)
        dbContext.Database.Migrate();

        var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
        foreach (var dataInitializer in dataInitializers)
            dataInitializer.InitializeData();

        return app;
    }
}