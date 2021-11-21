using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyPaws.Data.Migrations
{
    public partial class HeaderDetailsShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalServiceHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServiceHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalServiceHeader_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalServiceShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(nullable: false),
                    MedicalServiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServiceShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalServiceShoppingCart_MedicalService_MedicalServiceID",
                        column: x => x.MedicalServiceID,
                        principalTable: "MedicalService",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalServiceShoppingCart_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalServiceHeaderId = table.Column<int>(nullable: false),
                    MedicalServiceID = table.Column<int>(nullable: false),
                    MedicalServicePrice = table.Column<double>(nullable: false),
                    MedicalServiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_MedicalServiceHeader_MedicalServiceHeaderId",
                        column: x => x.MedicalServiceHeaderId,
                        principalTable: "MedicalServiceHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_MedicalService_MedicalServiceID",
                        column: x => x.MedicalServiceID,
                        principalTable: "MedicalService",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_MedicalServiceHeaderId",
                table: "AppointmentDetails",
                column: "MedicalServiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_MedicalServiceID",
                table: "AppointmentDetails",
                column: "MedicalServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceHeader_PetId",
                table: "MedicalServiceHeader",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceShoppingCart_MedicalServiceID",
                table: "MedicalServiceShoppingCart",
                column: "MedicalServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceShoppingCart_PetId",
                table: "MedicalServiceShoppingCart",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "MedicalServiceShoppingCart");

            migrationBuilder.DropTable(
                name: "MedicalServiceHeader");
        }
    }
}
