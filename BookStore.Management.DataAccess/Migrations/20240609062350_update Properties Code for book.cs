using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatePropertiesCodeforbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Avaiable",
                table: "Book",
                newName: "Available");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Book",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Book",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Book",
                newName: "Avaiable");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Book",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
