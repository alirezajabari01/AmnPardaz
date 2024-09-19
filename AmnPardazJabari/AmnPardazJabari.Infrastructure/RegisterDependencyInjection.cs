using AmnPardazJabari.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmnPardazJabari.Infrastructure;

public static class RegisterDependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection)
    {
        string connectionString = "Server=localhost;Database=mydb;User=myuser;Password=mypassword;";
        serviceCollection.AddDbContext<DatabaseContext>
        (
            options => options.UseMySql
            (
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );
    }
}