namespace MobilyaTakip.Models
{
    public class StokHareketi
    {
        public int HareketID { get; set; }

        // Dış anahtar (Foreign Key) özellikleri
        public int MalzemeID { get; set; }
        public int KullaniciID { get; set; }

        // Hareket özellikleri
        public string IslemTuru { get; set; } = ""; // "Giriş" veya "Çıkış"
        public int Miktar { get; set; }
        public DateTime Tarih { get; set; }

        // Navigation Properties (ilişkiler)
        public Malzeme Malzeme { get; set; } = null!;
        public Kullanici Kullanici { get; set; } = null!;
    }
}
