﻿using AudioEditor.Core.Models;
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
            modelBuilder.Entity<AudioFile>()
                .HasOne(u => u.User);

            modelBuilder.Entity<User>()
               .HasMany(af => af.AudioFiles);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
    }
}
