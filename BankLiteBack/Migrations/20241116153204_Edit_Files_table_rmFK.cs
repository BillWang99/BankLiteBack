using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLiteBack.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Files_table_rmFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Transactions_TransactionsId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionsId",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Transactions_TransactionsId",
                table: "Files",
                column: "TransactionsId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Transactions_TransactionsId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionsId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Transactions_TransactionsId",
                table: "Files",
                column: "TransactionsId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
