using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPSGERewrite.DataService.Migrations
{
    /// <inheritdoc />
    public partial class addedImageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Mouse",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Keyboard",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Mouse");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Keyboard");
        }
    }
}
