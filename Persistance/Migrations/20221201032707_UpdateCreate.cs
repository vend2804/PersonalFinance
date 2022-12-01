using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Category_Details",
                columns: table => new
                {
                    CatId = table.Column<int>(name: "Cat_Id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CatName = table.Column<string>(name: "Cat_Name", type: "TEXT", nullable: true),
                    CatDescription = table.Column<string>(name: "Cat_Description", type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created_By", type: "TEXT", nullable: true),
                    EntryDate = table.Column<DateTime>(name: "Entry_Date", type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Details", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Item_Details",
                columns: table => new
                {
                    ItemId = table.Column<int>(name: "Item_Id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(name: "Item_Name", type: "TEXT", nullable: true),
                    ItemDesc = table.Column<string>(name: "Item_Desc", type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(name: "Created_By", type: "TEXT", nullable: true),
                    EntryDate = table.Column<DateTime>(name: "Entry_Date", type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CatId = table.Column<int>(name: "Cat_Id", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Details", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Details_Category_Details_Cat_Id",
                        column: x => x.CatId,
                        principalTable: "Category_Details",
                        principalColumn: "Cat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense_Details",
                columns: table => new
                {
                    ExpId = table.Column<int>(name: "Exp_Id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(name: "Item_Id", type: "INTEGER", nullable: false),
                    ExpDesc = table.Column<string>(name: "Exp_Desc", type: "TEXT", nullable: true),
                    ExpAmount = table.Column<decimal>(name: "Exp_Amount", type: "TEXT", nullable: false),
                    ExpBy = table.Column<int>(name: "Exp_By", type: "INTEGER", nullable: false),
                    ExpDate = table.Column<DateTime>(name: "Exp_Date", type: "TEXT", nullable: false),
                    ExpMonthYear = table.Column<string>(name: "Exp_Month_Year", type: "TEXT", nullable: true),
                    Finalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense_Details", x => x.ExpId);
                    table.ForeignKey(
                        name: "FK_Expense_Details_Item_Details_Item_Id",
                        column: x => x.ItemId,
                        principalTable: "Item_Details",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenue_Details",
                columns: table => new
                {
                    RevId = table.Column<int>(name: "Rev_Id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(name: "Item_Id", type: "INTEGER", nullable: false),
                    RevDesc = table.Column<string>(name: "Rev_Desc", type: "TEXT", nullable: true),
                    RevAmount = table.Column<decimal>(name: "Rev_Amount", type: "TEXT", nullable: false),
                    RevBy = table.Column<int>(name: "Rev_By", type: "INTEGER", nullable: false),
                    RevDate = table.Column<DateTime>(name: "Rev_Date", type: "TEXT", nullable: false),
                    RevMonthYear = table.Column<string>(name: "Rev_Month_Year", type: "TEXT", nullable: true),
                    Finalized = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue_Details", x => x.RevId);
                    table.ForeignKey(
                        name: "FK_Revenue_Details_Item_Details_Item_Id",
                        column: x => x.ItemId,
                        principalTable: "Item_Details",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_Details_Item_Id",
                table: "Expense_Details",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Details_Cat_Id",
                table: "Item_Details",
                column: "Cat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_Details_Item_Id",
                table: "Revenue_Details",
                column: "Item_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense_Details");

            migrationBuilder.DropTable(
                name: "Revenue_Details");

            migrationBuilder.DropTable(
                name: "Item_Details");

            migrationBuilder.DropTable(
                name: "Category_Details");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Activities",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
