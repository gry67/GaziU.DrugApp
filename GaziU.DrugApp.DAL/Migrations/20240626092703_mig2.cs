using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaziU.DrugApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Doktorlar_DoktorId",
                table: "Hastalar");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorId",
                table: "Hastalar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Doktorlar_DoktorId",
                table: "Hastalar",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastalar_Doktorlar_DoktorId",
                table: "Hastalar");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorId",
                table: "Hastalar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hastalar_Doktorlar_DoktorId",
                table: "Hastalar",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
