using AudioEditor.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AudioEditor.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        readonly string constring = "Data Source=EDIZONFIRE\\SQLEXPRESS;Initial Catalog=Blogs;Integrated Security=True;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(constring);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioFile_User>()
                .HasOne(a => a.AudioFile)
                .WithMany(au => au.AudioFile_Users)
                .HasForeignKey(ai => ai.AudioFileId);
            modelBuilder.Entity<AudioFile_User>()
               .HasOne(a => a.User)
               .WithMany(au => au.AudioFile_Users)
               .HasForeignKey(ai => ai.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<AudioFile_User> AudioFile_Users { get; set; }
    }
}
