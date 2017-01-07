using System.Linq;
using Amelia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Amelia.Data.Contexts
{
    public class AmeliaContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Project> Projects { get; set; }

        public AmeliaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            foreach (var relationiship in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetForeignKeys()))
            {
                relationiship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            CreateModelUserAndRoles(modelBuilder);

        }


        private void CreateModelUserAndRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Salt).HasMaxLength(256).IsRequired();

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>().Property(r => r.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).IsRequired();

        }
    }
}