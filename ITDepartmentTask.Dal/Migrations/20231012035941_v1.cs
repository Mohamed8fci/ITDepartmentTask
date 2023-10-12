using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITDepartmentTask.Dal.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCategoryId = table.Column<int>(type: "int", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                        column: x => x.DeviceCategoryId,
                        principalTable: "DeviceCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyItems_DeviceCategories_DeviceCategoryID",
                        column: x => x.DeviceCategoryID,
                        principalTable: "DeviceCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PropertyValues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyItemId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyValues_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PropertyValues_PropertyItems_PropertyItemId",
                        column: x => x.PropertyItemId,
                        principalTable: "PropertyItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceCategoryId",
                table: "Devices",
                column: "DeviceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyItems_DeviceCategoryID",
                table: "PropertyItems",
                column: "DeviceCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_DeviceID",
                table: "PropertyValues",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_PropertyItemId",
                table: "PropertyValues",
                column: "PropertyItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyValues");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PropertyItems");

            migrationBuilder.DropTable(
                name: "DeviceCategories");
        }
    }
}
