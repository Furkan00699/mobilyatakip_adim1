using MobilyaTakip.Data;
using MobilyaTakip.Models;

namespace mobilyatakip
{
    /// <summary>
    /// Kullanıcı giriş ekranı
    /// Admin ve Personel login işlemini yönetir
    /// </summary>
    public class GirisFormu : Form
    {
        // Giriş yapan kullanıcıyı depolamak için static değişken
        // Uygulama genelinde erişilebilir
        public static Kullanici? GirisYapanKullanici { get; set; }

        // Form elemanları
        private TextBox txtKullaniciAdi;
        private TextBox txtSifre;
        private Button btnGirisYap;
        private Button btnIptal;

        public GirisFormu()
        {
            // Form ayarlarını yap
            this.Text = "Mobilya Stok Takip - Giriş"; // Pencerenin başlığı
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Pencere boyutu değiştirilemez
            this.MaximizeBox = false; // Maximize butonu gizle
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında aç
            this.Size = new Size(450, 300); // Pencere boyutu
            this.BackColor = SystemColors.Control; // Arka plan rengi

            // Arayüz elemanlarını oluştur
            OlusturArayuz();
        }

        // Arayüz elemanlarını oluştur (Label, TextBox, Button vs.)
        private void OlusturArayuz()
        {
            // Başlık etiketi
            Label lblBaslik = new Label
            {
                Text = "Giriş Yapın",
                Font = new Font("Arial", 18, FontStyle.Bold), // Kalın, büyük yazı
                Location = new Point(170, 20), // X=170, Y=20 konumunda
                AutoSize = true
            };
            this.Controls.Add(lblBaslik); // Forma ekle

            // Kullanıcı adı etiketi
            Label lblKullaniciAdi = new Label
            {
                Text = "Kullanıcı Adı:", // Gösterilecek metin
                Location = new Point(50, 70),
                AutoSize = true
            };
            this.Controls.Add(lblKullaniciAdi);

            // Kullanıcı adı giriş kutusu
            txtKullaniciAdi = new TextBox
            {
                Location = new Point(50, 95), // X=50, Y=95 konumunda
                Size = new Size(350, 30), // Genişlik=350, Yükseklik=30
                Font = new Font("Arial", 11)
            };
            this.Controls.Add(txtKullaniciAdi);

            // Şifre etiketi
            Label lblSifre = new Label
            {
                Text = "Şifre:",
                Location = new Point(50, 130),
                AutoSize = true
            };
            this.Controls.Add(lblSifre);

            // Şifre giriş kutusu (PasswordChar = '*' ile şifre gizlenir)
            txtSifre = new TextBox
            {
                Location = new Point(50, 155),
                Size = new Size(350, 30),
                Font = new Font("Arial", 11),
                PasswordChar = '*' // Yazılan karakterler * olarak gösterilir (güvenlik için)
            };
            this.Controls.Add(txtSifre);

            // Giriş Yap butonu
            btnGirisYap = new Button
            {
                Text = "Giriş Yap", // Butonun üzerindeki yazı
                Location = new Point(100, 220),
                Size = new Size(120, 40),
                BackColor = Color.Green, // Yeşil arka plan
                ForeColor = Color.White, // Beyaz yazı
                Font = new Font("Arial", 11, FontStyle.Bold),
                Cursor = Cursors.Hand // Fare üzerine gelince el göstergesi
            };
            btnGirisYap.Click += BtnGirisYap_Click; // Tıklama olayını bağla
            this.Controls.Add(btnGirisYap);

            // İptal butonu
            btnIptal = new Button
            {
                Text = "İptal",
                Location = new Point(240, 220),
                Size = new Size(120, 40),
                BackColor = Color.Red, // Kırmızı arka plan
                ForeColor = Color.White,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnIptal.Click += (s, e) => this.Close(); // Tıklanınca formu kapat
            this.Controls.Add(btnIptal);
        }

        // Giriş Yap butonuna tıklandığında çalışan metod
        private async void BtnGirisYap_Click(object sender, EventArgs e)
        {
            // TextBox'lardan değerleri al
            string kullaniciAdi = txtKullaniciAdi.Text.Trim(); // Başında ve sonundaki boşlukları sil
            string sifre = txtSifre.Text;

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi sonlandır
            }

            // Veritabanında kontrol et
            await GirisKontrolEt(kullaniciAdi, sifre);
        }

        // Veritabanında kullanıcı adı ve şifreyi kontrol et
        private async Task GirisKontrolEt(string kullaniciAdi, string sifre)
        {
            try
            {
                // Veritabanı bağlantısı oluştur
                using (var db = new StokDbContext())
                {
                    // Veritabanında kullanıcıyı ara
                    // FirstOrDefault: İlk eşleşen kullanıcıyı döndür, yoksa null
                    var kullanici = await Task.Run(() =>
                        db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi)
                    );

                    // Kullanıcı bulunamadıysa
                    if (kullanici == null)
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Giriş yapma
                    }

                    // Şifreyi düz metin karşılaştırması (geçici, sonra hash yapılacak)
                    if (sifre != kullanici.Sifre)
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Başarılı giriş - kullanıcıyı kaydet
                    GirisYapanKullanici = kullanici;

                    // Başarı mesajı
                    MessageBox.Show($"Hoş geldiniz {kullanici.KullaniciAdi}!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ana forma (Form1) geç
                    Form1 anaForm = new Form1();
                    anaForm.Show();

                    // Giriş formunu kapat
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Hata oluşursa mesaj göster
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
