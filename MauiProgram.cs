using FinanceTracker.MVVM.ViewModels;
using FinanceTracker.MVVM.Views;
using FinanceTracker.Repositories;
using Microsoft.Extensions.Logging;

namespace FinanceTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "transactions.db");
		builder.Services.AddSingleton<ITransactionRepository>(new TransactionRepository(dbPath));
		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<TransactionPageViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<TransactionPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
