using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLiteBack.Migrations
{
    /// <inheritdoc />
    public partial class Add_AccountTypes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypesAccounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
