using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SList",
                newName: "SListId");

            migrationBuilder.AddColumn<int>(
                name: "SListId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SListId",
                table: "Products",
                column: "SListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products",
                column: "SListId",
                principalTable: "SList",
                principalColumn: "SListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SListId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SListId",
                table: "SList",
                newName: "Id");
        }
    }
}
