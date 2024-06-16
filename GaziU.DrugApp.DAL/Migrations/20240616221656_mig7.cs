using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaziU.DrugApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktorMuayeneKayitlari_Doktorlar_DoktorId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_doktorMuayeneKayitlari_Hastalar_hastaId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_doktorMuayeneKayitlari_DoktorId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_doktorMuayeneKayitlari_hastaId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.RenameColumn(
                name: "hastaId",
                table: "doktorMuayeneKayitlari",
                newName: "HastaId");

            migrationBuilder.RenameColumn(
                name: "MuayeneNotları",
                table: "doktorMuayeneKayitlari",
                newName: "MuayeneNotlari");

            migrationBuilder.CreateTable(
                name: "DoktorDoktorMuayeneKaydi",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    DoktorMuayeneKayitlariId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorDoktorMuayeneKaydi", x => new { x.DoktorId, x.DoktorMuayeneKayitlariId });
                    table.ForeignKey(
                        name: "FK_DoktorDoktorMuayeneKaydi_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorDoktorMuayeneKaydi_doktorMuayeneKayitlari_DoktorMuayeneKayitlariId",
                        column: x => x.DoktorMuayeneKayitlariId,
                        principalTable: "doktorMuayeneKayitlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoktorMuayeneKaydiHasta",
                columns: table => new
                {
                    DoktorMuayeneKayitlariId = table.Column<int>(type: "int", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorMuayeneKaydiHasta", x => new { x.DoktorMuayeneKayitlariId, x.HastaId });
                    table.ForeignKey(
                        name: "FK_DoktorMuayeneKaydiHasta_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorMuayeneKaydiHasta_doktorMuayeneKayitlari_DoktorMuayeneKayitlariId",
                        column: x => x.DoktorMuayeneKayitlariId,
                        principalTable: "doktorMuayeneKayitlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorDoktorMuayeneKaydi_DoktorMuayeneKayitlariId",
                table: "DoktorDoktorMuayeneKaydi",
                column: "DoktorMuayeneKayitlariId");

            migrationBuilder.CreateIndex(
                name: "IX_DoktorMuayeneKaydiHasta_HastaId",
                table: "DoktorMuayeneKaydiHasta",
                column: "HastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorDoktorMuayeneKaydi");

            migrationBuilder.DropTable(
                name: "DoktorMuayeneKaydiHasta");

            migrationBuilder.RenameColumn(
                name: "HastaId",
                table: "doktorMuayeneKayitlari",
                newName: "hastaId");

            migrationBuilder.RenameColumn(
                name: "MuayeneNotlari",
                table: "doktorMuayeneKayitlari",
                newName: "MuayeneNotları");

            migrationBuilder.CreateIndex(
                name: "IX_doktorMuayeneKayitlari_DoktorId",
                table: "doktorMuayeneKayitlari",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_doktorMuayeneKayitlari_hastaId",
                table: "doktorMuayeneKayitlari",
                column: "hastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktorMuayeneKayitlari_Doktorlar_DoktorId",
                table: "doktorMuayeneKayitlari",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doktorMuayeneKayitlari_Hastalar_hastaId",
                table: "doktorMuayeneKayitlari",
                column: "hastaId",
                principalTable: "Hastalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
