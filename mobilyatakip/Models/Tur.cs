namespace MobilyaTakip.Models
{
    public class Tur
    {
        public int TurID { get; set; }

        public string TurAdi { get; set; } = "";

        // Bir türün birden fazla malzeme olabilir
        public ICollection<Malzeme> Malzemeler { get; set; } = new List<Malzeme>();
    }
}