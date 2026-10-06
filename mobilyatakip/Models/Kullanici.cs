namespace MobilyaTakip.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; } = "";

        public string Sifre { get; set; } = "";

        public string Rol { get; set; } = "";

        // Bir kullanıcının birden fazla stok hareketi olabilir
        public ICollection<StokHareketi> StokHareketleri { get; set; } = new List<StokHareketi>();
    }
}