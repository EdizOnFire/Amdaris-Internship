using AudioEditor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioEditor.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
    }
}
