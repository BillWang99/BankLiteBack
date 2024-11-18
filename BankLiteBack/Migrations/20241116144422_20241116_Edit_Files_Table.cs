using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLiteBack.Migrations
{
    /// <inheritdoc />
    public partial class _20241116_Edit_Files_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Files",
                newName: "UniqueName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniqueName",
                table: "Files",
                newName: "FileName");
        }
    }
}
