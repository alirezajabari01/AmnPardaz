using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AmnPardazJabari.Infrastructure.Context;

public class DatabaseContextFactory: IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
      string connectionString = "Server=localhost;Database=mydb;User=myuser;Password=mypassword;";

        
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

        optionsBuilder.UseMySql
        (
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );

        return new DatabaseContext(optionsBuilder.Options);
    }
}