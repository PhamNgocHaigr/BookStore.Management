using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "BookCatalogue",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "Cart",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cart",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BookCatalogue",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BookCatalogue");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "BookCatalogue",
                newName: "CreateOn");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Cart",
                type: "bit",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Cart",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cart",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
