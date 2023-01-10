using AudioEditor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioEditor.Infrastructure
{
    public class AppDbContext : DbContext
    {
        readonly string constring = "Data Source=EDIZONFIRE\\SQLEXPRESS;Initial Catalog=Database;Integrated Security=True;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(constring);

        public DbSet<User> Users { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
    }
}
