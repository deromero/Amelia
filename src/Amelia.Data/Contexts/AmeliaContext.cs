using System.Linq;
using Amelia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Amelia.Data.Contexts
{
    public class AmeliaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AmeliaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationiship in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetForeignKeys()))
            {
                relationiship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            CreateModelUser(modelBuilder);

        }


        private void CreateModelUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}