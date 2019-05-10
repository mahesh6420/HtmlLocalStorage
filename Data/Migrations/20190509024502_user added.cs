using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalStorage.Data.Migrations
{
    public partial class useradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPhoneDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Phone = table.Column<string>(nullable: true),
                    UserMasterModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhoneDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhoneDetail_UserMaster_UserMasterModelId",
                        column: x => x.UserMasterModelId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhoneDetail_UserMasterModelId",
                table: "UserPhoneDetail",
                column: "UserMasterModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPhoneDetail");

            migrationBuilder.DropTable(
                name: "UserMaster");
        }
    }
}
