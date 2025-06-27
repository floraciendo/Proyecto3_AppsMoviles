using FinanceTracker.MVVM.Models;

namespace FinanceTracker.Repositories;
public interface ITransactionRepository
{
    Task<int> AddTransactionAsync(Transaction transaction);
    Task<List<Transaction>> GetTransactionsAsync();
    Task<float> GetTotalIncomeAsync();
    Task<float> GetTotalExpensesAsync();
}