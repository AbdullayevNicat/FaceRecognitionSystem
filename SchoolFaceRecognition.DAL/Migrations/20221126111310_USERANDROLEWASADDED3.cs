using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class USERANDROLEWASADDED3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.AlterColumn<int>(
                name: "ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                column: "ROLE_ID",
                principalSchema: "AUTH",
                principalTable: "ROLES",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS");

            migrationBuilder.AlterColumn<int>(
                name: "ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLE_ID",
                schema: "AUTH",
                table: "USERS",
                column: "ROLE_ID",
                principalSchema: "AUTH",
                principalTable: "ROLES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
