using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaziU.DrugApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ToplamPuan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru9Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru8Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru7Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru6Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru5Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru4Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru3Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru2Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru1Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Soru10Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte>(
                name: "Soru11Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru12Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru13Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru14Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru15Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru16Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru17Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru18Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru19Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru20Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Soru21Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "BarnesAkatiziKayitlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hastaId = table.Column<int>(type: "int", nullable: false),
                    Soru1Puan = table.Column<int>(type: "int", nullable: false),
                    Soru2Puan = table.Column<int>(type: "int", nullable: false),
                    Soru3Puan = table.Column<int>(type: "int", nullable: false),
                    Soru4Puan = table.Column<int>(type: "int", nullable: false),
                    Soru5Puan = table.Column<int>(type: "int", nullable: false),
                    Soru6Puan = table.Column<int>(type: "int", nullable: false),
                    Soru7Puan = table.Column<int>(type: "int", nullable: false),
                    Soru8Puan = table.Column<int>(type: "int", nullable: false),
                    Soru9Puan = table.Column<int>(type: "int", nullable: false),
                    Soru10Puan = table.Column<int>(type: "int", nullable: false),
                    ToplamPuan = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarnesAkatiziKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarnesAkatiziKayitlari_Hastalar_hastaId",
                        column: x => x.hastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeckDepresyonKayitlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hastaId = table.Column<int>(type: "int", nullable: false),
                    Soru1Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru2Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru3Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru4Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru5Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru6Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru7Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru8Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru9Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru10Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru11Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru12Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru13Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru14Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru15Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru16Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru17Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru18Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru19Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru20Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    Soru21Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    ToplamPuan = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeckDepresyonKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeckDepresyonKayitlari_Hastalar_hastaId",
                        column: x => x.hastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarnesAkatiziKayitlari_hastaId",
                table: "BarnesAkatiziKayitlari",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_BeckDepresyonKayitlari_hastaId",
                table: "BeckDepresyonKayitlari",
                column: "hastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarnesAkatiziKayitlari");

            migrationBuilder.DropTable(
                name: "BeckDepresyonKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru11Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru12Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru13Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru14Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru15Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru16Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru17Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru18Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru19Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru20Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropColumn(
                name: "Soru21Puan",
                table: "BeckAnksiyeteKayitlari");

            migrationBuilder.AlterColumn<int>(
                name: "ToplamPuan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru9Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru8Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru7Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru6Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru5Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru4Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru3Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru2Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru1Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Soru10Puan",
                table: "BeckAnksiyeteKayitlari",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
