using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class RolePermissionsWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_PERMISSIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES_PERMISSIONS",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false),
                    PERMISSION_ID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ROLES_PERMISSIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLES_PERMISSIONS_PERMISSIONS_PERMISSION_ID",
                        column: x => x.PERMISSION_ID,
                        principalSchema: "AUTH",
                        principalTable: "PERMISSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLES_PERMISSIONS_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "AUTH",
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "AUTH",
                table: "PERMISSIONS",
                columns: new[] { "ID", "CREATER_USER", "CREATION_DATE", "IS_DELETED", "NAME", "REMOVER_USER", "REMOVING_DATE", "UPDATE_DATE", "UPDATER_USER" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2022, 12, 6, 7, 52, 1, 94, DateTimeKind.Local).AddTicks(8577), false, "Read", null, null, null, null },
                    { 2, "Admin", new DateTime(2022, 12, 6, 7, 52, 1, 94, DateTimeKind.Local).AddTicks(8593), false, "Create", null, null, null, null },
                    { 3, "Admin", new DateTime(2022, 12, 6, 7, 52, 1, 94, DateTimeKind.Local).AddTicks(8594), false, "Update", null, null, null, null },
                    { 4, "Admin", new DateTime(2022, 12, 6, 7, 52, 1, 94, DateTimeKind.Local).AddTicks(8596), false, "Delete", null, null, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 1,
                column: "CREATION_DATE",
                value: new DateTime(2022, 12, 6, 7, 52, 1, 142, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 2,
                column: "CREATION_DATE",
                value: new DateTime(2022, 12, 6, 7, 52, 1, 142, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                schema: "AUTH",
                table: "ROLES",
                keyColumn: "ID",
                keyValue: 3,
                column: "CREATION_DATE",
                value: new DateTime(2022, 12, 6, 7, 52, 1, 142, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_PERMISSIONS_PERMISSION_ID",
                schema: "AUTH",
                table: "ROLES_PERMISSIONS",
                column: "PERMISSION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_PERMISSIONS_ROLE_ID_PERMISSION_ID",
                schema: "AUTH",
                table: "ROLES_PERMISSIONS",
                columns: new[] { "ROLE_ID", "PERMISSION_ID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROLES_PERMISSIONS",
                schema: "AUTH");

            migrationBuilder.DropTable(
                name: "PERMISSIONS",
                schema: "AUTH");

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
        }
    }
}
