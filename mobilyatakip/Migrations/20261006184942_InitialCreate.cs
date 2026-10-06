using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mobilyatakip.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kalinliklar",
                columns: table => new
                {
                    KalinlikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kalinliklar", x => x.KalinlikID);
                });

            migrationBuilder.CreateTable(
                name: "Kaplamalar",
                columns: table => new
                {
                    KaplamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaplamaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaplamalar", x => x.KaplamaID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    MarkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.MarkaID);
                });

            migrationBuilder.CreateTable(
                name: "Turlar",
                columns: table => new
                {
                    TurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turlar", x => x.TurID);
                });

            migrationBuilder.CreateTable(
                name: "Malzemeler",
                columns: table => new
                {
                    MalzemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurID = table.Column<int>(type: "int", nullable: false),
                    MarkaID = table.Column<int>(type: "int", nullable: false),
                    KaplamaID = table.Column<int>(type: "int", nullable: false),
                    KalinlikID = table.Column<int>(type: "int", nullable: false),
                    En = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Boy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokMiktari = table.Column<int>(type: "int", nullable: false),
                    MinimumStok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzemeler", x => x.MalzemeID);
                    table.ForeignKey(
                        name: "FK_Malzemeler_Kalinliklar_KalinlikID",
                        column: x => x.KalinlikID,
                        principalTable: "Kalinliklar",
                        principalColumn: "KalinlikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Malzemeler_Kaplamalar_KaplamaID",
                        column: x => x.KaplamaID,
                        principalTable: "Kaplamalar",
                        principalColumn: "KaplamaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Malzemeler_Markalar_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Markalar",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Malzemeler_Turlar_TurID",
                        column: x => x.TurID,
                        principalTable: "Turlar",
                        principalColumn: "TurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketleri",
                columns: table => new
                {
                    HareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    IslemTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketleri", x => x.HareketID);
                    table.ForeignKey(
                        name: "FK_StokHareketleri_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StokHareketleri_Malzemeler_MalzemeID",
                        column: x => x.MalzemeID,
                        principalTable: "Malzemeler",
                        principalColumn: "MalzemeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_KalinlikID",
                table: "Malzemeler",
                column: "KalinlikID");

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_KaplamaID",
                table: "Malzemeler",
                column: "KaplamaID");

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_MarkaID",
                table: "Malzemeler",
                column: "MarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Malzemeler_TurID",
                table: "Malzemeler",
                column: "TurID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_KullaniciID",
                table: "StokHareketleri",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketleri_MalzemeID",
                table: "StokHareketleri",
                column: "MalzemeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StokHareketleri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Malzemeler");

            migrationBuilder.DropTable(
                name: "Kalinliklar");

            migrationBuilder.DropTable(
                name: "Kaplamalar");

            migrationBuilder.DropTable(
                name: "Markalar");

            migrationBuilder.DropTable(
                name: "Turlar");
        }
    }
}
