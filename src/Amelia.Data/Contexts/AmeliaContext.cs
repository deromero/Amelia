using System;
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
        public DbSet<Module> Modules { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<ProjectValue> ProjectValues { get; set; }
        public DbSet<ProjectValueType> ProjectValueTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<TaskPoint> TaskPoints { get; set; }
        public DbSet<TaskVote> TaskVotes { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }


        public AmeliaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // foreach (var entity in modelBuilder.Model.GetEntityTypes())
          //  {
           //     entity.Relational().TableName = entity.DisplayName();
          //  }
 
             foreach (var relationiship in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(e => e.GetForeignKeys()))
            {
                relationiship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            CreateModelUserAndRoles(modelBuilder);
            CreateModelProjects(modelBuilder);
            CreateModelTasks(modelBuilder);
            CreateModelOther(modelBuilder);
        }

        private void CreateModelOther(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Error>().ToTable("Errors");
            modelBuilder.Entity<Tag>().ToTable("Tags");
        }

        private void CreateModelProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Projects")
                .HasIndex(p => p.Slug).IsUnique();

            modelBuilder.Entity<Project>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Slug).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Project>().HasOne(p => p.Owner);

            modelBuilder.Entity<Module>().ToTable("Modules");
            modelBuilder.Entity<ProjectRole>().ToTable("ProjectRoles");
            modelBuilder.Entity<Member>().ToTable("ProjectMembers");

        }

        private void CreateModelSprints(ModelBuilder modelBuilder){
            modelBuilder.Entity<Sprint>().ToTable("Sprints")
            .HasOne(t=>t.Project);
        }

        private void CreateModelTasks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.Entity<Task>()
            .HasOne(t=>t.Parent)
            .WithMany(t=>t.Children)
            .HasForeignKey(t=>t.ParentId);


  /*          modelBuilder.Entity<Task>()
                .HasMany(t => t.ChildTasks)
                .WithOne(t => t.ParentTask);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.Attachments);
            
            
            modelBuilder.Entity<Comment>()
            .HasMany(a=>a.Attachments); */
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