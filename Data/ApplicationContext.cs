using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;

        public DbSet<Album> Albums { get; set; } = null!;

        public DbSet<Playlist> Playlist { get; set; }

        public ApplicationContext(DbContextOptions option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasKey(s => new { s.IdSong, s.IdAuthor });
        }
    }
}
