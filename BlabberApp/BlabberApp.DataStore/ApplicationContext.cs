using BlabberApp.Domain.Entities;
using BlabberApp.DataStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlabberApp.DataStore
{
    public class ApplicationContext : DbContext
    {
        //Constructor
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}


        //Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BlabMap(modelBuilder.Entity<Blab>());
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}
