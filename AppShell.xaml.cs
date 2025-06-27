using FinanceTracker.MVVM.Views;

namespace FinanceTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("TransactionPage", typeof(TransactionPage));
		Routing.RegisterRoute("MainPage", typeof(MainPage));
	}
}
