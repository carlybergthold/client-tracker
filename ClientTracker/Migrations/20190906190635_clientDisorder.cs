using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientTracker.Migrations
{
    public partial class clientDisorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DisorderId",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "ClientDisorder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisorderId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDisorder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDisorder_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDisorder_Disorder_DisorderId",
                        column: x => x.DisorderId,
                        principalTable: "Disorder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDisorder_ClientId",
                table: "ClientDisorder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDisorder_DisorderId",
                table: "ClientDisorder",
                column: "DisorderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDisorder");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Disorder",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisorderId",
                table: "Client",
                nullable: false,
                defaultValue: 0);

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
    }
}
