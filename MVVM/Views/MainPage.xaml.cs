namespace FinanceTracker.MVVM.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnAgregarTransaccionClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(TransactionPage));
	}

}

