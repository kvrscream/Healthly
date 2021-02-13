using Microsoft.EntityFrameworkCore.Migrations;

namespace Heathly.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "PlanosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(nullable: true),
                    PlanosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanosCliente_Clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanosCliente_Planos_PlanosId",
                        column: x => x.PlanosId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanosCliente_ClientId",
                table: "PlanosCliente",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosCliente_PlanosId",
                table: "PlanosCliente",
                column: "PlanosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanosCliente");

           
        }
    }
}
