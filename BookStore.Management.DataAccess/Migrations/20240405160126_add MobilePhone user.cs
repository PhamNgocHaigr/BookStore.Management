using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMobilePhoneuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Users");
        }
    }
}
