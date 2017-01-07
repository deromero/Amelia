using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amelia.WebApp.Migrations
{
    public partial class modifyprojectstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectCount",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameColumn(
                name: "HomePage",
                table: "Projects",
                newName: "ImageLogoUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ProjectType",
                table: "Projects",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Projects",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Slug",
                table: "Projects",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Slug",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameColumn(
                name: "ImageLogoUrl",
                table: "Project",
                newName: "HomePage");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectCount",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");
        }
    }
}
