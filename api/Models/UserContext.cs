using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "LeBron",
                LastName = "James",
                UserName = "lebronjames23",
                Email = "james.lebron@gmail.com"
            }, new User
            {
                UserId = 2,
                FirstName = "Michael",
                LastName = "Jordan",
                UserName = "michaeljordan23",
                Email = "airjordan@gmail.com"
            });
        }
    }
}
