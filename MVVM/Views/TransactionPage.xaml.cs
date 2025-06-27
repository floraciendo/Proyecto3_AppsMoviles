using FinanceTracker.MVVM.ViewModels;

namespace FinanceTracker.MVVM.Views;

public partial class TransactionPage : ContentPage
{
	public TransactionPage(TransactionPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

