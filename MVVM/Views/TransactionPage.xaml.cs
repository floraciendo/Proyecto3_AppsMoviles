namespace FinanceTracker.MVVM.Views;

public partial class TransactionPage : ContentPage
{

    public TransactionPage()
    {
        InitializeComponent();
    }
    
    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}

