namespace BahsisHesaplayici;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Slider hareket edince oranı güncelle
    private void OnYuzdeDegisti(object sender, ValueChangedEventArgs e)
    {
        if (YuzdeLabel != null)
            YuzdeLabel.Text = $"Bahşiş Oranı: %{(int)e.NewValue}";
    }

    // Stepper'a basınca kişi sayısını güncelle
    private void OnKisiDegisti(object sender, ValueChangedEventArgs e)
    {
        if (KisiLabel != null)
            KisiLabel.Text = $"Kişi Sayısı: {(int)e.NewValue}";
    }

    private void OnHesaplaClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(TutarEntry.Text, out double tutar) || tutar <= 0)
        {
            SonucLabel.TextColor = Colors.Red;
            SonucLabel.Text = "Lütfen geçerli bir tutar girin.";
            return;
        }

        int yuzde = (int)YuzdeSlider.Value;
        int kisi = (int)KisiStepper.Value;

        double bahsis = tutar * yuzde / 100;
        double toplam = tutar + bahsis;
        double kisiBasi = toplam / kisi;

        SonucLabel.TextColor = Colors.Green;
        SonucLabel.Text = $"Bahşiş: {bahsis:F2} ₺\n" +
                          $"Toplam: {toplam:F2} ₺\n" +
                          $"Kişi başı: {kisiBasi:F2} ₺";
    }

    private void OnTemizleClicked(object sender, EventArgs e)
    {
        TutarEntry.Text = string.Empty;
        YuzdeSlider.Value = 10;
        KisiStepper.Value = 1;
        SonucLabel.Text = string.Empty;
    }
}