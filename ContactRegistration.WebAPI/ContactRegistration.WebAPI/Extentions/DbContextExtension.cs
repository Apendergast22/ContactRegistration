
namespace ContactRegistration.WebAPI.Extentions;

public static class DbContextExtension
{
    /// <summary>
    /// Add Notification Api Db Context
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        SqliteConnection sqliteConnection = new SqliteConnection(configuration.GetConnectionString("InMemoryConnection"));
        sqliteConnection.Open(); // open connection to use

        services.AddSingleton((Func<IServiceProvider, DbConnection>)(implementationFactory =>
        {
            return sqliteConnection;
        }));


        services.AddDbContext<ContactRegistrationDbContext>((serviceProvider, dbContextOptionBuilder) =>
        {
            DbConnection dbConnection = serviceProvider.GetRequiredService<DbConnection>();
            dbContextOptionBuilder.UseSqlite(dbConnection, builder => builder.MigrationsAssembly(Assembly.Load("ContactRegistration.Infrastructure").GetName().Name));
        });

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        IServiceScope serviceScope = serviceProvider.CreateScope();
        ContactRegistrationDbContext customerDbContext = serviceScope.ServiceProvider.GetRequiredService<ContactRegistrationDbContext>();
        customerDbContext.Database.Migrate();        
    }
}
