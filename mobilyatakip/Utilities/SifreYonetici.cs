using System.Security.Cryptography;
using System.Text;

namespace MobilyaTakip.Utilities
{
    /// <summary>
    /// Şifre hashleme ve doğrulama işlemleri için yardımcı sınıf
    /// Şifreler hiçbir zaman düz metin olarak veritabanında saklanmaz
    /// </summary>
    public static class SifreYonetici
    {
        /// <summary>
        /// Şifreyi güvenli bir şekilde hash'ler
        /// </summary>
        public static string SifreHashle(string sifre)
        {
            // 16 byte'lık random salt oluştur
            // Salt: Şifreyi hash'lerken eklenen rastgele veri
            // Her şifre için farklı salt kullanılır (güvenlik için)
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt); // Rastgele salt değerlerini doldur
            }

            // PBKDF2 algoritmasıyla şifreyi hash'le
            // Parametreler:
            // - sifre: Kullanıcının girdiği şifre
            // - salt: Rastgele oluşturulan salt değeri
            // - 10000: Döngü sayısı (ne kadar çok, o kadar güvenli ama yavaş)
            // - SHA256: Kullanılacak hash algoritması
            var pbkdf2 = new Rfc2898DeriveBytes(sifre, salt, 10000, HashAlgorithmName.SHA256);

            // Hash sonucunu 20 byte olarak al
            byte[] hash = pbkdf2.GetBytes(20);

            // Salt ve hash'i birleştir (toplam 36 byte)
            // İlk 16 byte: salt
            // Son 20 byte: hash
            byte[] hashSaltBirlesik = new byte[36];
            Array.Copy(salt, 0, hashSaltBirlesik, 0, 16);      // Salt'ı başa koy
            Array.Copy(hash, 0, hashSaltBirlesik, 16, 20);     // Hash'i sona koy

            // Veritabanında saklamak için Base64'e çevir
            // Base64: Binary veriyi metin formatına çevirme yöntemi
            return Convert.ToBase64String(hashSaltBirlesik);
        }

        /// <summary>
        /// Kullanıcının girdiği şifreyi, veritabanındaki saklanmış hash ile karşılaştırır
        /// </summary>
        public static bool SifreDogrula(string girilenSifre, string sakliHash)
        {
            // Base64'den byte dizisine geri çevir
            byte[] hashSaltBirlesik = Convert.FromBase64String(sakliHash);

            // Salt'ı ayıkla (ilk 16 byte)
            byte[] salt = new byte[16];
            Array.Copy(hashSaltBirlesik, 0, salt, 0, 16);

            // Kullanıcının girdiği şifreyi, saklanmış salt ile hash'le
            // Aynı şifre + aynı salt = aynı hash (matematik garantisiyle)
            var pbkdf2 = new Rfc2898DeriveBytes(girilenSifre, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Hesaplanan hash'i saklanmış hash ile kıyasla
            // Eşleşiyorsa şifre doğrudur
            for (int i = 0; i < 20; i++)
            {
                if (hashSaltBirlesik[i + 16] != hash[i])
                    return false; // Bir byte bile farklıysa şifre yanlış
            }

            return true; // Tüm byteler eşleşti, şifre doğru
        }
    }
}

