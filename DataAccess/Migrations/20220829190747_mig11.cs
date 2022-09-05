using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SListId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products",
                column: "SListId",
                principalTable: "SList",
                principalColumn: "SListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SListId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SList_SListId",
                table: "Products",
                column: "SListId",
                principalTable: "SList",
                principalColumn: "SListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
