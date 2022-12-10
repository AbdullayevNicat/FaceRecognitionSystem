using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class USERANDROLEWASADDED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AUTH");

            migrationBuilder.CreateTable(
                name: "ROLES",
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
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AGE = table.Column<byte>(type: "tinyint", nullable: true),
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
                    table.PrimaryKey("PK_USERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "AUTH",
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "UK_USERS_EMAIL",
                schema: "AUTH",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS",
                schema: "AUTH");

            migrationBuilder.DropTable(
                name: "ROLES",
                schema: "AUTH");
        }
    }
}
