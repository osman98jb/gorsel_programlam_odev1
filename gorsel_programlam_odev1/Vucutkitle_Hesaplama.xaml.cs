namespace gorsel_programlam_odev1;

public partial class Vucutkitle_Hesaplama : ContentPage
{
	public Vucutkitle_Hesaplama()
	{
		InitializeComponent();
    }
  

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        double weight = double.Parse(WeightEntry.Text);
        double height = double.Parse(HeightEntry.Text) / 100;  

        double bmi = weight / (height * height);

        ResultLabel.Text = $"Vucut kutleniz: {bmi:F2}";

        
        InterpretBMI(bmi);
    }

    private void InterpretBMI(double bmi)
    {
        if (bmi < 16)
        {
            ResultLabel.Text += "\nAsari Zayif";
        }
        else if (bmi >= 16 && bmi <= 16.99)
        {
            ResultLabel.Text += "\nOrta Düzeyde Zayif";
        }
        else if (bmi >= 17 && bmi <= 18.50)
        {
            ResultLabel.Text += "\nHafif Düzeyde Zayif";
        }
        else if (bmi >= 18.51 && bmi <= 25)
        {
            ResultLabel.Text += "\nNormal Kilolu";
        }
        else if (bmi >= 25.1 && bmi <= 29.99)
        {
            ResultLabel.Text += "\nHafif sisman / Fazla Kilolu";
        }
        else if (bmi >= 30 && bmi <= 34.99)
        {
            ResultLabel.Text += "\n1. Derece Obez";
        }
        else if (bmi >= 35 && bmi <= 39.99)
        {
            ResultLabel.Text += "\n2. Derece Obez";
        }
        else
        {
            ResultLabel.Text += "\n3. Derece Obez";
        }
    }

}