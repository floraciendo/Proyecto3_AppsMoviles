using FinanceTracker.MVVM.ViewModels;

namespace FinanceTracker.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

