using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLiteBack.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Transaction_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Transactions",
                newName: "IsDelete");

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Transactions",
                newName: "IsDeleted");
        }
    }
}
