using Config.Database.Context;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FunctionApp3.Startup))]
namespace FunctionApp3
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("DefaultConnection");
            var context = new UsersContext(new DbContextOptionsBuilder<UsersContext>().UseSqlServer(SqlConnection).Options);
            var service = new Services.UsersService(context);
            builder.Services.AddTransient<Services.IUsersService<Models.Users>, Services.UsersService>((_) =>
            {
                return new Services.UsersService(context);
            });
        }
    }
}
