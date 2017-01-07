using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Amelia.Data.Contexts;

namespace Amelia.WebApp.Migrations
{
    [DbContext(typeof(AmeliaContext))]
    [Migration("20170107070745_modify project structure")]
    partial class modifyprojectstructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amelia.Domain.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Error");
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

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Roles");
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

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Amelia.Domain.Models.Project", b =>
                {
                    b.HasOne("Amelia.Domain.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
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
