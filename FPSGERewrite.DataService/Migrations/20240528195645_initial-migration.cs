using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSGERewrite.DataService.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keyboard",
                columns: table => new
                {
                    KeyboardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CableLength = table.Column<string>(type: "TEXT", nullable: false),
                    SwitchType = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    RGB = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboard", x => x.KeyboardId);
                });

            migrationBuilder.CreateTable(
                name: "Mouse",
                columns: table => new
                {
                    MouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalKeys = table.Column<string>(type: "TEXT", nullable: false),
                    SensorType = table.Column<string>(type: "TEXT", nullable: false),
                    RGB = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse", x => x.MouseId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCondition = table.Column<string>(type: "TEXT", nullable: false),
                    MouseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    KeyboardId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Keyboard_KeyboardId",
                        column: x => x.KeyboardId,
                        principalTable: "Keyboard",
                        principalColumn: "KeyboardId");
                    table.ForeignKey(
                        name: "FK_Product_Mouse_MouseId",
                        column: x => x.MouseId,
                        principalTable: "Mouse",
                        principalColumn: "MouseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_KeyboardId",
                table: "Product",
                column: "KeyboardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_MouseId",
                table: "Product",
                column: "MouseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Keyboard");

            migrationBuilder.DropTable(
                name: "Mouse");
        }
    }
}
