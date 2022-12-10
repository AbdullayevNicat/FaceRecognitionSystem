using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class RefreshTokenWasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REFRESH_TOKEN",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOKEN = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EXPIRATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_REFRESH_TOKEN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REFRESH_TOKEN_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "AUTH",
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_REFRESH_TOKEN_UserId",
                schema: "AUTH",
                table: "REFRESH_TOKEN",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REFRESH_TOKEN",
                schema: "AUTH");
        }
    }
}
