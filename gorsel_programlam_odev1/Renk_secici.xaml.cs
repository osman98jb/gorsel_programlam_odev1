namespace gorsel_programlam_odev1;

public partial class Renk_secici : ContentPage
{
	public Renk_secici()
	{
		InitializeComponent();

    }
    private void GenerateRandomColor_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        byte red = (byte)random.Next(256);
        byte green = (byte)random.Next(256);
        byte blue = (byte)random.Next(256);

        redSlider.Value = red;
        greenSlider.Value = green;
        blueSlider.Value = blue;

        SetColor(red, green, blue);
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        byte red = (byte)redSlider.Value;
        byte green = (byte)greenSlider.Value;
        byte blue = (byte)blueSlider.Value;

        SetColor(red, green, blue);
    }

    private void SetColor(byte red, byte green, byte blue)
    {
        rgbCodeLabel.Text = $"RGB Code: ({red}, {green}, {blue})";

        
        colorBox.Color = Color.FromRgb(red, green, blue);
    }
}




