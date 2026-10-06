namespace mobilyatakip
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın giriş noktası
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Uygulamayı başlat
                ApplicationConfiguration.Initialize();

                // GirisFormu ile başlat (login ekranı ilk açılacak)
                Application.Run(new GirisFormu());
            }
            catch (Exception ex)
            {
                // Hatayı göster
                MessageBox.Show($"HATA:\n{ex.Message}\n\n{ex.StackTrace}", "Uygulama Hatası");
            }
        }
    }
}

