using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypesIDID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attributes_Types_TypesIDID",
                        column: x => x.TypesIDID,
                        principalTable: "Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypesIDID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Objects_Types_TypesIDID",
                        column: x => x.TypesIDID,
                        principalTable: "Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ObjectIDID = table.Column<Guid>(nullable: true),
                    AttributeIDID = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parameters_Attributes_AttributeIDID",
                        column: x => x.AttributeIDID,
                        principalTable: "Attributes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parameters_Objects_ObjectIDID",
                        column: x => x.ObjectIDID,
                        principalTable: "Objects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_TypesIDID",
                table: "Attributes",
                column: "TypesIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_TypesIDID",
                table: "Objects",
                column: "TypesIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_AttributeIDID",
                table: "Parameters",
                column: "AttributeIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ObjectIDID",
                table: "Parameters",
                column: "ObjectIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
