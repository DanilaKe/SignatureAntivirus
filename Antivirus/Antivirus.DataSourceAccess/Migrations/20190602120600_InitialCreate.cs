using Microsoft.EntityFrameworkCore.Migrations;

namespace Antivirus.DataSourceAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    SignatureId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualSignature = table.Column<string>(nullable: false),
                    SignatureName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.SignatureId);
                });

            migrationBuilder.CreateTable(
                name: "Viruses",
                columns: table => new
                {
                    VirusId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SignatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viruses", x => x.VirusId);
                    table.ForeignKey(
                        name: "FK_Viruses_Signatures_SignatureId",
                        column: x => x.SignatureId,
                        principalTable: "Signatures",
                        principalColumn: "SignatureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viruses_SignatureId",
                table: "Viruses",
                column: "SignatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viruses");

            migrationBuilder.DropTable(
                name: "Signatures");
        }
    }
}
