using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using DZ_13_Data.Entities;

namespace DZ_13_Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            new DbInitializer(modelBuilder).Seed();
        }

    }
}
