using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mobilyatakip.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Şifre örnekleri (hash'lenmiş)
            // admin123 için hash
            string adminSifreHash = "AHxvWMQj/t1hvqM42x+kcO3vwJANx0V7V4v7Y7gFh3pMPJ4F0LlvkSGfaU2ij0CtVA==";
            // personel123 için hash
            string personelSifreHash = "AHhYpfgI8r1pvqM42x+kcO3vwJANx0V7V4v7Y7gFh3pMPJ4F0LlvkSGfaU2ij0CtVA==";

            // Admin kullanıcı ekle
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciAdi", "Sifre", "Rol" },
                values: new object[] { "admin", adminSifreHash, "Admin" }
            );

            // Personel kullanıcı ekle
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciAdi", "Sifre", "Rol" },
                values: new object[] { "personel", personelSifreHash, "Personel" }
            );

            // Örnek Türler ekle
            migrationBuilder.InsertData(
                table: "Turlar",
                columns: new[] { "TurAdi" },
                values: new object[] { "MDF" }
            );

            migrationBuilder.InsertData(
                table: "Turlar",
                columns: new[] { "TurAdi" },
                values: new object[] { "Masif Ağaç" }
            );

            // Örnek Markalar ekle
            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "MarkaAdi" },
                values: new object[] { "Glossmax" }
            );

            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "MarkaAdi" },
                values: new object[] { "Kastamonu" }
            );

            // Örnek Kaplamalar ekle
            migrationBuilder.InsertData(
                table: "Kaplamalar",
                columns: new[] { "KaplamaAdi" },
                values: new object[] { "Parlak" }
            );

            migrationBuilder.InsertData(
                table: "Kaplamalar",
                columns: new[] { "KaplamaAdi" },
                values: new object[] { "Mat" }
            );

            // Örnek Kalınlıklar ekle
            migrationBuilder.InsertData(
                table: "Kalinliklar",
                columns: new[] { "Deger" },
                values: new object[] { "18 mm" }
            );

            migrationBuilder.InsertData(
                table: "Kalinliklar",
                columns: new[] { "Deger" },
                values: new object[] { "25 mm" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Silme işlemleri (geri alma)
            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciAdi",
                keyValue: "admin"
            );

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciAdi",
                keyValue: "personel"
            );

            migrationBuilder.DeleteData(
                table: "Turlar",
                keyColumn: "TurAdi",
                keyValue: "MDF"
            );

            migrationBuilder.DeleteData(
                table: "Turlar",
                keyColumn: "TurAdi",
                keyValue: "Masif Ağaç"
            );

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "MarkaAdi",
                keyValue: "Glossmax"
            );

            migrationBuilder.DeleteData(
                table: "Markalar",
                keyColumn: "MarkaAdi",
                keyValue: "Kastamonu"
            );

            migrationBuilder.DeleteData(
                table: "Kaplamalar",
                keyColumn: "KaplamaAdi",
                keyValue: "Parlak"
            );

            migrationBuilder.DeleteData(
                table: "Kaplamalar",
                keyColumn: "KaplamaAdi",
                keyValue: "Mat"
            );

            migrationBuilder.DeleteData(
                table: "Kalinliklar",
                keyColumn: "Deger",
                keyValue: "18 mm"
            );

            migrationBuilder.DeleteData(
                table: "Kalinliklar",
                keyColumn: "Deger",
                keyValue: "25 mm"
            );
        }
    }
}
