using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task8.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProductSupplyRequestTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId1",
                table: "supplyRequests");

            migrationBuilder.DropIndex(
                name: "IX_supplyRequests_UserId1",
                table: "supplyRequests");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "supplyRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "supplyRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_supplyRequests_UserId",
                table: "supplyRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId",
                table: "supplyRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId",
                table: "supplyRequests");

            migrationBuilder.DropIndex(
                name: "IX_supplyRequests_UserId",
                table: "supplyRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "supplyRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "supplyRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supplyRequests_UserId1",
                table: "supplyRequests",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_supplyRequests_AspNetUsers_UserId1",
                table: "supplyRequests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
