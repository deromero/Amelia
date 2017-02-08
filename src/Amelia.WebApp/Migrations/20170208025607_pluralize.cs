using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amelia.WebApp.Migrations
{
    public partial class pluralize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Members_CreatedById",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Members_CreatedById",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Tasks_TaskId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Members_UpdatedById",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentAttachment_Attachment_AttachmentId",
                table: "CommentAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentAttachment_Comment_CommentId",
                table: "CommentAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Projects_ProjectId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_Point_Tasks_TaskId",
                table: "Point");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectValue_Projects_ProjectId",
                table: "ProjectValue");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectValue_ProjectValueType_ValueTypeId",
                table: "ProjectValue");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestType_Projects_ProjectId",
                table: "RequestType");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Projects_ProjectId",
                table: "Sprint");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Projects_ProjectId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RequestType_RequestTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprint_SprintId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskType_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoint_Members_MemberId",
                table: "TaskPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoint_Point_PointId",
                table: "TaskPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoint_ProjectRoles_ProjectRoleId",
                table: "TaskPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoint_Tasks_TaskId",
                table: "TaskPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatus_Modules_ModuleId",
                table: "TaskStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatus_Projects_ProjectId",
                table: "TaskStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatus_TaskType_TaskTypeId",
                table: "TaskStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTag_Tag_TagId",
                table: "TaskTag");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVote_Members_MemberId",
                table: "TaskVote");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVote_Point_PointId",
                table: "TaskVote");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVote_ProjectRoles_ProjectRoleId",
                table: "TaskVote");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVote_Tasks_TaskId",
                table: "TaskVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskVote",
                table: "TaskVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPoint",
                table: "TaskPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprint",
                table: "Sprint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestType",
                table: "RequestType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectValueType",
                table: "ProjectValueType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectValue",
                table: "ProjectValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Error",
                table: "Error");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "TaskVote",
                newName: "TaskVotes");

            migrationBuilder.RenameTable(
                name: "TaskType",
                newName: "TaskTypes");

            migrationBuilder.RenameTable(
                name: "TaskStatus",
                newName: "TaskStatuses");

            migrationBuilder.RenameTable(
                name: "TaskPoint",
                newName: "TaskPoints");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Sprint",
                newName: "Sprints");

            migrationBuilder.RenameTable(
                name: "RequestType",
                newName: "RequestTypes");

            migrationBuilder.RenameTable(
                name: "ProjectValueType",
                newName: "ProjectValueTypes");

            migrationBuilder.RenameTable(
                name: "ProjectValue",
                newName: "ProjectValues");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Points");

            migrationBuilder.RenameTable(
                name: "Error",
                newName: "Errors");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVote_TaskId",
                table: "TaskVotes",
                newName: "IX_TaskVotes_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVote_ProjectRoleId",
                table: "TaskVotes",
                newName: "IX_TaskVotes_ProjectRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVote_PointId",
                table: "TaskVotes",
                newName: "IX_TaskVotes_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVote_MemberId",
                table: "TaskVotes",
                newName: "IX_TaskVotes_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatus_TaskTypeId",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatus_ProjectId",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatus_ModuleId",
                table: "TaskStatuses",
                newName: "IX_TaskStatuses_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoint_TaskId",
                table: "TaskPoints",
                newName: "IX_TaskPoints_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoint_ProjectRoleId",
                table: "TaskPoints",
                newName: "IX_TaskPoints_ProjectRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoint_PointId",
                table: "TaskPoints",
                newName: "IX_TaskPoints_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoint_MemberId",
                table: "TaskPoints",
                newName: "IX_TaskPoints_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ProjectId",
                table: "Tags",
                newName: "IX_Tags_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_ProjectId",
                table: "Sprints",
                newName: "IX_Sprints_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestType_ProjectId",
                table: "RequestTypes",
                newName: "IX_RequestTypes_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectValue_ValueTypeId",
                table: "ProjectValues",
                newName: "IX_ProjectValues_ValueTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectValue_ProjectId",
                table: "ProjectValues",
                newName: "IX_ProjectValues_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_TaskId",
                table: "Points",
                newName: "IX_Points_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Point_ProjectId",
                table: "Points",
                newName: "IX_Points_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UpdatedById",
                table: "Comments",
                newName: "IX_Comments_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TaskId",
                table: "Comments",
                newName: "IX_Comments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CreatedById",
                table: "Comments",
                newName: "IX_Comments_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_CreatedById",
                table: "Attachments",
                newName: "IX_Attachments_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskVotes",
                table: "TaskVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPoints",
                table: "TaskPoints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprints",
                table: "Sprints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectValueTypes",
                table: "ProjectValueTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectValues",
                table: "ProjectValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Errors",
                table: "Errors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Members_CreatedById",
                table: "Attachments",
                column: "CreatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Members_CreatedById",
                table: "Comments",
                column: "CreatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Members_UpdatedById",
                table: "Comments",
                column: "UpdatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAttachment_Attachments_AttachmentId",
                table: "CommentAttachment",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAttachment_Comments_CommentId",
                table: "CommentAttachment",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Projects_ProjectId",
                table: "Points",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Tasks_TaskId",
                table: "Points",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectValues_Projects_ProjectId",
                table: "ProjectValues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectValues_ProjectValueTypes_ValueTypeId",
                table: "ProjectValues",
                column: "ValueTypeId",
                principalTable: "ProjectValueTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_Projects_ProjectId",
                table: "RequestTypes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RequestTypes_RequestTypeId",
                table: "Tasks",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_SprintId",
                table: "Tasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoints_Members_MemberId",
                table: "TaskPoints",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoints_Points_PointId",
                table: "TaskPoints",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoints_ProjectRoles_ProjectRoleId",
                table: "TaskPoints",
                column: "ProjectRoleId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoints_Tasks_TaskId",
                table: "TaskPoints",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatuses_Modules_ModuleId",
                table: "TaskStatuses",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatuses_Projects_ProjectId",
                table: "TaskStatuses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatuses_TaskTypes_TaskTypeId",
                table: "TaskStatuses",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTag_Tags_TagId",
                table: "TaskTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVotes_Members_MemberId",
                table: "TaskVotes",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVotes_Points_PointId",
                table: "TaskVotes",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVotes_ProjectRoles_ProjectRoleId",
                table: "TaskVotes",
                column: "ProjectRoleId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVotes_Tasks_TaskId",
                table: "TaskVotes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Members_CreatedById",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Members_CreatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Members_UpdatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentAttachment_Attachments_AttachmentId",
                table: "CommentAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentAttachment_Comments_CommentId",
                table: "CommentAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Projects_ProjectId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Tasks_TaskId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectValues_Projects_ProjectId",
                table: "ProjectValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectValues_ProjectValueTypes_ValueTypeId",
                table: "ProjectValues");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_Projects_ProjectId",
                table: "RequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RequestTypes_RequestTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_SprintId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoints_Members_MemberId",
                table: "TaskPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoints_Points_PointId",
                table: "TaskPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoints_ProjectRoles_ProjectRoleId",
                table: "TaskPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPoints_Tasks_TaskId",
                table: "TaskPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatuses_Modules_ModuleId",
                table: "TaskStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatuses_Projects_ProjectId",
                table: "TaskStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatuses_TaskTypes_TaskTypeId",
                table: "TaskStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTag_Tags_TagId",
                table: "TaskTag");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVotes_Members_MemberId",
                table: "TaskVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVotes_Points_PointId",
                table: "TaskVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVotes_ProjectRoles_ProjectRoleId",
                table: "TaskVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskVotes_Tasks_TaskId",
                table: "TaskVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskVotes",
                table: "TaskVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatuses",
                table: "TaskStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPoints",
                table: "TaskPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprints",
                table: "Sprints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectValueTypes",
                table: "ProjectValueTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectValues",
                table: "ProjectValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Errors",
                table: "Errors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "TaskVotes",
                newName: "TaskVote");

            migrationBuilder.RenameTable(
                name: "TaskTypes",
                newName: "TaskType");

            migrationBuilder.RenameTable(
                name: "TaskStatuses",
                newName: "TaskStatus");

            migrationBuilder.RenameTable(
                name: "TaskPoints",
                newName: "TaskPoint");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Sprints",
                newName: "Sprint");

            migrationBuilder.RenameTable(
                name: "RequestTypes",
                newName: "RequestType");

            migrationBuilder.RenameTable(
                name: "ProjectValueTypes",
                newName: "ProjectValueType");

            migrationBuilder.RenameTable(
                name: "ProjectValues",
                newName: "ProjectValue");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Point");

            migrationBuilder.RenameTable(
                name: "Errors",
                newName: "Error");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRole",
                newName: "IX_UserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVotes_TaskId",
                table: "TaskVote",
                newName: "IX_TaskVote_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVotes_ProjectRoleId",
                table: "TaskVote",
                newName: "IX_TaskVote_ProjectRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVotes_PointId",
                table: "TaskVote",
                newName: "IX_TaskVote_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskVotes_MemberId",
                table: "TaskVote",
                newName: "IX_TaskVote_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_TaskTypeId",
                table: "TaskStatus",
                newName: "IX_TaskStatus_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_ProjectId",
                table: "TaskStatus",
                newName: "IX_TaskStatus_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskStatuses_ModuleId",
                table: "TaskStatus",
                newName: "IX_TaskStatus_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoints_TaskId",
                table: "TaskPoint",
                newName: "IX_TaskPoint_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoints_ProjectRoleId",
                table: "TaskPoint",
                newName: "IX_TaskPoint_ProjectRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoints_PointId",
                table: "TaskPoint",
                newName: "IX_TaskPoint_PointId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPoints_MemberId",
                table: "TaskPoint",
                newName: "IX_TaskPoint_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ProjectId",
                table: "Tag",
                newName: "IX_Tag_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Sprints_ProjectId",
                table: "Sprint",
                newName: "IX_Sprint_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestTypes_ProjectId",
                table: "RequestType",
                newName: "IX_RequestType_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectValues_ValueTypeId",
                table: "ProjectValue",
                newName: "IX_ProjectValue_ValueTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectValues_ProjectId",
                table: "ProjectValue",
                newName: "IX_ProjectValue_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_TaskId",
                table: "Point",
                newName: "IX_Point_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Points_ProjectId",
                table: "Point",
                newName: "IX_Point_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UpdatedById",
                table: "Comment",
                newName: "IX_Comment_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TaskId",
                table: "Comment",
                newName: "IX_Comment_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CreatedById",
                table: "Comment",
                newName: "IX_Comment_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_CreatedById",
                table: "Attachment",
                newName: "IX_Attachment_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskVote",
                table: "TaskVote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatus",
                table: "TaskStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPoint",
                table: "TaskPoint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprint",
                table: "Sprint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestType",
                table: "RequestType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectValueType",
                table: "ProjectValueType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectValue",
                table: "ProjectValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Error",
                table: "Error",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Members_CreatedById",
                table: "Attachment",
                column: "CreatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Members_CreatedById",
                table: "Comment",
                column: "CreatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Tasks_TaskId",
                table: "Comment",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Members_UpdatedById",
                table: "Comment",
                column: "UpdatedById",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAttachment_Attachment_AttachmentId",
                table: "CommentAttachment",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAttachment_Comment_CommentId",
                table: "CommentAttachment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Projects_ProjectId",
                table: "Point",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Tasks_TaskId",
                table: "Point",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectValue_Projects_ProjectId",
                table: "ProjectValue",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectValue_ProjectValueType_ValueTypeId",
                table: "ProjectValue",
                column: "ValueTypeId",
                principalTable: "ProjectValueType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestType_Projects_ProjectId",
                table: "RequestType",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Projects_ProjectId",
                table: "Sprint",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Projects_ProjectId",
                table: "Tag",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RequestType_RequestTypeId",
                table: "Tasks",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprint_SprintId",
                table: "Tasks",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskType_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoint_Members_MemberId",
                table: "TaskPoint",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoint_Point_PointId",
                table: "TaskPoint",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoint_ProjectRoles_ProjectRoleId",
                table: "TaskPoint",
                column: "ProjectRoleId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPoint_Tasks_TaskId",
                table: "TaskPoint",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatus_Modules_ModuleId",
                table: "TaskStatus",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatus_Projects_ProjectId",
                table: "TaskStatus",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatus_TaskType_TaskTypeId",
                table: "TaskStatus",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTag_Tag_TagId",
                table: "TaskTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVote_Members_MemberId",
                table: "TaskVote",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVote_Point_PointId",
                table: "TaskVote",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVote_ProjectRoles_ProjectRoleId",
                table: "TaskVote",
                column: "ProjectRoleId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskVote_Tasks_TaskId",
                table: "TaskVote",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
