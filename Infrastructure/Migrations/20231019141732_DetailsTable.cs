using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IPDetails",
                table: "IPDetails");

            migrationBuilder.RenameTable(
                name: "IPDetails",
                newName: "Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "IP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "IPDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IPDetails",
                table: "IPDetails",
                column: "IP");
        }
    }
}
