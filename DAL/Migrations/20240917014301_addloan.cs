using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addloan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "mst_user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "mst_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "mst_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "mst_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "mst_user",
                newName: "balance");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "mst_user",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "mst_user",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "mst_loans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    borrower_id = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    interest_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    duration_in_months = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mst_loans_mst_user_borrower_id",
                        column: x => x.borrower_id,
                        principalTable: "mst_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mst_loans_borrower_id",
                table: "mst_loans",
                column: "borrower_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_loans");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "mst_user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "mst_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "mst_user",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "mst_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "mst_user",
                newName: "Balance");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "mst_user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "mst_user",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
