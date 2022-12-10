using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class UserIdRoleIdUniqueWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USERS_ROLES_ROLE_ID_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES");

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 1,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 30, 7, 55, 0, 152, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 2,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 30, 7, 55, 0, 152, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 3,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 30, 7, 55, 0, 152, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_ROLE_ID_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES",
                columns: new[] { "ROLE_ID", "USER_ID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USERS_ROLES_ROLE_ID_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES");

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 1,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 2,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 3,
                column: "CREATION_DATE",
                value: new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_ROLE_ID_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES",
                columns: new[] { "ROLE_ID", "USER_ID" });
        }
    }
}
