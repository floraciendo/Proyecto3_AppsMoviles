using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Repositories;
using FinanceTracker.MVVM.Models;

namespace FinanceTracker.MVVM.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly ITransactionRepository _repository;

    [ObservableProperty]
    private ObservableCollection<Transaction> transactions;

    [ObservableProperty]
    private float totalIncome;

    [ObservableProperty]
    private float totalExpenses;

    [ObservableProperty]
    private float balance;

    public MainPageViewModel(ITransactionRepository repository)
    {
        _repository = repository;
        Transactions = new ObservableCollection<Transaction>();
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        var transaction_list = await _repository.GetTransactionsAsync();
        Transactions = new ObservableCollection<Transaction>(transaction_list);

        TotalIncome = await _repository.GetTotalIncomeAsync();
        TotalExpenses = await _repository.GetTotalExpensesAsync();
        Balance = TotalIncome - TotalExpenses;
    }

    [RelayCommand]
    private async Task GoToTransactionPage()
    {
        await Shell.Current.GoToAsync("TransactionPage");
    }

}