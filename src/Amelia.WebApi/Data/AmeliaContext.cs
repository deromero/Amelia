using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Amelia.WebApi.Models.Entities;

namespace Amelia.WebApi.Data
{
    public class AmeliaContext : DbContext
    {
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