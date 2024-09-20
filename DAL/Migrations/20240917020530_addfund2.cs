using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addfund2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_fund");

            migrationBuilder.CreateTable(
                name: "trn_fund",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    loan_id = table.Column<string>(type: "text", nullable: false),
                    lender_id = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    funded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trn_fund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trn_fund_mst_loans_loan_id",
                        column: x => x.loan_id,
                        principalTable: "mst_loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trn_fund_mst_user_lender_id",
                        column: x => x.lender_id,
                        principalTable: "mst_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trn_fund_lender_id",
                table: "trn_fund",
                column: "lender_id");

            migrationBuilder.CreateIndex(
                name: "IX_trn_fund_loan_id",
                table: "trn_fund",
                column: "loan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trn_fund");

            migrationBuilder.CreateTable(
                name: "mst_fund",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    lender_id = table.Column<string>(type: "text", nullable: false),
                    loan_id = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    funded_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_fund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mst_fund_mst_loans_loan_id",
                        column: x => x.loan_id,
                        principalTable: "mst_loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mst_fund_mst_user_lender_id",
                        column: x => x.lender_id,
                        principalTable: "mst_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mst_fund_lender_id",
                table: "mst_fund",
                column: "lender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mst_fund_loan_id",
                table: "mst_fund",
                column: "loan_id");
        }
    }
}
