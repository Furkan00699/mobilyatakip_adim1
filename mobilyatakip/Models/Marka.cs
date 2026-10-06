namespace MobilyaTakip.Models
{
    public class Marka
    {
        public int MarkaID { get; set; }

        public string MarkaAdi { get; set; } = "";

        // Bir markanın birden fazla malzeme olabilir
        public ICollection<Malzeme> Malzemeler { get; set; } = new List<Malzeme>();
    }
}