using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalStorage.Data.Migrations
{
    public partial class testmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestForm",
                columns: table => new
                {
                    Int = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    FatherFirstName = table.Column<string>(nullable: true),
                    FatherMiddleName = table.Column<string>(nullable: true),
                    FatherLastName = table.Column<string>(nullable: true),
                    MotherFirstName = table.Column<string>(nullable: true),
                    MotherMiddleName = table.Column<string>(nullable: true),
                    MotherLastName = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    FatherBirthPlace = table.Column<string>(nullable: true),
                    MotherBirthPlace = table.Column<string>(nullable: true),
                    FatherPhone = table.Column<string>(nullable: true),
                    MotherPhone = table.Column<string>(nullable: true),
                    SpouseFirstName = table.Column<string>(nullable: true),
                    SposeMiddleName = table.Column<string>(nullable: true),
                    SpouseLastName = table.Column<string>(nullable: true),
                    SpusePhone = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true),
                    WorkPlaceAddress = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FatherBirthDate = table.Column<DateTime>(nullable: false),
                    MotherBirthDate = table.Column<DateTime>(nullable: false),
                    SpouseBirthDate = table.Column<DateTime>(nullable: false),
                    SpouseBirthPlace = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestForm", x => x.Int);
                    table.ForeignKey(
                        name: "FK_TestForm_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestForm_CreatedBy",
                table: "TestForm",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestForm");
        }
    }
}
