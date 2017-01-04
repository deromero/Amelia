using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Amelia.WebApi.Data;

namespace Amelia.WebApi.Migrations
{
    [DbContext(typeof(AmeliaContext))]
    [Migration("20170104025526_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amelia.WebApi.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthSourceId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailNotification");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Language");

                    b.Property<DateTime>("LastLoginOn");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
