//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace ATM.Migrations
//{
//    /// <inheritdoc />
//    public partial class InitialCreate : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "accounts",
//                columns: table => new
//                {
//                    AccountNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    CardNumber = table.Column<int>(type: "int", nullable: false),
//                    Pin = table.Column<int>(type: "int", nullable: false),
//                    Balance = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_accounts", x => x.AccountNo);
//                });

//            migrationBuilder.CreateTable(
//                name: "transactions",
//                columns: table => new
//                {
//                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    AccountNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    TransactionType = table.Column<int>(type: "int", nullable: false),
//                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
//                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_transactions", x => x.TransactionId);
//                    table.ForeignKey(
//                        name: "FK_transactions_accounts_AccountNo",
//                        column: x => x.AccountNo,
//                        principalTable: "accounts",
//                        principalColumn: "AccountNo",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_transactions_AccountNo",
//                table: "transactions",
//                column: "AccountNo");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "transactions");

//            migrationBuilder.DropTable(
//                name: "accounts");
//        }
//    }
//}
