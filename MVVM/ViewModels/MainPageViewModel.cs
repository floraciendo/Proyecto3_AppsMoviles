using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Repositories;
using FinanceTracker.MVVM.Models;
using System.Diagnostics;

namespace FinanceTracker.MVVM.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly ITransactionRepository _repository;

    [ObservableProperty]
    private ObservableCollection<Transaction> transactions;

    [ObservableProperty]
    private decimal totalIncome;

    [ObservableProperty]
    private decimal totalExpenses;

    [ObservableProperty]
    private decimal balance;

    public MainPageViewModel(ITransactionRepository repository)
    {
        _repository = repository;
        Transactions = new ObservableCollection<Transaction>();
    }

    public async Task LoadDataAsync()
    {
        var transaction_list = await _repository.GetTransactionsAsync();
        Transactions = new ObservableCollection<Transaction>(transaction_list);
        // Borrar después
        Debug.WriteLine($"Cantidad de transacciones: {Transactions?.Count ?? 0}");

        TotalIncome = await _repository.GetTotalIncomeAsync();
        TotalExpenses = await _repository.GetTotalExpensesAsync();
        Balance = TotalIncome - TotalExpenses;
    }

    [RelayCommand]
    private async Task GoToTransactionPage()
    {
        await Shell.Current.GoToAsync("TransactionPage");
    }

    // Borrar después
    [RelayCommand]
    private async Task DeleteAllTransactionsAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Confirmar",
            "¿Estás seguro de eliminar TODAS las transacciones?",
            "Sí", "No");
        
        if (confirm)
        {
            await _repository.DeleteTransactionsAsync();
            await LoadDataAsync();
            await Shell.Current.DisplayAlert("Éxito", "Transacciones eliminadas", "OK");
        }
    }

}