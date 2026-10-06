namespace mobilyatakip
{
    /// <summary>
    /// Ana uygulama formu
    /// Giriş yapan kullanıcı burada malzeme yönetimini yapacak
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form1 oluşturma hatası:\n{ex.Message}", "Hata");
            }
        }

        // Form Load olayı
        private void Form1_Load(object sender, EventArgs e)
        {
            // Form başlık ve ayarları
            this.Text = "Mobilya Stok Takip Sistemi - Ana Menü";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Hoş geldiniz mesajı
            Label lblHosgeldiniz = new Label
            {
                Text = "Hoş Geldiniz!",
                Font = new Font("Arial", 20, FontStyle.Bold),
                Location = new Point(300, 250),
                AutoSize = true
            };
            this.Controls.Add(lblHosgeldiniz);

            Label lblMesaj = new Label
            {
                Text = "Giriş başarılı! Sistem açılıyor...",
                Font = new Font("Arial", 12),
                Location = new Point(250, 300),
                AutoSize = true
            };
            this.Controls.Add(lblMesaj);
        }
    }
}
