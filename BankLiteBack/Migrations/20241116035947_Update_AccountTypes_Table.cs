using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLiteBack.Migrations
{
    /// <inheritdoc />
    public partial class Update_AccountTypes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypesAccounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypesId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypesId",
                table: "Accounts",
                column: "AccountTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypesId",
                table: "Accounts",
                column: "AccountTypesId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypesId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypesId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountTypesId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "AccountTypesAccounts",
                columns: table => new
                {
                    AccountTypesId = table.Column<int>(type: "int", nullable: false),
                    AccountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypesAccounts", x => new { x.AccountTypesId, x.AccountsId });
                    table.ForeignKey(
                        name: "FK_AccountTypesAccounts_AccountTypes_AccountTypesId",
                        column: x => x.AccountTypesId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTypesAccounts_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypesAccounts_AccountsId",
                table: "AccountTypesAccounts",
                column: "AccountsId");
        }
    }
}
