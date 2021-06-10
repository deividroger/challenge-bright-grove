using System.Collections.Generic;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Office> Offices { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=./app.db");
           
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return this.Database.GetDbConnection().Query<T>(sql);
        }
    }
}
