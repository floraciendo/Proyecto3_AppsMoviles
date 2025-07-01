using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinanceTracker.Repositories;
using FinanceTracker.MVVM.Models;
using FinanceTracker.MVVM.Views;
using System;

namespace FinanceTracker.MVVM.ViewModels;

public partial class TransactionPageViewModel : ObservableObject
{
    private readonly ITransactionRepository _repository;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private decimal value;

    [ObservableProperty]
    private DateTime date = DateTime.Now;

    [ObservableProperty]
    private bool isIncome;

    public TransactionPageViewModel(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    private async Task SaveTransactionAsync()
    {
        if (string.IsNullOrWhiteSpace(Description) || Value <= 0)
        {
            return;
        }

        var new_transaction = new Transaction
        {
            Description = Description,
            Value = Value,
            Date = Date,
            IsIncome = IsIncome
        };

        await _repository.AddTransactionAsync(new_transaction);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task CancelTransactionAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}