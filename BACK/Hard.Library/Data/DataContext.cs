using Hard.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Hard.Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Gender> Genders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(g => g.Gender);
        }
    }
}
