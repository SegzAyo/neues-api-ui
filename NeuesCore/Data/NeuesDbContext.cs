using Microsoft.EntityFrameworkCore;
using Neues.Model;
using NeuesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuesCore.Data
{
    public class NeuesDbContext : DbContext
    {
        /*public NeuesDbContext() : base()
        {
        }*/

        /*public NeuesDbContext(DbContextOptions options) : base(options)
        {
        }*/

        public NeuesDbContext(DbContextOptions<NeuesDbContext> options) : base(options)
        {
        }

        public DbSet<Post>? Posts { get; set; }

        public DbSet<MainComment>? mainComments { get; set; }

        public DbSet<SubComment>? subComments { get; set; }

        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainComment>()
                .HasOne(p => p.Post)
                .WithMany(b => b.Comments)
                .HasForeignKey(p => p.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubComment>()
                .HasOne(p => p.MainComment)
                .WithMany(b => b.SubComments)
                .HasForeignKey(p => p.MainCommentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<SubComment>()
            //    .HasOne(p => p.user)
            //    .WithOne(p => p.Comment)
            //    .HasForeignKey<SubComment>("UserId")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<SubComment>()
            //    .HasKey("UserId");

            //modelBuilder.Entity<Comment>()
            //    .HasOne(p => p.user)
            //    .WithMany(b => b.Comments)
            //    .HasForeignKey(p => p.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=tcp:neueswatchserver.database.windows.net,1433;Initial Catalog=neuesdb;Persist Security Info=False;User ID=neuesw;Password=Olusegun1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
