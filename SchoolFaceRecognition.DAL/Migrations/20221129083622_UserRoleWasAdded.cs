using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class UserRoleWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "ROLE_ID",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.CreateTable(
                name: "USERS_ROLES",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false),
                    CREATER_USER = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATER_USER = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMOVER_USER = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    REMOVING_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_ROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "AUTH",
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERS_ROLES_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "AUTH",
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "AUTH",
                table: "ROLES",
                columns: new[] { "ID", "CREATER_USER", "CREATION_DATE", "IS_DELETED", "NAME", "REMOVER_USER", "REMOVING_DATE", "UPDATE_DATE", "UPDATER_USER" },
                values: new object[] { 1, "Admin", new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(480), false, "Teacher", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "AUTH",
                table: "ROLES",
                columns: new[] { "ID", "CREATER_USER", "CREATION_DATE", "IS_DELETED", "NAME", "REMOVER_USER", "REMOVING_DATE", "UPDATE_DATE", "UPDATER_USER" },
                values: new object[] { 2, "Admin", new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(541), false, "Director", null, null, null, null });

            migrationBuilder.InsertData(
                schema: "AUTH",
                table: "ROLES",
                columns: new[] { "ID", "CREATER_USER", "CREATION_DATE", "IS_DELETED", "NAME", "REMOVER_USER", "REMOVING_DATE", "UPDATE_DATE", "UPDATER_USER" },
                values: new object[] { 3, "Admin", new DateTime(2022, 11, 29, 12, 36, 22, 541, DateTimeKind.Local).AddTicks(543), false, "Admin", null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_ROLE_ID_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES",
                columns: new[] { "ROLE_ID", "USER_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_USER_ID",
                schema: "AUTH",
                table: "USERS_ROLES",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS_ROLES",
                schema: "AUTH");

            migrationBuilder.DeleteData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                column: "ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                column: "ROLE_ID",
                principalSchema: "AUTH",
                principalTable: "ROLES",
                principalColumn: "ID");
        }
    }
}
