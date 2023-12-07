using System.Globalization;

namespace gorsel_programlam_odev1;

public partial class kerdi_Hesaplama : ContentPage
{
	public kerdi_Hesaplama()
	{
		InitializeComponent();
	}


    private void CalculateButton_Clicked(object sender, EventArgs e)
    {
        string loanType = LoanTypePicker.SelectedItem as string;
        double loanAmount = Convert.ToDouble(LoanAmountEntry.Text);
        double interestRate = Convert.ToDouble(InterestRateEntry.Text);
        int loanTerm = Convert.ToInt32(LoanTermEntry.Text);

      
        var result = CalculateLoan(loanType, loanAmount, interestRate, loanTerm);

     
        ResultLabel.Text = $"Aylik Taksit: {result.monthlyPayment.ToString("C", new CultureInfo("tr-TR"))}\n" +
                          $"Toplam Ödeme: {result.totalPayment.ToString("C", new CultureInfo("tr-TR"))}\n" +
                          $"Toplam Faiz: {result.totalInterest.ToString("C", new CultureInfo("tr-TR"))}";
    }

    private (double monthlyPayment, double totalPayment, double totalInterest) CalculateLoan(string loanType, double loanAmount, double interestRate, int loanTerm)
    {
        double KKDF = 0; 
        double BSMV = 0; 

        
        if (loanType == "Ihtiyaç Kredisi")
        {
            KKDF = 15;
            BSMV = 10;
        }
        else if (loanType == "Tasit Kredisi")
        {
            KKDF = 15;
            BSMV = 5;
        }
        else if (loanType == "Konut Kredisi")
        {
  
        }
        else if (loanType == "Ticari Kredisi")
        {
            BSMV = 5;
        }

        double brutFaiz = ((interestRate + (interestRate * BSMV / 100) + (interestRate * KKDF / 100)) / 100);
        double taksit = ((Math.Pow(1 + brutFaiz, loanTerm) * brutFaiz) / (Math.Pow(1 + brutFaiz, loanTerm) - 1)) * loanAmount;
        double totalPayment = taksit * loanTerm;
        double totalInterest = totalPayment - loanAmount;

        return (taksit, totalPayment, totalInterest);
    }

}
