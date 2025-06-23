using FinanceTracker.MVVM.Views;

namespace FinanceTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TransactionPage), typeof(TransactionPage));
	}
}
