using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientTracker.Migrations
{
    public partial class clientDisorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisorderId",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Disorder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disorder_ClientId",
                table: "Disorder",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disorder_Client_ClientId",
                table: "Disorder",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disorder_Client_ClientId",
                table: "Disorder");

            migrationBuilder.DropIndex(
                name: "IX_Disorder_ClientId",
                table: "Disorder");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Disorder");

            migrationBuilder.RenameColumn(
                name: "DisorderId",
                table: "Client",
                newName: "ApplicationUserId");
        }
    }
}
