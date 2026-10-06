namespace MobilyaTakip.Models
{
    public class Malzeme
    {
        public int MalzemeID { get; set; }

        // Dış anahtar (Foreign Key) özellikleri
        public int TurID { get; set; }
        public int MarkaID { get; set; }
        public int KaplamaID { get; set; }
        public int KalinlikID { get; set; }

        // Malzeme özellikleri
        public decimal En { get; set; }
        public decimal Boy { get; set; }
        public int StokMiktari { get; set; }
        public int MinimumStok { get; set; }

        // Navigation Properties (ilişkiler)
        public Tur Tur { get; set; } = null!;
        public Marka Marka { get; set; } = null!;
        public Kaplama Kaplama { get; set; } = null!;
        public Kalinlik Kalinlik { get; set; } = null!;

        // Bir malzemenin birden fazla stok hareketi olabilir
        public ICollection<StokHareketi> StokHareketleri { get; set; } = new List<StokHareketi>();
    }
}
