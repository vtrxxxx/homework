using hw11.Models;
using Microsoft.EntityFrameworkCore;



namespace hw11.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }    

        public DbSet<Note> Notes { get; set; }
    }
}
