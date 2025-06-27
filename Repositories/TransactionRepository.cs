using FinanceTracker.MVVM.Models;
using SQLite;

namespace FinanceTracker.Repositories;
public class TransactionRepository : ITransactionRepository
{
    private readonly SQLiteAsyncConnection _connection;

    public TransactionRepository(string dbPath)
    {
        _connection = new SQLiteAsyncConnection(dbPath);
        _connection.CreateTableAsync<Transaction>().Wait();
    }

    public Task<int> AddTransactionAsync(Transaction transaction)
    {
        return _connection.InsertAsync(transaction);
    }

    public Task<List<Transaction>> GetTransactionsAsync()
    {
        return _connection.Table<Transaction>().OrderByDescending(t => t.Date).ToListAsync();
    }

    public async Task<float> GetTotalIncomeAsync() {
        var income = await _connection.Table<Transaction>().Where(t => t.IsIncome).ToListAsync();
        return income.Sum(t => t.Value);
    }

    public async Task<float> GetTotalExpensesAsync()
    {
        var expenses = await _connection.Table<Transaction>().Where(t => !t.IsIncome).ToListAsync();
        return expenses.Sum(t => t.Value);
    }
}