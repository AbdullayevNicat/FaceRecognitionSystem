using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFaceRecognition.DAL.Migrations
{
    public partial class ClientAndAudienceWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIENCES",
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
                    table.PrimaryKey("PK_AUDIENCES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTS",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_CLIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTSAUDIENCES",
                schema: "AUTH",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENT_ID = table.Column<int>(type: "int", nullable: false),
                    AUDIENCE_ID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CLIENTSAUDIENCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENTSAUDIENCES_AUDIENCE_ID",
                        column: x => x.AUDIENCE_ID,
                        principalSchema: "AUTH",
                        principalTable: "AUDIENCES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLIENTSAUDIENCES_CLIENT_ID",
                        column: x => x.CLIENT_ID,
                        principalSchema: "AUTH",
                        principalTable: "CLIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTSAUDIENCES_AUDIENCE_ID_CLIENT_ID",
                schema: "AUTH",
                table: "CLIENTSAUDIENCES",
                columns: new[] { "AUDIENCE_ID", "CLIENT_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTSAUDIENCES_CLIENT_ID",
                schema: "AUTH",
                table: "CLIENTSAUDIENCES",
                column: "CLIENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTSAUDIENCES",
                schema: "AUTH");

            migrationBuilder.DropTable(
                name: "AUDIENCES",
                schema: "AUTH");

            migrationBuilder.DropTable(
                name: "CLIENTS",
                schema: "AUTH");
        }
    }
}
