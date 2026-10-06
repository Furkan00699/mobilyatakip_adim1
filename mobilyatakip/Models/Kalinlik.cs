namespace MobilyaTakip.Models
{
    public class Kalinlik
    {
        public int KalinlikID { get; set; }

        public string Deger { get; set; } = "";

        // Bir kalınlığın birden fazla malzeme olabilir
        public ICollection<Malzeme> Malzemeler { get; set; } = new List<Malzeme>();
    }
}
