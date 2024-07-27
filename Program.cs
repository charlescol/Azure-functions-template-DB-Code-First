using Config.Database.Context;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        string SqlConnection = Environment.GetEnvironmentVariable("DefaultConnection");
        if (SqlConnection != null )
        {
            var context = new UsersContext(new DbContextOptionsBuilder<UsersContext>().UseSqlServer(SqlConnection).Options);
            services.AddTransient<Services.IUsersService<Models.Users>, Services.UsersService>((_) =>
            {
                return new Services.UsersService(context);
            });
        }
        else
        {
            Console.WriteLine("DefaultConnection missing in environment variables");
        }
    })
    .Build();

host.Run();
