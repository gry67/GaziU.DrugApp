using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaziU.DrugApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HalfLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "BeckAnksiyeteKayitlari",
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
                    table.PrimaryKey("PK_BeckAnksiyeteKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeckAnksiyeteKayitlari_Hastalar_hastaId",
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

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineTypeId = table.Column<int>(type: "int", nullable: false),
                    ActiveIngredientId = table.Column<int>(type: "int", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_ActiveIngredients_ActiveIngredientId",
                        column: x => x.ActiveIngredientId,
                        principalTable: "ActiveIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drugs_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drugs_MedicineTypes_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuayeneKayitlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuayeneNotu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    HastaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuayeneKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MuayeneKayitlari_Doktorlar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktorlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MuayeneKayitlari_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HastaIlacKayitlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaId = table.Column<int>(type: "int", nullable: false),
                    IlacId = table.Column<int>(type: "int", nullable: false),
                    KullanimBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HastaIlacKayitlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HastaIlacKayitlari_Drugs_IlacId",
                        column: x => x.IlacId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HastaIlacKayitlari_Hastalar_HastaId",
                        column: x => x.HastaId,
                        principalTable: "Hastalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarnesAkatiziKayitlari_hastaId",
                table: "BarnesAkatiziKayitlari",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_BeckAnksiyeteKayitlari_hastaId",
                table: "BeckAnksiyeteKayitlari",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_BeckDepresyonKayitlari_hastaId",
                table: "BeckDepresyonKayitlari",
                column: "hastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_ActiveIngredientId",
                table: "Drugs",
                column: "ActiveIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_HastaId",
                table: "Drugs",
                column: "HastaId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_MedicineTypeId",
                table: "Drugs",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaIlacKayitlari_HastaId",
                table: "HastaIlacKayitlari",
                column: "HastaId");

            migrationBuilder.CreateIndex(
                name: "IX_HastaIlacKayitlari_IlacId",
                table: "HastaIlacKayitlari",
                column: "IlacId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_DoktorId",
                table: "Hastalar",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_MuayeneKayitlari_DoktorId",
                table: "MuayeneKayitlari",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_MuayeneKayitlari_HastaId",
                table: "MuayeneKayitlari",
                column: "HastaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarnesAkatiziKayitlari");

            migrationBuilder.DropTable(
                name: "BeckAnksiyeteKayitlari");

            migrationBuilder.DropTable(
                name: "BeckDepresyonKayitlari");

            migrationBuilder.DropTable(
                name: "HastaIlacKayitlari");

            migrationBuilder.DropTable(
                name: "MuayeneKayitlari");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "ActiveIngredients");

            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DropTable(
                name: "Doktorlar");
        }
    }
}
