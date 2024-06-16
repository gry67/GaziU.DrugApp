using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaziU.DrugApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoktorId",
                table: "doktorMuayeneKayitlari",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_doktorMuayeneKayitlari_DoktorId",
                table: "doktorMuayeneKayitlari",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_doktorMuayeneKayitlari_Doktorlar_DoktorId",
                table: "doktorMuayeneKayitlari",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doktorMuayeneKayitlari_Doktorlar_DoktorId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_doktorMuayeneKayitlari_DoktorId",
                table: "doktorMuayeneKayitlari");

            migrationBuilder.DropColumn(
                name: "DoktorId",
                table: "doktorMuayeneKayitlari");
        }
    }
}
