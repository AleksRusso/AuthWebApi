using Microsoft.EntityFrameworkCore;
using AuthWebApi.Models;
namespace AuthWebApi.FContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "user" }
            });
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User { Id = 1, Name = "Name1", Email="email1@gmail.com", Login="Login1", Password = "pass1", RoleId = 1 },
                new User { Id = 2, Name = "Name2", Email="email2@gmail.com", Login="Login1", Password = "pass2", RoleId = 2 }
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
