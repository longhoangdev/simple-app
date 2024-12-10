using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleApp.Persistence.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var connectionString = GetConnectionString();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql(connectionString,
            npgsqlOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable("__MigrationsHistory");
            });
        
        return new DataContext(optionsBuilder.Options);
    }
    
    private static string GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.Development.json", true);

        builder.AddEnvironmentVariables();

        IConfiguration config = builder.Build();

        var connectionString = config.GetConnectionString("Default");
        if (connectionString is null)
            throw new ArgumentNullException(nameof(connectionString), "Unable to find connection string for migration");
        return connectionString;
    }
}