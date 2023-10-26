namespace MultiTracksAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using MultiTracksAPI.Data.Models;

    public class MultiTracksDbContext : DbContext
    {
        public MultiTracksDbContext(DbContextOptions<MultiTracksDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Song> Song { get; set; }

    }
}
