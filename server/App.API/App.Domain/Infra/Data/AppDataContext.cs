using System.Collections.Generic;
using App.Context.Domain.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Context.Infra.Data
{
    public class AppDataContext : DbContext
    {
        private readonly string _connectionString;

        public AppDataContext(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Office> Offices { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
            

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(t => t.UserRoles);
            
            base.OnModelCreating(modelBuilder);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return Database.GetDbConnection().Query<T>(sql);
        }
    }
}
