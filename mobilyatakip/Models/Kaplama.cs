namespace MobilyaTakip.Models
{
    public class Kaplama
    {
        public int KaplamaID { get; set; }

        public string KaplamaAdi { get; set; } = "";

        // Bir kaplamanın birden fazla malzeme olabilir
        public ICollection<Malzeme> Malzemeler { get; set; } = new List<Malzeme>();
    }
}
