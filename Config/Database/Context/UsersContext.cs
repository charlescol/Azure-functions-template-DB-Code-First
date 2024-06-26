using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Config.Database.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UsersContext() 
        {}
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection"));
        }
    }
}
