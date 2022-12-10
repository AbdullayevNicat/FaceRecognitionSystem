using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class USERANDROLEWASADDED2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                schema: "AUTH",
                table: "USERS",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "UK_USERS_USER_NAME",
                schema: "AUTH",
                table: "USERS",
                column: "USER_NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_USERS_USER_NAME",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                schema: "AUTH",
                table: "USERS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
