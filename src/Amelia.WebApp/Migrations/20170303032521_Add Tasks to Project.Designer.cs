using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Amelia.Data.Contexts;

namespace Amelia.WebApp.Migrations
{
    [DbContext(typeof(AmeliaContext))]
    [Migration("20170303032521_Add Tasks to Project")]
    partial class AddTaskstoProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amelia.Domain.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Extension");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<string>("MimmeType");

                    b.Property<string>("Name");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsPrivate");

                    b.Property<bool>("IsResolved");

                    b.Property<int?>("TaskId");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("TaskId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Amelia.Domain.Models.CommentAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttachmentId");

                    b.Property<int?>("CommentId");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentAttachment");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAdmin");

                    b.Property<int?>("RoleId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("TaskId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("ImageLogoUrl");

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("OwnerId");

                    b.Property<short>("ProjectType");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<short>("Status");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Amelia.Domain.Models.ProjectRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectRoles");
                });

            modelBuilder.Entity("Amelia.Domain.Models.ProjectValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<short>("Position");

                    b.Property<int?>("ProjectId");

                    b.Property<decimal>("Value");

                    b.Property<int?>("ValueTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("ProjectValues");
                });

            modelBuilder.Entity("Amelia.Domain.Models.ProjectValueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProjectValueTypes");
                });

            modelBuilder.Entity("Amelia.Domain.Models.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssignedToId");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int?>("ParentId");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("RequestTypeId");

                    b.Property<int?>("SprintId");

                    b.Property<int>("Status");

                    b.Property<string>("Subject");

                    b.Property<int?>("TaskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("SprintId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("MemberId");

                    b.Property<int?>("PointId");

                    b.Property<int?>("ProjectRoleId");

                    b.Property<int?>("TaskId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PointId");

                    b.HasIndex("ProjectRoleId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskPoints");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsClosed");

                    b.Property<int?>("ModuleId");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("Slug");

                    b.Property<int?>("TaskTypeId");

                    b.Property<int>("WipLimit");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TagId");

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskTag");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("MemberId");

                    b.Property<int?>("PointId");

                    b.Property<int?>("ProjectRoleId");

                    b.Property<int?>("TaskId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PointId");

                    b.HasIndex("ProjectRoleId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskVotes");
                });

            modelBuilder.Entity("Amelia.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<short>("Status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Amelia.Domain.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Attachment", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Member", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Comment", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Member", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Amelia.Domain.Models.Task", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId");

                    b.HasOne("Amelia.Domain.Models.Member", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Amelia.Domain.Models.CommentAttachment", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("Amelia.Domain.Models.Comment", "Comment")
                        .WithMany("Attachments")
                        .HasForeignKey("CommentId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Member", b =>
                {
                    b.HasOne("Amelia.Domain.Models.ProjectRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Amelia.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Module", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project")
                        .WithMany("Modules")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Point", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Amelia.Domain.Models.Task")
                        .WithMany("Points")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Project", b =>
                {
                    b.HasOne("Amelia.Domain.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.ProjectRole", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.ProjectValue", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Amelia.Domain.Models.ProjectValueType", "ValueType")
                        .WithMany()
                        .HasForeignKey("ValueTypeId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.RequestType", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Role", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project")
                        .WithMany("Roles")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Sprint", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Tag", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Task", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Member", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("Amelia.Domain.Models.Member", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Amelia.Domain.Models.Task", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Amelia.Domain.Models.RequestType", "RequestType")
                        .WithMany("Tasks")
                        .HasForeignKey("RequestTypeId");

                    b.HasOne("Amelia.Domain.Models.Sprint", "Sprint")
                        .WithMany("Tasks")
                        .HasForeignKey("SprintId");

                    b.HasOne("Amelia.Domain.Models.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskPoint", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("Amelia.Domain.Models.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId");

                    b.HasOne("Amelia.Domain.Models.ProjectRole", "ProjectRole")
                        .WithMany()
                        .HasForeignKey("ProjectRoleId");

                    b.HasOne("Amelia.Domain.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskStatus", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId");

                    b.HasOne("Amelia.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Amelia.Domain.Models.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskTag", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");

                    b.HasOne("Amelia.Domain.Models.Task", "Task")
                        .WithMany("Tags")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.TaskVote", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("Amelia.Domain.Models.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId");

                    b.HasOne("Amelia.Domain.Models.ProjectRole", "ProjectRole")
                        .WithMany()
                        .HasForeignKey("ProjectRoleId");

                    b.HasOne("Amelia.Domain.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Amelia.Domain.Models.UserRole", b =>
                {
                    b.HasOne("Amelia.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Amelia.Domain.Models.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
